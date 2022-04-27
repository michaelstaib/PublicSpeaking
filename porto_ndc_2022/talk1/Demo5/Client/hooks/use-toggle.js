import {useCallback, useState} from 'react';

/**
 * React state hook that tracks value of a boolean.
 *
 * **Note**: The identity of the updater functions is stable and won’t change on re-renders.
 *
 * @param initial - Initial value.
 * @returns A stateful value and updater functions (i.e., `toggle` and `setValue`).
 *
 * @example
 * const Spoiler = ({children}) => {
 *   const [visible, toggle] = useToggle(false);
 *
 *   return (
 *     <div>
 *       <button onClick={toggle}>{visible ? 'hide' : 'show'}</button>
 *       {visible && children}
 *     </div>
 *   );
 * };
 */
export const useToggle = (initial = false) => {
  const [value, setValue] = useState(initial);
  const toggle = useCallback(() => {
    setValue((v) => !v);
  }, []);

  return [value, toggle, setValue];
};
