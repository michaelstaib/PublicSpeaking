import styled from '@emotion/styled';

const Svg = styled.svg(
  ({theme}) => `
height: 100%;
width: 100%;
position: absolute;
top: 0;
left: 0;
transition: ${theme.transitions.create('opacity', {
    duration: theme.transitions.duration.short,
    easing: theme.transitions.easing.ease,
  })};
`,
);

const Circle = styled.circle(
  ({theme, color}) => `
  fill: ${color};
  stroke: ${theme.palette.background.paper};
  stroke-width: 2;
`,
);

export const Cursor = ({color, visible, x, y}) => (
  <Svg style={{opacity: visible ? 1 : 0}}>
    <Circle color={color} cx={x} cy={y} r={5} />
  </Svg>
);
