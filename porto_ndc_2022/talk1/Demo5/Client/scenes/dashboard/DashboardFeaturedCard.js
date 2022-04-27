import {
  Box,
  Card,
  CardContent,
  Link,
  Stack,
  Typography,
  useTheme,
} from '@mui/material';
import NextLink from 'next/link';
import {memo} from 'react';
import {graphql, useFragment} from 'react-relay';

import {MiniChart} from '@/components';
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
        fontSize: theme.typography.fontSizeMedium,
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
      fontSize: theme.typography.fontSizeMedium,
      fontWeight: theme.typography.fontWeightMedium,
      lineHeight: 1,
    })}
  >
    {formatPercent(value, options, locales)}
  </Typography>
);

const SmartChart = memo(function SmartChart({color, data}) {
  const theme = useTheme();

  return (
    <MiniChart
      color={findClosestAccessibleColor(
        color,
        theme.palette.background.default,
        3,
      )}
      data={data.map((item) => [item.price, item.epoch * 1000])}
    />
  );
});

export default memo(function DashboardFeaturedCard({fragmentRef}) {
  const asset = useFragment(
    graphql`
      fragment DashboardFeaturedCardFragment_asset on Asset {
        symbol
        color
        price {
          currency
          lastPrice
          change24Hour
          change(span: DAY) {
            history {
              nodes {
                epoch
                price
              }
            }
          }
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
        <Card variant="outlined">
          <CardContent>
            <Stack direction="row" gap={4}>
              <Symbol value={asset.symbol} color={asset.color} />
              <Price
                value={price.lastPrice}
                options={{currency: price.currency}}
              />
              <Change value={price.change24Hour} />
            </Stack>
          </CardContent>
          <Box>
            <SmartChart color={asset.color} data={price.change.history.nodes} />
          </Box>
        </Card>
      </Link>
    </NextLink>
  );
});
