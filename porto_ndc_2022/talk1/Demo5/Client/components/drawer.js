import styled from '@emotion/styled';
import {SwipeableDrawer} from '@mui/material';

import {noop} from '@/utils';

const $SwipeableDrawer = styled(SwipeableDrawer)(
  ({theme}) => `
  width: 100%;
  min-width: 375px;
  max-width: 600px;

  .MuiBackdrop-root {
    position: absolute;
  }

  .MuiDrawer-paper {
    width: 100%;
    max-height: 80%;

    position: absolute;
    overflow: hidden;
  }

  .MuiDrawer-paperAnchorTop {
    border-bottom-left-radius: ${theme.spacing(2)};
    border-bottom-right-radius: ${theme.spacing(2)};
  }

  .MuiDrawer-paperAnchorBottom {
    border-top-left-radius: ${theme.spacing(2)};
    border-top-right-radius: ${theme.spacing(2)};
  }
`,
);

const Pusher = styled.div(
  ({theme, anchor}) => `
  width: 30px;
  min-height: 6px;
  margin: ${theme.spacing(2)};
  border-radius: 3px;
  background-color: ${theme.palette.divider};
  align-self: center;
  cursor: ${anchor === 'top' ? 'n-resize' : 's-resize'};
`,
);

const Scrollable = styled.div`
  flex: 1;
  display: flex;
  flex-direction: column;
  overflow-y: auto;
  overflow-x: hidden;
`;

export const Drawer = ({open = true, anchor = 'top', children, ...rest}) => (
  <$SwipeableDrawer
    anchor={anchor}
    open={open}
    disableSwipeToOpen
    onOpen={noop}
    onClose={noop}
    {...rest}
  >
    {anchor === 'bottom' && <Pusher anchor={anchor} onClick={rest.onClose} />}
    <Scrollable>{children}</Scrollable>
    {anchor === 'top' && <Pusher anchor={anchor} onClick={rest.onClose} />}
  </$SwipeableDrawer>
);
