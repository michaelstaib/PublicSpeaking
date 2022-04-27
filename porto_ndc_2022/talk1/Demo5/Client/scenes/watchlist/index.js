import {Suspense} from 'react';

import {ActivityIndicator, ErrorBoundaryWithRetry} from '@/components';

import WatchlistContainer from './WatchlistContainer';

export const Watchlist = () => (
  <ErrorBoundaryWithRetry>
    {({cacheBuster}) => (
      <Suspense fallback={<ActivityIndicator />}>
        <WatchlistContainer cacheBuster={cacheBuster} />
      </Suspense>
    )}
  </ErrorBoundaryWithRetry>
);
