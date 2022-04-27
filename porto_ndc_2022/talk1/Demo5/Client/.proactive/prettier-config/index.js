'use strict';

module.exports = {
  $schema: 'http://json.schemastore.org/prettierrc',
  printWidth: 80,
  tabWidth: 2,
  useTabs: false,
  semi: true,
  singleQuote: true,
  trailingComma: 'all',
  bracketSpacing: false,
  bracketSameLine: false,
  arrowParens: 'always',
  plugins: [require.resolve('@proactive/prettier-plugin-sort-imports')],
};
