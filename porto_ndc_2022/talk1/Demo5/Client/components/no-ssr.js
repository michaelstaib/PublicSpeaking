import dynamic from 'next/dynamic';

export const NoSSR = dynamic(
  () =>
    Promise.resolve(function NoSSR({children}) {
      return children;
    }),
  {
    ssr: false,
  },
);
