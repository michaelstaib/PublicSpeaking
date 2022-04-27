import {Stack, useTheme} from '@mui/material';
import {memo, useCallback, useMemo, useState, useTransition} from 'react';
import {
  graphql,
  useFragment,
  useRefetchableFragment,
  useSubscription,
} from 'react-relay';

import {Change, Chart, Price, SpanSelector} from '@/components';
import {findClosestAccessibleColor} from '@/utils';

const SmartChart = memo(function SmartChart({color, currency, span, data}) {
  const theme = useTheme();

  return (
    <Chart
      color={findClosestAccessibleColor(
        color,
        theme.palette.background.default,
        3,
      )}
      currency={currency}
      span={span}
      data={data.map((item) => [item.price, item.epoch * 1000])}
    />
  );
});

export default memo(function ViewerSnapshot({fragmentRef}) {
  const asset = useFragment(
    graphql`
      fragment ViewerSnapshotFragment_asset on Asset {
        symbol
        color
        price {
          ...ViewerSnapshotFragment_price
        }
      }
    `,
    fragmentRef,
  );
  const [price, refetch] = useRefetchableFragment(
    graphql`
      fragment ViewerSnapshotFragment_price on AssetPrice
      @argumentDefinitions(span: {type: "ChangeSpan", defaultValue: DAY})
      @refetchable(queryName: "ViewerSnapshotRefetchableQuery") {
        currency
        lastPrice
        change(span: $span) {
          percentageChange
          history {
            nodes {
              epoch
              price
            }
          }
        }
      }
    `,
    asset.price,
  );

  const [span, setSpan] = useState('DAY');
  const [busy, startTransition] = useTransition();

  const handleSpanChange = useCallback((e, value) => {
    startTransition(() => {
      setSpan(value);
      refetch({span: value});
    });
  }, []);

  useSubscription(
    useMemo(
      () => ({
        subscription: graphql`
          subscription ViewerSnapshotSubscription(
            $symbol: String!
            $span: ChangeSpan!
          ) {
            onPriceChange(symbols: [$symbol]) {
              lastPrice
              change(span: $span) {
                percentageChange
              }
            }
          }
        `,
        variables: {symbol: asset.symbol, span},
      }),
      [asset.symbol, span],
    ),
  );

  return (
    <Stack justifyContent="center" alignItems="center" gap={2}>
      <Stack direction="row" gap={2}>
        <Price value={price.lastPrice} options={{currency: price.currency}} />
        <Change value={price.change.percentageChange} />
      </Stack>
      <SpanSelector span={span} busy={busy} onChange={handleSpanChange} />
      <SmartChart
        color={asset.color}
        currency={price.currency}
        span={span}
        data={price.change.history.nodes}
      />
    </Stack>
  );
});
