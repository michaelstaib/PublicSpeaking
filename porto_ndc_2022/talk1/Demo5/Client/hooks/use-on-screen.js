import {useRef, useState} from 'react';

import {useIntersectionObserver} from './use-intersection-observer';

/**
 * React layout hook that tracks the visibility of a HTML element.
 *
 * @example
 * const MyComponent = () => {
 *   const [spyRef, active] = useOnScreen();
 *
 *   return (
 *     <div ref={spyRef}>
 *       <div>On screen: {active}</div>
 *     </div>
 *   );
 * };
 */
export const useOnScreen = () => {
  const targetRef = useRef(null);
  const [isIntersecting, setIntersecting] = useState(false);

  useIntersectionObserver(targetRef, (entries) => {
    setIntersecting(entries.some((entry) => entry.isIntersecting));
  });

  return [targetRef, isIntersecting];
};
