const seed = {};

export const syncWithStorage = (
  source,
  storage = typeof localStorage !== 'undefined' && localStorage,
) => {
  const target = Object.assign(seed, source);

  if (storage) {
    for (const [key, value] of Object.entries(source)) {
      if (value === undefined) {
        const stored = storage.getItem(key);

        if (stored !== null) {
          target[key] = JSON.parse(stored);
        }
      } else {
        storage.setItem(key, JSON.stringify(value));
      }
    }
  }

  return target;
};

export const Config = syncWithStorage({
  MODE: process.env.NEXT_PUBLIC_MODE,

  HTTP_ENDPOINT: process.env.NEXT_PUBLIC_HTTP_ENDPOINT,
  WS_ENDPOINT: process.env.NEXT_PUBLIC_WS_ENDPOINT,

  USERNAME: process.env.NEXT_PUBLIC_USERNAME,
  PASSWORD: process.env.NEXT_PUBLIC_PASSWORD,

  AUTH_TOKEN: process.env.NEXT_PUBLIC_AUTH_TOKEN,
});
