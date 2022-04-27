import {keyframes} from '@emotion/css';
import styled from '@emotion/styled';
import {Divider, Stack, alpha} from '@mui/material';

import {useToggle} from '@/hooks';

const $Stack = styled(Stack)(
  ({theme}) => `
  width: 100%;
  position: relative;
  overflow: hidden;

  :before {
    content: '';
    height: 100%;
    width: 50px;
    position: absolute;
    top: 0;
    left: 0;
    z-index: 1;
    background-image: linear-gradient(to left, ${alpha(
      theme.palette.background.default,
      0,
    )}, ${theme.palette.background.default});
  }
  :after {
    content: '';
    height: 100%;
    width: 50px;
    position: absolute;
    top: 0;
    right: 0;
    z-index: 1;
    background-image: linear-gradient(to right, ${alpha(
      theme.palette.background.default,
      0,
    )}, ${theme.palette.background.default});
  }
`,
);

const ticker = keyframes`
0% {
  transform: translate3d(0, 0, 0);
}
100% {
  transform: translate3d(-50%, 0, 0);
}
`;

export const Ticker = ({children, ...rest}) => {
  const [paused, toggle] = useToggle(false);

  return (
    <$Stack
      direction="row"
      alignItems="center"
      onMouseEnter={toggle}
      onMouseLeave={toggle}
      onTouchStart={toggle}
      onTouchEnd={toggle}
      {...rest}
    >
      <Stack
        direction="row"
        alignItems="center"
        spacing={3}
        divider={<Divider orientation="vertical" variant="middle" flexItem />}
        sx={{
          width: 'max-content',
          animation: `${ticker} 30s linear infinite`,
        }}
        style={{animationPlayState: paused && 'paused'}}
        {...rest}
      >
        <Divider orientation="vertical" variant="middle" flexItem />
        {children}
        {children}
      </Stack>
    </$Stack>
  );
};
