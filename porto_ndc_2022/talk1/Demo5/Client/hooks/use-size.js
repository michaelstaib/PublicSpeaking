import {useRef, useState} from 'react';

import {useResizeObserver} from './use-resize-observer';

/**
 * React layout hook that tracks the size of a HTML element.
 *
 * @example
 * const MyComponent = () => {
 *   const [targetRef, size] = useSize();
 *
 *   return (
 *     <div ref={targetRef}>
 *       <div>Height: {size.height}</div>
 *       <div>Width: {size.width}</div>
 *     </div>
 *   );
 * };
 */
export const useSize = () => {
  const targetRef = useRef(null);
  const [size, setSize] = useState(null);

  useResizeObserver(
    targetRef,
    (entries) => {
      for (const {
        contentRect: {height, width},
      } of entries) {
        setSize({height, width});
      }
    },
    {box: 'border-box'},
  );

  return [targetRef, size];
};
