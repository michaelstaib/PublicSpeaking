import styled from '@emotion/styled';
import {memo} from 'react';

import {useSize} from '@/hooks';

import {Graph} from './graph';

const Pane = styled.div`
  height: 100%;
  width: 100%;
`;

export const MiniChart = memo(function Chart({color, data}) {
  const [paneRef, size] = useSize();

  return (
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
    </Pane>
  );
});
