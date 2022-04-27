import styled from '@emotion/styled';
import {memo} from 'react';

import {direction, formatPercent} from '@/utils';

const Root = styled.div(
  ({theme, trend}) => `
font-size: 1.125rem;
font-weight: 400;
color: ${theme.palette.trend[trend]};
`,
);

export const Change = memo(function Change({value, options, locales}) {
  return (
    <Root trend={direction(value)}>
      {formatPercent(value, options, locales)}
    </Root>
  );
});
