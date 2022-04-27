import {useReducer} from 'react';

/**
 * React state hook that causes a re-render of the component.
 * @see https://reactjs.org/docs/hooks-faq.html#is-there-something-like-forceupdate
 *
 * @example
 * const Random = () => {
 *   const forceUpdate = useForceUpdate();
 *
 *   return (
 *     <>
 *       Random number: {random(1, 100)}
 *       <hr />
 *       <button onClick={forceUpdate}>try again</button>
 *     </>
 *   );
 * };
 */
export const useForceUpdate = () => {
  const [, forceUpdate] = useReducer((i) => i + 1, 0);

  return forceUpdate;
};
