import styled from '@emotion/styled';
import {memo, useEffect, useRef, useState} from 'react';

import d3 from './d3';

const Svg = styled.svg`
  height: 100%;
  width: 100%;

  .line {
    fill: none;
    pointer-events: none;
    stroke-width: 2;
  }
`;

const scaleData = (height, width, offset, data) => {
  const scalePriceToY = d3
    .scaleLinear()
    .range([height - offset, offset])
    .domain(d3.extent(data, ([price, time]) => price));

  const scaleTimeToX = d3
    .scaleTime()
    .range([0, width])
    .domain(d3.extent(data, ([price, time]) => time));

  return data.map(([price, time]) => [
    scalePriceToY(price),
    scaleTimeToX(time),
  ]);
};

export const Graph = memo(function Graph({height, width, offset, color, data}) {
  const [[previous, current], setScaledData] = useState(() => [null, null]);
  const svgRef = useRef();

  useEffect(() => {
    if (height && width) {
      const next = scaleData(height, width, offset, data);
      const initial = current ?? next.map(([price, time]) => [height, time]);

      setScaledData([initial, next]);
    }
  }, [height, width, offset, data]);

  useEffect(() => {
    if (previous && current) {
      const graph = d3.select(svgRef.current);
      const line = d3
        .line()
        .x(([price, time]) => time)
        .y(([price, time]) => price);
      const previousLineGraph = line(previous);
      const currentLineGraph = line(current);

      graph.selectAll('path').remove();

      graph
        .append('path')
        .attr('class', 'line')
        .style('stroke', color)
        .transition()
        .duration(500)
        .ease(d3.easeCubicOut)
        .attrTween(
          'd',
          d3.interpolatePath.bind(null, previousLineGraph, currentLineGraph),
        );
    }
  }, [previous, current]);

  return (
    <Svg>
      <g ref={svgRef} />
    </Svg>
  );
});
