import styled from '@emotion/styled';
import {memo, useCallback, useEffect, useRef, useState} from 'react';

import {formatCurrency, formatDateForSpan} from '@/utils';

import {Cursor} from './cursor';
import d3 from './d3';
import {Tooltip} from './tooltip';
import {Value} from './value';

const Root = styled.div`
  height: 100%;
  width: 100%;
  position: absolute;
  top: 0;
  left: 0;
  cursor: crosshair;
`;

export const Indicator = memo(function Indicator({
  height,
  width,
  offset,
  color,
  data,
  currency,
}) {
  const [state, setState] = useState(() => ({
    active: false,
    posX: -1,
    posY: -1,
    content: null,
  }));
  const rootRef = useRef();

  const handleEnd = useCallback(() => {
    setState((prev) => ({...prev, active: false}));
  }, []);
  const handleMove = useCallback(
    (e) => {
      const posX =
        (e.touches?.[0]?.clientX ?? e.clientX) -
        rootRef.current.getBoundingClientRect().left;

      setState((prev) => {
        const index = Math.round((posX / width) * (data.length - 1));
        const [price, time] = data[index] || [];

        const value = price && formatCurrency(price, {currency});
        const date = time && formatDateForSpan(time);

        const scalePriceToY = d3
          .scaleLinear()
          .range([height - offset, offset])
          .domain(d3.extent(data, ([price, time]) => price));
        const posY = price ? scalePriceToY(price) : prev.posY;

        const active = !!value;

        return {
          active,
          posX,
          posY,
          content: active && <Value price={value} date={date} />,
        };
      });
    },
    [height, width, offset, data, currency],
  );

  useEffect(handleEnd, [height, width]);

  return (
    <Root
      ref={rootRef}
      onMouseMove={handleMove}
      onMouseLeave={handleEnd}
      onTouchMove={handleMove}
      onTouchEnd={handleEnd}
    >
      <Cursor
        visible={state.active}
        color={color}
        x={state.posX}
        y={state.posY}
      />
      <Tooltip
        visible={state.active}
        width={width}
        x={state.posX}
        y={state.posY}
        offset={72}
        content={state.content}
      />
    </Root>
  );
});
