import Head from 'next/head';

export const Metadata = ({title = 'Crypto', description = 'Crypto'}) => (
  <Head>
    <meta httpEquiv="Content-type" content="text/html; charset=utf-8" />
    <meta name="description" content={description} />
    <meta name="viewport" content="initial-scale=1, width=device-width" />
    <title>{title}</title>

    {/* <!-- Favicons --> */}
    <link
      key="favicon:1"
      rel="apple-touch-icon"
      sizes="180x180"
      href="/favicon/apple-touch-icon.png"
    />
    <link
      key="favicon:2"
      rel="icon"
      type="image/png"
      sizes="32x32"
      href="/favicon/favicon-32x32.png"
    />
    <link
      key="favicon:3"
      rel="icon"
      type="image/png"
      sizes="16x16"
      href="/favicon/favicon-16x16.png"
    />
    <link key="favicon:4" rel="icon" href="/favicon/favicon.ico" />
    <link key="manifest" rel="manifest" href="/manifest.webmanifest" />
  </Head>
);
