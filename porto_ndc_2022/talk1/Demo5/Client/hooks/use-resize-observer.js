import {useIsomorphicEffect} from './use-isomorphic-effect';

/**
 * React effectful hook which invokes a specified callback to report changes to the dimensions of a HTML element.
 * @see https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserver
 *
 * @param target A React ref created by `useRef()` and attached to a HTML element.
 * @param callback A function which will be called on each change changes to the content or border box of an Element or the bounding box of an SVGElement.
 * @param options An object providing options for the observation.
 *
 * @example
 * const MyComponent = ({children}) => {
 *   const targetRef = useRef(null);
 *
 *   useResizeObserver(
 *     targetRef,
 *     (entries) => {
 *       for (const {
 *         contentRect: {height, width},
 *       } of entries) {
 *         console.log('size', `${height} x ${width}`);
 *       }
 *     },
 *     {box: 'border-box'},
 *   );
 *
 *   return <div ref={targetRef}>{children}</div>
 * };
 */
export const useResizeObserver = (target, callback, options) => {
  useIsomorphicEffect(() => {
    if (target.current) {
      const observer = new ResizeObserver(callback);

      observer.observe(target.current, options);

      return () => {
        observer.disconnect();
      };
    }
  }, []);
};
