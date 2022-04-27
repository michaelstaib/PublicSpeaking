import styled from '@emotion/styled';
import {memo} from 'react';

import {formatDateForSpan} from '@/utils';

import d3 from './d3';

const generateTicks = (data, ticks) => {
  if (data.length < 2 || ticks < 2) {
    return null;
  }

  const [minTime, maxTime] = d3.extent(data, ([price, time]) => time);
  const rangeStep = (maxTime - minTime) / (ticks - 1);
  const generatedTicks = [];

  for (let i = 0; i < ticks; i += 1) {
    generatedTicks.push(minTime + i * rangeStep);
  }

  return generatedTicks;
};

const Root = styled.div(
  ({theme}) => `
  width: 100%;
  padding: ${theme.spacing(1, 2)};
  border-top: 1px solid ${theme.palette.line};
  border-bottom: 1px solid ${theme.palette.line};
  display: flex;
  justify-content: space-between;
  gap: ${theme.spacing(4)};
  text-transform: uppercase;
`,
);

const Tick = styled.div(
  ({theme}) => `
font-size: ${theme.typography.fontSizeTiny};
font-weight: ${theme.typography.fontWeightMedium};
text-align: center;
`,
);

export const HorizontalAxis = memo(function HorizontalAxis({
  data,
  span,
  ticks,
}) {
  return (
    <Root>
      {generateTicks(data, ticks)?.map((value) => (
        <Tick key={value}>{formatDateForSpan(value, span)}</Tick>
      ))}
    </Root>
  );
});
