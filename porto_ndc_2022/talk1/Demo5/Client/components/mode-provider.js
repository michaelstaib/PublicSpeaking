import {createContext} from 'react';

import {noop} from '@/utils';

export const ModeContext = createContext({
  mode: 'light',
  setModeLight: noop,
  setModeDark: noop,
  setModeAuto: noop,
  toggleMode: noop,
});

/**
 * @example
 * const ctx = {mode, setModeLight, setModeDark, setModeAuto, toggleMode};
 *
 * <ModeProvider value={ctx}>
 *   ...
 * </ModeProvider>
 */
export const ModeProvider = (props) => <ModeContext.Provider {...props} />;
