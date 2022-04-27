import styled from '@emotion/styled';
import {memo} from 'react';

import {formatCurrency, formatCurrencyToParts} from '@/utils';

const Root = styled.div`
  display: flex;
  flex-direction: row;
  font-size: 3rem;
  user-select: none;
`;

const Currency = styled.span`
  position: relative;
  vertical-align: baseline;
  font-size: 0.675em;
`;

const Integer = styled.span`
  display: flex;
  flex-direction: row;
  font-size: 1em;
  letter-spacing: -2px;
  line-height: 1;
  height: 1em;
  overflow: hidden;
`;

const Group = styled.span`
  font-size: 1em;
  line-height: 1;
`;

const Decimal = styled.span`
  font-size: 0.675em;
  line-height: 1;
`;

const Fraction = styled.span`
  display: flex;
  flex-direction: row;
  font-size: 0.675em;
  letter-spacing: -2px;
  line-height: 1;
  height: 1em;
  overflow: hidden;
`;

const Reel = styled.div`
  display: flex;
  flex-direction: column;
  height: 1em;
  text-align: center;
  transition: margin 0.3s ease-in-out 0s;
`;

const digits = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

const Numbers = memo(function Numbers() {
  return digits.map((num) => <span key={num}>{num}</span>);
});

const Digits = memo(function Digits({value}) {
  const current = Array.from(String(value), Number);

  return current.map((item, index, {length}) => (
    <Reel
      key={length - index}
      style={{marginTop: `-${digits.indexOf(item)}em`}}
    >
      <Numbers />
    </Reel>
  ));
});

export const Price = memo(function Price({value, options, locales}) {
  const label = formatCurrency(value, options, locales);
  const content = formatCurrencyToParts(value, options, locales).map(
    ({type, value}, index) => {
      const key = `${type}:${index}`;

      switch (type) {
        case 'currency':
          return <Currency key={key}>{value}</Currency>;
        case 'integer':
          return (
            <Integer key={key}>
              <Digits value={value} />
            </Integer>
          );
        case 'group':
          return <Group key={key}>{value}</Group>;
        case 'decimal':
          return <Decimal key={key}>{value}</Decimal>;
        case 'fraction':
          return (
            <Fraction key={key}>
              <Digits value={value} />
            </Fraction>
          );
      }
    },
  );

  return (
    <Root aria-live="polite" aria-label={label}>
      {content}
    </Root>
  );
});
