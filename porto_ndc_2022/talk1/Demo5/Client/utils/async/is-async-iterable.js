/**
 * Returns true if the provided object implements the AsyncIterator protocol via
 * implementing a `Symbol.asyncIterator` method.
 *
 * @example
 * isAsyncIterable({}); // → false
 *
 * @example
 * async function* asyncGeneratorFunc() {
 *   // do nothing
 * }
 * isAsyncIterable(asyncGeneratorFunc()); // → true
 */
export const isAsyncIterable = (value) =>
  typeof Object(value)[Symbol.asyncIterator] === 'function';
