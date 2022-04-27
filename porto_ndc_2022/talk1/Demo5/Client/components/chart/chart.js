import styled from '@emotion/styled';
import {memo} from 'react';

import {useSize} from '@/hooks';
import {clamp} from '@/utils';

import {Graph} from './graph';
import {HorizontalAxis} from './horizontal-axis';
import {Indicator} from './indicator';

const calculateTicks = (width, size = 100, min = 3, max = 6) =>
  clamp(Math.floor(width / size), min, max);

const Pane = styled.div`
  height: 208px;
  width: 100%;
  position: relative;
`;

export const Chart = memo(function Chart({color, data, currency, span}) {
  const [paneRef, size] = useSize();

  return (
    <>
      <Pane ref={paneRef}>
        {size && (
          <Graph
            height={size.height}
            width={size.width}
            offset={6}
            color={color}
            data={data}
          />
        )}
        {size && (
          <Indicator
            height={size.height}
            width={size.width}
            offset={6}
            color={color}
            data={data}
            currency={currency}
          />
        )}
      </Pane>
      {size && (
        <HorizontalAxis
          data={data}
          span={span}
          ticks={calculateTicks(size.width)}
        />
      )}
    </>
  );
});
