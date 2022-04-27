/**
 * Used for percentage values, it returns a formatted string according to the locale and percent formatting options.
 *
 * @example
 * formatPercent(0.1); // → +10.00%
 *
 * @example
 * formatPercent(0.1011); // → +10.11%
 *
 * @example
 * formatPercent(0.1011, {minimumFractionDigits: 0}); // → +10%
 *
 * @example
 * formatPercent(0.1091); // → +10.91%
 *
 * @example
 * formatPercent(0.1091, {minimumFractionDigits: 0}); // → +11%
 */
export const formatPercent = (value, options = {}, locales = 'en') =>
  Intl.NumberFormat(locales, {
    style: 'percent',
    minimumFractionDigits: 2,
    signDisplay: 'exceptZero',
    ...options,
  }).format(value);

/**
 * Used for monetary values, it returns a formatted string according to the locale and currency formatting options.
 *
 * @example
 * formatCurrency(100, {currency: 'USD'}); // → $100.00
 */
export const formatCurrency = (value, options = {}, locales = 'en') =>
  Intl.NumberFormat(locales, {style: 'currency', ...options}).format(value);

/**
 * Used for monetary values, it returns an array of objects representing the number string in parts according to the locale and currency formatting options.
 *
 * @example
 * formatCurrencyToParts(100, {currency: 'USD'}); // → [
 *                                                       {type: 'currency', value: '$'},
 *                                                       {type: 'integer', value: '100'},
 *                                                       {type: 'decimal', value: '.'},
 *                                                       {type: 'fraction', value: '00'},
 *                                                     ]
 */
export const formatCurrencyToParts = (value, options = {}, locales = 'en') =>
  Intl.NumberFormat(locales, {style: 'currency', ...options}).formatToParts(
    value,
  );

/**
 * Used for monetary values, it returns a formatted string using compact notation according to the locale and currency formatting options.
 *
 * @example
 * formatCurrencyUsingCompactNotation(747106164000, {currency: 'USD'}); // → $747.1B
 */
export const formatCurrencyUsingCompactNotation = (
  value,
  options = {},
  locales = 'en',
) =>
  new Intl.NumberFormat(locales, {
    style: 'currency',
    notation: 'compact',
    compactDisplay: 'short',
    maximumFractionDigits: 1,
    ...options,
  }).format(value);

/**
 * Used for numeric values, it returns a formatted string using compact notation according to the locale and decimal formatting options.
 *
 * @example
 * formatDecimalUnitUsingCompactNotation(21000000); // → 21M
 */
export const formatDecimalUnitUsingCompactNotation = (
  value,
  options = {},
  locales = 'en',
) =>
  new Intl.NumberFormat(locales, {
    style: 'decimal',
    notation: 'compact',
    compactDisplay: 'short',
    maximumFractionDigits: 1,
    ...options,
  }).format(value);
