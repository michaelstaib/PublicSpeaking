import {useMediaQuery} from '@mui/material';
import {useCallback, useEffect, useMemo, useState} from 'react';

import {Config, syncWithStorage} from '@/config';
import {createTheme} from '@/styles';

export const usePreferredTheme = (initial) => {
  const prefersDarkMode = useMediaQuery('(prefers-color-scheme: dark)');
  const [mode, setMode] = useState(
    () => initial ?? (prefersDarkMode ? 'dark' : 'light'),
  );
  const theme = useMemo(() => createTheme(mode), [mode]);

  useEffect(() => {
    if (initial === undefined) {
      const stored = Config.MODE;

      if (stored && mode !== stored) {
        setMode(stored);
      }
    }
  }, []);

  useEffect(() => {
    syncWithStorage({MODE: mode});
  }, [mode]);

  const setModeLight = useCallback(() => {
    setMode('light');
  }, []);
  const setModeDark = useCallback(() => {
    setMode('dark');
  }, []);
  const setModeAuto = useCallback(() => {
    setMode(prefersDarkMode ? 'dark' : 'light');
  }, [prefersDarkMode]);
  const toggleMode = useCallback(() => {
    setMode((previous) => (previous === 'light' ? 'dark' : 'light'));
  }, []);

  return [theme, {mode, setModeLight, setModeDark, setModeAuto, toggleMode}];
};
