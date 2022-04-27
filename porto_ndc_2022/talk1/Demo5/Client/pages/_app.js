import {CacheProvider} from '@emotion/react';
import {CssBaseline, ThemeProvider} from '@mui/material';
import {useEffect} from 'react';
import {RelayEnvironmentProvider} from 'react-relay';

import {useEnvironment} from '@/client';
import {
  Content,
  Hacks,
  Metadata,
  ModeProvider,
  SlotsProvider,
} from '@/components';
import {usePreferredTheme} from '@/hooks';
import {Notifications} from '@/scenes';
import {createEmotionCache} from '@/styles';

const clientSideEmotionCache = createEmotionCache();

export default function MyApp({
  Component,
  emotionCache = clientSideEmotionCache,
  pageProps,
}) {
  const environment = useEnvironment(pageProps.initialRecords);
  const [theme, mode] = usePreferredTheme();

  useEffect(() => {
    if ('serviceWorker' in navigator) {
      navigator.serviceWorker.register('/sw.js');
    }
  }, []);

  return (
    <RelayEnvironmentProvider environment={environment}>
      <CacheProvider value={emotionCache}>
        <ThemeProvider theme={theme}>
          <ModeProvider value={mode}>
            <Metadata />
            <CssBaseline enableColorScheme />
            <SlotsProvider>
              <Content variant="crypto">
                <Notifications />
                <Component {...pageProps} />
              </Content>
            </SlotsProvider>
            <Hacks />
          </ModeProvider>
        </ThemeProvider>
      </CacheProvider>
    </RelayEnvironmentProvider>
  );
}
