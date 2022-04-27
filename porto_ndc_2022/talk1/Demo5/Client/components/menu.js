import {
  Avatar,
  List,
  ListItem,
  ListItemAvatar,
  ListItemButton,
  ListItemText,
} from '@mui/material';
import {useRouter} from 'next/router';

import {
  DashboardIcon,
  ScreenerIcon,
  SettingsIcon,
  WatchlistIcon,
} from '@/icons';

import {Drawer} from './drawer';

const entries = [
  ['/dashboard', DashboardIcon, 'Dashboard', "Get a feel for what's moving."],
  ['/screener', ScreenerIcon, 'Screener', 'Look first, then leap.'],
  ['/watchlist', WatchlistIcon, 'Watchlist', 'Track your favorite assets.'],
  ['/settings', SettingsIcon, 'Settings', 'Customize your experience.'],
];

export const Menu = ({active, close}) => {
  const router = useRouter();

  return (
    <Drawer open={active} onClose={close}>
      <List>
        {entries.map(([route, Icon, primary, secondary]) => (
          <ListItem key={route}>
            <ListItemButton
              disabled={route === router.pathname}
              onClick={() => {
                router.push(route);
                close();
              }}
            >
              <ListItemAvatar>
                <Avatar>
                  <Icon color="action" />
                </Avatar>
              </ListItemAvatar>
              <ListItemText primary={primary} secondary={secondary} />
            </ListItemButton>
          </ListItem>
        ))}
      </List>
    </Drawer>
  );
};
