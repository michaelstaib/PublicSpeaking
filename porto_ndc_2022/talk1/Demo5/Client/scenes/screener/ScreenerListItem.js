import {
  Checkbox,
  Link,
  Stack,
  TableCell,
  TableRow,
  Typography,
} from '@mui/material';
import NextLink from 'next/link';
import {memo, useCallback} from 'react';
import {graphql, useFragment, useMutation} from 'react-relay';

import {CryptoIcon, WatchIcon, WatchedIcon} from '@/icons';
import {
  direction,
  formatCurrency,
  formatCurrencyUsingCompactNotation,
  formatPercent,
} from '@/utils';

const useAddToWatchlist = () => {
  const [commit, isInFlight] = useMutation(graphql`
    mutation ScreenerListItemAATWMutation($input: AddAssetToWatchlistInput!) {
      addAssetToWatchlist(input: $input) {
        watchlist {
          assets {
            nodes {
              isInWatchlist
            }
          }
        }
      }
    }
  `);

  const execute = useCallback(
    ({id, symbol}) => {
      commit({
        variables: {input: {symbol}},
        optimisticUpdater(store) {
          const record = store.get(id);

          record.setValue(true, 'isInWatchlist');
        },
        onCompleted() {
          console.log(`${symbol} was added to the watchlist`);
        },
        onError() {
          console.log(
            `there was a problem with ${symbol} while adding to the watchlist`,
          );
        },
      });
    },
    [commit],
  );

  return [execute, isInFlight];
};

const useRemoveFromWatchlist = () => {
  const [commit, isInFlight] = useMutation(graphql`
    mutation ScreenerListItemRAFWMutation(
      $input: RemoveAssetFromWatchlistInput!
    ) {
      removeAssetFromWatchlist(input: $input) {
        removedAsset {
          isInWatchlist
        }
      }
    }
  `);

  const execute = useCallback(
    ({id, symbol}) => {
      commit({
        variables: {input: {symbol}},
        optimisticUpdater: (store) => {
          const record = store.get(id);

          record.setValue(false, 'isInWatchlist');
        },
        onCompleted: () => {
          console.log(`${symbol} was removed from the watchlist`);
        },
        onError: () => {
          console.log(
            `there was a problem with ${symbol} while removing from the watchlist`,
          );
        },
      });
    },
    [commit],
  );

  return [execute, isInFlight];
};

export default memo(function ScreenerListItem({fragmentRef, extended}) {
  const asset = useFragment(
    graphql`
      fragment ScreenerListItemFragment_asset on Asset {
        id
        symbol
        name
        imageUrl
        isInWatchlist
        price {
          currency
          lastPrice
          change24Hour
          marketCap
        }
      }
    `,
    fragmentRef,
  );
  const {price} = asset;

  const [addToWatchlist] = useAddToWatchlist();
  const [removeFromWatchlist] = useRemoveFromWatchlist();

  const labelId = `row:${asset.symbol}`;

  return (
    <TableRow
      key={asset.symbol}
      role="checkbox"
      aria-checked={!!asset.isInWatchlist}
      tabIndex={-1}
      hover
    >
      <TableCell component="th" scope="row" sx={{width: 'auto'}}>
        <NextLink
          href="/currencies/[symbol]"
          as={`/currencies/${asset.symbol}`}
          passHref
        >
          <Link underline="none">
            <Stack direction="row" alignItems="center" gap={2}>
              <CryptoIcon src={asset.imageUrl} alt={asset.name} size="medium" />
              <Stack direction="column">
                <Typography id={labelId} variant="caption">
                  {asset.name}
                </Typography>
                <Typography variant="caption" color="text.secondary">
                  {asset.symbol}
                </Typography>
              </Stack>
            </Stack>
          </Link>
        </NextLink>
      </TableCell>
      <TableCell
        align="right"
        sx={{width: 100, paddingLeft: 0, fontWeight: 600}}
      >
        {price && formatCurrency(price.lastPrice, {currency: price.currency})}
      </TableCell>
      <TableCell
        align="right"
        sx={(theme) => ({
          width: 70,
          paddingLeft: 0,
          color: theme.palette.trend[direction(price?.change24Hour)],
        })}
      >
        {price && formatPercent(price.change24Hour)}
      </TableCell>
      {extended && (
        <TableCell align="right" sx={{width: 70, paddingLeft: 0}}>
          {price &&
            formatCurrencyUsingCompactNotation(price.marketCap, {
              currency: price.currency,
            })}
        </TableCell>
      )}
      <TableCell align="right" sx={{width: 46, paddingLeft: 0}}>
        <Checkbox
          color="primary"
          icon={<WatchIcon />}
          checkedIcon={<WatchedIcon />}
          checked={!!asset.isInWatchlist}
          disabled={asset.isInWatchlist === null}
          size="small"
          inputProps={{
            'aria-labelledby': labelId,
          }}
          onChange={(event) => {
            if (event.target.checked) {
              addToWatchlist(asset);
            } else {
              removeFromWatchlist(asset);
            }
          }}
        />
      </TableCell>
    </TableRow>
  );
});
