'use strict';

const relay = require('./relay.config');

module.exports = {
  reactStrictMode: true,
  i18n: {
    locales: ['en'],
    defaultLocale: 'en',
  },
  devIndicators: {
    buildActivity: false,
  },
  compiler: {
    relay,
  },
  experimental: {
    reactRoot: 'concurrent',
    concurrentFeatures: true,
  },
};
