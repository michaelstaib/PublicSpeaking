import {useIsomorphicEffect} from './use-isomorphic-effect';

/**
 * React effectful hook which provides a way to asynchronously observe changes in the intersection of a target element with an ancestor element or with a top-level document's viewport.
 * @see https://developer.mozilla.org/en-US/docs/Web/API/IntersectionObserver
 *
 * @param target A React ref created by `useRef()` and attached to a HTML element.
 * @param callback A function which will be called when it detects that a target element's visibility has crossed one or more thresholds.
 * @param options An object providing options, useful for watching for specific changes in degree of visibility.
 *
 * @example
 * const MyComponent = ({children}) => {
 *   const targetRef = useRef(null);
 *
 *   useIntersectionObserver(
 *     targetRef,
 *     () => {
 *       console.log('threshold reached');
 *     },
 *     {threshold: 0.5},
 *   );
 *
 *   return <div ref={targetRef}>{children}</div>
 * };
 */
export const useIntersectionObserver = (target, callback, options) => {
  useIsomorphicEffect(() => {
    if (target.current) {
      const observer = new IntersectionObserver(callback);

      observer.observe(target.current, options);

      return () => {
        observer.disconnect();
      };
    }
  }, []);
};
