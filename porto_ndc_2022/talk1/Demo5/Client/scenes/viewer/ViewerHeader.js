import {Checkbox, Chip, Stack, Typography} from '@mui/material';
import {memo, useCallback} from 'react';
import {graphql, useFragment, useMutation} from 'react-relay';

import {useAlerts} from '@/hooks';
import {
  AlertActiveIcon,
  AlertIcon,
  CryptoIcon,
  WatchIcon,
  WatchedIcon,
} from '@/icons';

const useAddToWatchlist = () => {
  const [commit, isInFlight] = useMutation(graphql`
    mutation ViewerHeaderAATWMutation($input: AddAssetToWatchlistInput!) {
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
    mutation ViewerHeaderRAFWMutation($input: RemoveAssetFromWatchlistInput!) {
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

export default memo(function ViewerHeader({fragmentRef}) {
  const asset = useFragment(
    graphql`
      fragment ViewerHeaderFragment_asset on Asset {
        id
        symbol
        name
        imageUrl
        isInWatchlist
        hasAlerts
      }
    `,
    fragmentRef,
  );

  const [addToWatchlist] = useAddToWatchlist();
  const [removeFromWatchlist] = useRemoveFromWatchlist();

  const {active, show} = useAlerts();

  return (
    <Stack direction="row" alignItems="center" gap={2} mb={4}>
      <Stack
        direction="row"
        alignItems="center"
        gap={2}
        marginLeft={2}
        marginRight="auto"
      >
        <CryptoIcon src={asset.imageUrl} alt={asset.name} size="large" />
        <Typography variant="h2" fontWeight={600}>
          {asset.name}
        </Typography>
        <Chip
          label={asset.symbol}
          size="small"
          sx={(theme) => ({
            borderRadius: theme.spacing(2),
          })}
        />
      </Stack>
      <Stack direction="row">
        <Checkbox
          color="primary"
          icon={<AlertIcon />}
          checkedIcon={asset.hasAlerts ? <AlertActiveIcon /> : <AlertIcon />}
          checked={asset.hasAlerts || active}
          disabled={asset.isInWatchlist === null}
          inputProps={{
            'aria-label': 'alert',
          }}
          onChange={(event) => {
            event.preventDefault();

            show();
          }}
        />
        <Checkbox
          color="primary"
          icon={<WatchIcon />}
          checkedIcon={<WatchedIcon />}
          checked={!!asset.isInWatchlist}
          disabled={asset.isInWatchlist === null}
          inputProps={{
            'aria-label': 'watch',
          }}
          onChange={(event) => {
            if (event.target.checked) {
              addToWatchlist(asset);
            } else {
              removeFromWatchlist(asset);
            }
          }}
        />
      </Stack>
    </Stack>
  );
});
