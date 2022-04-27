import {useEffect, useState} from 'react';

/**
 * React hook that tracks the component's mounted status.
 *
 * @example
 * const ClientOnly = ({children}) => {
 *   const hasMounted = useHasMounted();
 *
 *   if (!hasMounted) return null;
 *
 *   return children;
 * };
 */
export const useHasMounted = () => {
  const [hasMounted, setHasMounted] = useState(false);

  useEffect(() => {
    setHasMounted(true);
  }, []);

  return hasMounted;
};
