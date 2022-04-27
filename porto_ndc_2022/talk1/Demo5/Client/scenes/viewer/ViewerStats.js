import styled from '@emotion/styled';
import {Box, LinearProgress, Stack, Tooltip, Typography} from '@mui/material';
import {memo} from 'react';
import {graphql, useFragment} from 'react-relay';

import {InfoIcon} from '@/icons';
import {formatPercent} from '@/utils';
import {
  formatCurrencyUsingCompactNotation,
  formatDecimalUnitUsingCompactNotation,
} from '@/utils';

const Block = styled.div(
  ({theme}) => `
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(150px, 1fr));
  column-gap: ${theme.spacing(2)};
  `,
);

const $dl = styled.dl(
  ({theme}) => `
  padding: ${theme.spacing(1, 2)};
  border-bottom: 1px solid ${theme.palette.line};
  margin-top: 0;
  margin-bottom: 0;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  gap: ${theme.spacing(1)};
`,
);

const $dt = styled.dt(
  ({theme}) => `
  display: flex;
  gap: ${theme.spacing(1)};
  font-size: ${theme.typography.fontSizeSmall};
  font-weight: ${theme.typography.fontWeightRegular};
`,
);

const $dd = styled.dd(
  ({theme, align = 'end'}) => `
  margin: 0;
  align-self: ${align};
  font-size: ${theme.typography.fontSizeMedium};
  font-weight: ${theme.typography.fontWeightMedium};
  line-height: 1;
`,
);

const InfoText = styled(Typography)(
  ({theme}) => `
  p {
    margin: 0;
  }

  p + p {
    margin-top: ${theme.spacing(3)};
  }
`,
);

const Info = ({children}) => (
  <Tooltip
    title={<InfoText variant="body2">{children}</InfoText>}
    arrow
    componentsProps={{
      tooltip: {
        sx: {
          maxWidth: 200,
          paddingY: 2,
          paddingX: 3,
          borderRadius: 2,
        },
      },
    }}
  >
    <InfoIcon fontSize="inherit" />
  </Tooltip>
);

const Meter = ({value}) => {
  const buy = value >= 0.5;
  const sell = !buy;
  const relative = buy ? value : 1 - value;
  const absolute = relative * 100;
  const percent = formatPercent(relative, {
    minimumFractionDigits: 0,
    signDisplay: 'never',
  });

  return (
    <Box sx={{display: 'flex', alignItems: 'center', gap: 2}}>
      {buy && <span>{percent} buy</span>}
      <LinearProgress
        variant="determinate"
        color="inherit"
        value={absolute}
        sx={{
          direction: 'rtl',
          flex: 1,
          color: buy ? 'trend.positive' : 'trend.negative',
          transform: sell && 'rotate(180deg)',
        }}
      />
      {sell && <span>{percent} sell</span>}
    </Box>
  );
};

export default memo(function ViewerStats({fragmentRef}) {
  const asset = useFragment(
    graphql`
      fragment ViewerStatsFragment_asset on Asset {
        price {
          currency
          marketCap
          volume24Hour
          volumePercentChange24Hour
          maxSupply
          circulatingSupply
          tradingActivity
          tradableMarketCapRank
        }
      }
    `,
    fragmentRef,
  );

  if (!asset?.price) {
    return null;
  }

  return (
    <Stack p={2}>
      <Typography variant="h3" gutterBottom>
        Market stats
      </Typography>
      <Block>
        <$dl>
          <$dt>
            Market Cap
            <Info>
              <p>
                The total market value of a cryptocurrency's circulating supply.
              </p>
              <p>Market Cap = Current Price x Circulating Supply.</p>
            </Info>
          </$dt>
          <$dd>
            {formatCurrencyUsingCompactNotation(asset.price.marketCap, {
              currency: asset.price.currency,
            })}
          </$dd>
        </$dl>
        <$dl>
          <$dt>
            Volume 24h
            <Info>
              <p>
                A measure of how much of a cryptocurrency was traded in the last
                24 hours.
              </p>
            </Info>
          </$dt>
          <$dd>
            {formatCurrencyUsingCompactNotation(asset.price.volume24Hour, {
              currency: asset.price.currency,
            })}
          </$dd>
        </$dl>
        <$dl>
          <$dt>
            Circulating Supply
            <Info>
              <p>
                The amount of coins that are circulating in the market and are
                in public hands. It is analogous to the flowing shares in the
                stock market.
              </p>
            </Info>
          </$dt>
          <$dd>
            {formatDecimalUnitUsingCompactNotation(
              asset.price.circulatingSupply,
            )}
          </$dd>
        </$dl>
        <$dl>
          <$dt>
            Max Supply
            <Info>
              <p>
                The maximum amount of coins that will ever exist in the lifetime
                of the cryptocurrency.
              </p>
            </Info>
          </$dt>
          <$dd>
            {formatDecimalUnitUsingCompactNotation(asset.price.maxSupply)}
          </$dd>
        </$dl>
        <$dl>
          <$dt>
            Trading activity
            <Info>
              <p>Market direction over the past 24 hours through trading.</p>
            </Info>
          </$dt>
          <$dd align="auto">
            <Meter value={asset.price.tradingActivity} />
          </$dd>
        </$dl>
        <$dl>
          <$dt>
            Popularity
            <Info>
              <p>
                Popularity is based on the relative market cap of tradable
                assets
              </p>
            </Info>
          </$dt>
          <$dd>#{asset.price.tradableMarketCapRank}</$dd>
        </$dl>
      </Block>
    </Stack>
  );
});
