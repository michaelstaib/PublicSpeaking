/**
 * Tokenizes the sign of a number.
 *
 * @example
 * direction(0.12); // → positive
 *
 * @example
 * direction(-0.12); // → negative
 *
 * @example
 * direction(0); // → neutral
 */
export const direction = (value) =>
  value > 0 ? 'positive' : value < 0 ? 'negative' : 'neutral';

/**
 * Returns the non-strict inequality symbol for the comparison between the given numbers.
 *
 * @example
 * inequality(0.15); // → >=
 *
 * @example
 * inequality(-0.15); // → <=
 */
export const inequality = (a, b = 0) => (a >= b ? '>=' : '<=');

/**
 * Rounds a number to a given number of decimal places.
 *
 * @example
 * round(123.14499999997, 2); // → 123.14
 *
 * @example
 * round(123.14499999997, 1); // → 123.1
 *
 * @example
 * round(123.14499999997, 0); // → 123
 */
export const round = (value, decimals = 0) => {
  const factor = 10 ** decimals;

  return Math.round(value * factor) / factor;
};
