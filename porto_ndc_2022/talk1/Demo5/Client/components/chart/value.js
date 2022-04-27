import styled from '@emotion/styled';

const Root = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
`;

const Price = styled.div(
  ({theme}) => `
  font-size: ${theme.typography.fontSizeLarge};
  font-weight: ${theme.typography.fontWeightMedium};
`,
);

const Time = styled.div(
  ({theme}) => `
  font-size: ${theme.typography.fontSizeTiny};
  font-weight: ${theme.typography.fontWeightRegular};
  line-height: 1;
  opacity: 0.5;
`,
);

export const Value = ({price, date}) => (
  <Root>
    <Price>{price}</Price>
    <Time>{date}</Time>
  </Root>
);
