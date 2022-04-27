import {createContext, useRef} from 'react';

export const SlotsContext = createContext({
  menubar: {current: null},
  statusbar: {current: null},
});

/**
 * @example
 * <SlotsProvider>
 *   ...
 * </SlotsProvider>
 */
export const SlotsProvider = (props) => {
  const menubar = useRef(null);
  const statusbar = useRef(null);

  return <SlotsContext.Provider value={{menubar, statusbar}} {...props} />;
};
