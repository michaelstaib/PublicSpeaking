import {useReducer} from 'react';

/**
 * React state hook that exposes an incremental counter.
 *
 * @example
 * const Counter = () => {
 *   const [counter, setCounter] = useCounter(0, 1);
 *
 *   return (
 *     <>
 *       Counter: {counter}
 *       <hr />
 *       <button onClick={setCounter}>+1</button>
 *     </>
 *   );
 * };
 */
export const useCounter = (initial = 0, step = 1) => {
  const [counter, setCounter] = useReducer((prev) => prev + step, initial);

  return [counter, setCounter];
};
