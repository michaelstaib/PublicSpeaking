import extractFiles from 'extract-files/extractFiles.mjs';
import isExtractableFile from 'extract-files/isExtractableFile.mjs';
import {createClient} from 'graphql-ws';
import {meros} from 'meros/browser';
import {useMemo} from 'react';
import {
  Environment,
  Network,
  Observable,
  RecordSource,
  Store,
} from 'relay-runtime';

import {Config} from '@/config';
import {isAsyncIterable, merge, pause} from '@/utils';

let relayEnvironment;

const ErrorMessages = {
  FAILED_FETCH: 'Failed to fetch',
  ERROR_FETCH: 'Error in fetch',
  UNWORKABLE_FETCH: 'Unworkable fetch',
  SOCKET_CLOSED: 'Socket closed',
  GRAPHQL_ERRORS: 'GraphQL error',
};

class NetworkError extends Error {
  constructor(message, options) {
    super(message, options);

    this.name = 'NetworkError';

    if (options) {
      const {cause, ...meta} = options;

      Object.assign(this, meta);
    }
  }
}

const fetchFn = (operation, variables, cacheConfig, uploadables) => {
  const httpEndpoint = Config.HTTP_ENDPOINT;
  const authToken = Config.AUTH_TOKEN;

  return Observable.create((sink) => {
    const init = {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        Authorization: authToken ? `basic ${authToken}` : undefined,
      },
    };

    const {clone, files} = extractFiles(
      {
        id: operation.id ?? undefined,
        query: operation.text ?? undefined,
        variables,
      },
      isExtractableFile,
    );

    if (files.size) {
      const form = new FormData();

      form.set('operations', JSON.stringify(clone));

      const map = {};
      let i = 0;

      files.forEach((paths) => {
        map[i++] = paths;
      });

      form.set('map', JSON.stringify(map));

      i = 0;
      files.forEach((paths, file) => {
        form.set(`${i++}`, file, file.name);
      });

      merge(init, {
        body: form,
      });
    } else {
      merge(init, {
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(clone),
      });
    }

    (async () => {
      const request = new Request(httpEndpoint, init);

      try {
        const response = await fetch(request);

        // Status code in range 200-299 inclusive (2xx).
        if (response.ok) {
          try {
            const parts = await meros(response);

            if (isAsyncIterable(parts)) {
              for await (const part of parts) {
                if (!part.json) {
                  sink.error(
                    new NetworkError(ErrorMessages.UNWORKABLE_FETCH, {
                      request,
                      response,
                    }),
                  );
                  break;
                }

                // If any exceptions occurred when processing the request,
                // throw an error to indicate to the developer what went wrong.
                if (Array.isArray(part.body.errors)) {
                  sink.error(
                    new NetworkError(ErrorMessages.GRAPHQL_ERRORS, {
                      request,
                      response,
                    }),
                  );
                  break;
                }

                // DEMO: delay chunked responses
                // await pause(2_000);

                // HACK: if `label` is present, also `path` is required, remove once fixed in HC
                // @see https://github.com/maraisr/meros/issues/15#issuecomment-1054268416
                if (part.body.label && !part.body.path) {
                  part.body.path = [];
                }

                sink.next(part.body);
              }
            } else {
              const json = await response.json();

              // If any exceptions occurred when processing the request,
              // throw an error to indicate to the developer what went wrong.
              if (Array.isArray(json.errors)) {
                sink.error(
                  new NetworkError(ErrorMessages.GRAPHQL_ERRORS, {
                    request,
                    response,
                  }),
                );
              } else {
                // DEMO: delay response
                // await pause(2_000);

                sink.next(json);
              }
            }

            sink.complete();
          } catch (err) {
            sink.error(
              new NetworkError(ErrorMessages.UNWORKABLE_FETCH, {
                cause: err,
                request,
                response,
              }),
              true,
            );
          }
        } else {
          sink.error(
            new NetworkError(ErrorMessages.ERROR_FETCH, {request, response}),
          );
        }
      } catch (err) {
        sink.error(
          new NetworkError(ErrorMessages.FAILED_FETCH, {cause: err, request}),
          true,
        );
      }
    })();
  });
};

let wsClient;

/**
 * With `graphql-ws`.
 * @see https://github.com/enisdenjo/graphql-ws
 */
const subscribeFn = (operation, variables) => {
  const wsEndpoint = Config.WS_ENDPOINT;
  const authToken = Config.AUTH_TOKEN;

  const client = (wsClient ??= createClient({
    url: wsEndpoint,
    connectionParams: {
      Authorization: authToken ? `basic ${authToken}` : undefined,
    },
  }));

  return Observable.create((sink) =>
    client.subscribe(
      {
        id: operation.id ?? undefined,
        query: operation.text,
        variables,
      },
      {
        ...sink,
        error: (err) => {
          if (Array.isArray(err)) {
            return sink.error(
              new NetworkError(ErrorMessages.ERROR_FETCH, {cause: err}),
            );
          }

          if (err instanceof CloseEvent) {
            return sink.error(
              new NetworkError(ErrorMessages.SOCKET_CLOSED, {cause: err}),
            );
          }

          return sink.error(err, true);
        },
      },
    ),
  );
};

const createEnvironment = (initialRecords) => {
  const source = new RecordSource(initialRecords);

  /**
   * Presence of Data
   * @see https://relay.dev/docs/guided-tour/reusing-cached-data/presence-of-data/
   *
   * - Note that having a buffer size of 0 is equivalent to not having the release buffer, which means that queries will be immediately released and collected.
   * - By default, environments have a release buffer size of 10.
   *
   * @example
   * // last 10 queries
   * gcReleaseBufferSize: 10,
   *
   *
   * Staleness of Data
   * @see https://relay.dev/docs/guided-tour/reusing-cached-data/staleness-of-data/
   *
   * - If the query cache expiration time is not provided, staleness checks only look at whether the referenced records have been invalidated.
   *
   * @example
   * // 1 min
   * queryCacheExpirationTime: 60 * 1_000,
   */
  const options = {};

  const store = new Store(source, options);

  const network = Network.create(fetchFn, subscribeFn);

  return new Environment({
    network,
    store,
  });
};

export const initEnvironment = (initialRecords) => {
  // Create a network layer from the fetch function
  const environment = relayEnvironment ?? createEnvironment(initialRecords);

  // If your page has Next.js data fetching methods that use Relay, the initial records
  // will get hydrated here
  if (initialRecords) {
    environment.getStore().publish(new RecordSource(initialRecords));
  }
  // For SSG and SSR always create a new Relay environment
  if (typeof window === 'undefined') return environment;
  // Create the Relay environment once in the client
  if (!relayEnvironment) relayEnvironment = environment;

  return relayEnvironment;
};

export const useEnvironment = (initialRecords) =>
  useMemo(() => initEnvironment(initialRecords), [initialRecords]);
