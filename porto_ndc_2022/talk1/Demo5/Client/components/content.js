import styled from '@emotion/styled';
import {Divider, Fade, IconButton, Stack, Tooltip, alpha} from '@mui/material';
import {useRouter} from 'next/router';
import {useState} from 'react';

import {useMode, useMutationObserver, useSlots} from '@/hooks';
import {
  AppIcon,
  BitcoinIcon,
  CardanoIcon,
  CloseIcon,
  CommandIcon,
  DarkModeIcon,
  DashboardIcon,
  EthereumClassicIcon,
  LightModeIcon,
  MenuIcon,
  ScreenerIcon,
  WatchlistIcon,
} from '@/icons';

import {ErrorBoundary} from './error-boundary';
import {Menu} from './menu';
import {NoSSR} from './no-ssr';

const favorites = [
  ['BTC', BitcoinIcon, 'Bitcoin'],
  ['ETC', EthereumClassicIcon, 'Ethereum Classic'],
  ['ADA', CardanoIcon, 'Cardano'],
];

const Root = styled.div`
  height: 100vh;
  width: 100%;
  min-width: 375px;
  max-width: 600px;
  position: relative;
  display: flex;
  flex-direction: column;
  overflow: hidden;
  box-shadow: 1px 0 0 0 #4a4c50, 0 0 0 100vw #292a2d;
`;

const Menubar = styled(Stack)(
  ({theme}) => `
  height: ${theme.spacing(6.5)};
  padding: ${theme.spacing(1)};
  flex-direction: row;
  align-items: center;
  overflow: hidden;
`,
);

const Statusbar = styled(Stack)(
  ({theme}) => `
  height: ${theme.spacing(6.5)};
  padding: ${theme.spacing(1)};
  flex-direction: row;
  align-items: center;
  overflow: hidden;
`,
);

const Controlbar = styled(Stack)`
  flex-direction: row;
  align-items: center;
  margin-left: auto;
`;

const Main = styled.div(
  ({theme}) => `
  padding: ${theme.spacing(3)};
  flex: 1;
  display: flex;
  flex-direction: column;
  position: relative;
  overflow: scroll;

  & > div[style] {
    color: inherit !important;
    background: inherit !important;

    & h1[style] {
      border-right: 1px solid ${alpha(
        theme.palette.text.primary,
        0.3,
      )} !important;
    }
  }
`,
);

export const Content = ({variant = 'unknown', children}) => {
  const router = useRouter();
  const {mode, toggleMode} = useMode();
  const {menubar: menubarRef, statusbar: statusbarRef} = useSlots();
  const [command, setCommand] = useState(0);
  const [menu, setMenu] = useState(false);

  useMutationObserver(
    statusbarRef,
    () => {
      setCommand((previous) => {
        const current = Math.sign(statusbarRef.current?.childElementCount ?? 0);

        return current === previous ? previous : current;
      });
    },
    {childList: true},
  );

  if (variant === 'unknown') {
    return (
      <Root>
        <Main>
          <NoSSR>
            <ErrorBoundary>{children}</ErrorBoundary>
          </NoSSR>
        </Main>
      </Root>
    );
  }

  return (
    <Root>
      <Menu
        active={menu}
        close={() => {
          setMenu(false);
        }}
      />
      <Menubar>
        <IconButton
          size="small"
          disableRipple
          onClick={() => {
            router.push('/');
          }}
        >
          <AppIcon fontSize="small" />
        </IconButton>
        <Controlbar ref={menubarRef} />
        <Tooltip title="Mode">
          <IconButton aria-label="mode" size="small" onClick={toggleMode}>
            {mode === 'light' ? (
              <DarkModeIcon fontSize="inherit" />
            ) : (
              <LightModeIcon fontSize="inherit" />
            )}
          </IconButton>
        </Tooltip>
        <Tooltip title="Menu">
          <IconButton
            aria-label="menu"
            size="small"
            onClick={() => {
              setMenu(true);
            }}
          >
            <MenuIcon fontSize="inherit" />
          </IconButton>
        </Tooltip>
      </Menubar>
      <Divider />
      <Main>
        <NoSSR>
          <ErrorBoundary>{children}</ErrorBoundary>
        </NoSSR>
      </Main>
      <Divider />
      <Statusbar>
        <Tooltip title="Dashboard">
          <IconButton
            aria-label="dashboard"
            size="small"
            onClick={() => {
              router.push('/dashboard');
            }}
          >
            <DashboardIcon fontSize="inherit" />
          </IconButton>
        </Tooltip>
        <Tooltip title="Screener">
          <IconButton
            aria-label="screener"
            size="small"
            onClick={() => {
              router.push('/screener');
            }}
          >
            <ScreenerIcon fontSize="inherit" />
          </IconButton>
        </Tooltip>
        <Tooltip title="Watchlist">
          <IconButton
            aria-label="watchlist"
            size="small"
            onClick={() => {
              router.push('/watchlist');
            }}
          >
            <WatchlistIcon fontSize="inherit" />
          </IconButton>
        </Tooltip>
        {favorites.map(([symbol, Icon, title]) => (
          <Tooltip key={symbol} title={title}>
            <IconButton
              aria-label={title}
              size="small"
              onClick={() => {
                router.push(`/currencies/${symbol}`);
              }}
            >
              <Icon fontSize="inherit" />
            </IconButton>
          </Tooltip>
        ))}
        <Fade in={command < 0}>
          <Controlbar ref={statusbarRef} />
        </Fade>
        <Tooltip title="Command">
          <span>
            <IconButton
              aria-label="command"
              size="small"
              disabled={!command}
              onClick={() => {
                setCommand((previous) => previous * -1);
              }}
            >
              {command < 0 ? (
                <CloseIcon fontSize="inherit" />
              ) : (
                <CommandIcon fontSize="inherit" />
              )}
            </IconButton>
          </span>
        </Tooltip>
      </Statusbar>
    </Root>
  );
};
