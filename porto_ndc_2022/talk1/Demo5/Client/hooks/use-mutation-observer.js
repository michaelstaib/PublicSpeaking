import {useIsomorphicEffect} from './use-isomorphic-effect';

/**
 * React effectful hook which invokes a specified callback when DOM events occur.
 * @see https://developer.mozilla.org/en-US/docs/Web/API/MutationObserver
 *
 * @param target A React ref created by `useRef()` and attached to a HTML element.
 * @param callback A function which will be called on each DOM change that qualifies given the observed node or subtree and options.
 * @param options An object providing options that describe which DOM mutations should be reported to mutationObserver’s callback. At a minimum, one of childList, attributes, and/or characterData must be true.
 *
 * @example
 * const MyComponent = ({children}) => {
 *   const targetRef = useRef(null);
 *
 *   useMutationObserver(
 *     targetRef,
 *     () => {
 *       console.log('number of children', targetRef.current.childElementCount);
 *     },
 *     {childList: true},
 *   );
 *
 *   return <div ref={targetRef}>{children}</div>
 * };
 */
export const useMutationObserver = (target, callback, options) => {
  useIsomorphicEffect(() => {
    if (target.current) {
      const observer = new MutationObserver(callback);

      observer.observe(target.current, options);

      return () => {
        observer.disconnect();
      };
    }
  }, []);
};
