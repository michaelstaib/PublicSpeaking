import styled from '@emotion/styled';
import {Paper} from '@mui/material';

const $Paper = styled(Paper)(
  ({theme}) => `
  padding: ${theme.spacing(2, 3)};
  margin: ${theme.spacing(0, 2)};
  position: absolute;
  transition: ${theme.transitions.create('opacity', {
    duration: theme.transitions.duration.short,
    easing: theme.transitions.easing.ease,
  })};
  background-color: ${theme.palette.float.main};
  color: ${theme.palette.float.contrastText};
  z-index: 10;
`,
);

export const Tooltip = ({visible, width, x, y, offset, content}) => (
  <$Paper
    style={{
      top: y - offset,
      left: x <= width / 2 && Math.max(x - offset, 0),
      right: x > width / 2 && Math.max(width - x - offset, 0),
      opacity: visible ? 1 : 0,
      visibility: visible ? 'visible' : 'hidden',
    }}
  >
    {content}
  </$Paper>
);
