import {useEffect, useLayoutEffect} from 'react';

/**
 * Resolves to `useEffect` when "window" is not in scope and `useLayoutEffect` in the browser.
 */
export const useIsomorphicEffect =
  typeof window === 'undefined' ? useEffect : useLayoutEffect;
