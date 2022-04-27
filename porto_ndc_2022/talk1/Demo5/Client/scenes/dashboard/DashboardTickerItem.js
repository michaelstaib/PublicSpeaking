import {Link, Stack, Typography} from '@mui/material';
import NextLink from 'next/link';
import {memo} from 'react';
import {graphql, useFragment} from 'react-relay';

import {
  direction,
  findClosestAccessibleColor,
  formatCurrency,
  formatPercent,
} from '@/utils';

const Symbol = memo(function Symbol({value, color}) {
  return (
    <Typography
      variant="caption"
      sx={(theme) => ({
        color: findClosestAccessibleColor(
          color,
          theme.palette.background.default,
          3,
        ),
        fontSize: theme.typography.fontSizeTiny,
        fontWeight: theme.typography.fontWeightMedium,
        lineHeight: 1,
      })}
    >
      {value}
    </Typography>
  );
});

const Price = ({value, options, locales}) => (
  <Typography
    variant="caption"
    sx={(theme) => ({
      color: theme.palette.text.primary,
      fontSize: theme.typography.fontSizeMedium,
      fontWeight: theme.typography.fontWeightMedium,
      lineHeight: 1,
    })}
  >
    {formatCurrency(value, options, locales)}
  </Typography>
);

const Change = ({value, options, locales}) => (
  <Typography
    variant="caption"
    sx={(theme) => ({
      color: theme.palette.trend[direction(value)],
      fontSize: theme.typography.fontSizeTiny,
      fontWeight: theme.typography.fontWeightMedium,
      lineHeight: 1,
    })}
  >
    {formatPercent(value, options, locales)}
  </Typography>
);

export default memo(function DashboardTickerItem({fragmentRef}) {
  const asset = useFragment(
    graphql`
      fragment DashboardTickerItemFragment_asset on Asset {
        symbol
        color
        price {
          currency
          lastPrice
          change24Hour
        }
      }
    `,
    fragmentRef,
  );
  const {price} = asset;

  return (
    <NextLink
      href="/currencies/[symbol]"
      as={`/currencies/${asset.symbol}`}
      passHref
    >
      <Link underline="none">
        <Stack direction="column" spacing={1} minWidth={100}>
          <Symbol value={asset.symbol} color={asset.color} />
          <Price value={price.lastPrice} options={{currency: price.currency}} />
          <Change value={price.change24Hour} />
        </Stack>
      </Link>
    </NextLink>
  );
});
