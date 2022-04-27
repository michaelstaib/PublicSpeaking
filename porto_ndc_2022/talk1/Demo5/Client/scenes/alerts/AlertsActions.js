import {
  Box,
  Checkbox,
  FormControlLabel,
  IconButton,
  Stack,
  Table,
  TableBody,
  TableCell,
  TableRow,
  TextField,
} from '@mui/material';
import {useCallback, useState} from 'react';
import {graphql, useFragment, useMutation} from 'react-relay';

import {BusyButton, NoData, PercentageSlider} from '@/components';
import {CancelIcon} from '@/icons';
import {formatCurrency, inequality, round} from '@/utils';

const useCreateAlert = () => {
  const [commit, isInFlight] = useMutation(graphql`
    mutation AlertsActionsCAMutation($input: CreateAlertInput!) {
      createAlert(input: $input) {
        createdAlert {
          asset {
            hasAlerts
            alerts {
              nodes {
                id
                currency
                targetPrice
                percentageChange
                recurring
              }
            }
          }
        }
      }
    }
  `);

  const execute = useCallback(
    ({symbol, currency, targetPrice, recurring}) => {
      commit({
        variables: {input: {symbol, currency, targetPrice, recurring}},
        onCompleted() {
          console.log(`alert created for ${symbol}`);
        },
        onError() {
          console.log(
            `there was a problem while creating an alert for ${symbol}`,
          );
        },
      });
    },
    [commit],
  );

  return [execute, isInFlight];
};

export const AddAlert = ({fragmentRef, symbol}) => {
  const asset = useFragment(
    graphql`
      fragment AlertsActionsAAFragment_asset on Asset {
        price {
          currency
          lastPrice
        }
      }
    `,
    fragmentRef,
  );
  const {currency, lastPrice} = asset.price;

  const [createAlert, isInFlight] = useCreateAlert();

  const [state, setState] = useState(() => ({
    symbol,
    currency,
    targetPrice: lastPrice,
    percentage: 0,
    recurring: false,
  }));

  const handleChange = useCallback((e) => {
    const {name, value, checked} = e.target;

    switch (name) {
      case 'percentage':
        setState((prev) => ({
          ...prev,
          percentage: value,
          targetPrice:
            value === 0 ? lastPrice : round(lastPrice * (1 + value / 100), 2),
        }));
        break;
      case 'price':
        setState((prev) => ({
          ...prev,
          percentage: (Math.max(Number(value), 0) / lastPrice - 1) * 100,
          targetPrice: Math.max(Number(value), 0),
        }));
        break;
      case 'recurring':
        setState((prev) => ({...prev, recurring: checked}));
        break;
    }
  }, []);

  return (
    <form
      onSubmit={(e) => {
        e.preventDefault();

        createAlert(state);
      }}
    >
      <Stack gap={6}>
        <Box sx={{mt: 12, mx: 8}}>
          <PercentageSlider
            name="percentage"
            value={state.percentage}
            min={-25}
            max={+25}
            step={1}
            onChange={handleChange}
          />
        </Box>
        <TextField
          type="number"
          name="price"
          label="Target price"
          value={state.targetPrice}
          autoComplete="off"
          onChange={handleChange}
          sx={{width: 150, margin: 'auto'}}
        />
        <FormControlLabel
          label="Recurring"
          labelPlacement="end"
          control={
            <Checkbox
              name="recurring"
              checked={state.recurring}
              onChange={handleChange}
            />
          }
          sx={{margin: 'auto'}}
        />
        <Stack direction="row" justifyContent="end">
          <BusyButton type="submit" color="primary" busy={isInFlight}>
            save
          </BusyButton>
        </Stack>
      </Stack>
    </form>
  );
};

const useDeleteAlert = () => {
  const [commit, isInFlight] = useMutation(graphql`
    mutation AlertsActionsDAMutation($input: DeleteAlertInput!) {
      deleteAlert(input: $input) {
        deletedAlert {
          asset {
            hasAlerts
            alerts {
              nodes {
                id
                currency
                targetPrice
                percentageChange
                recurring
              }
            }
          }
        }
      }
    }
  `);

  const execute = useCallback(
    ({id, symbol}) => {
      commit({
        variables: {input: {alertId: id}},
        onCompleted() {
          console.log(`alert deleted for ${symbol}`);
        },
        onError() {
          console.log(
            `there was a problem while deleting an alert for ${symbol}`,
          );
        },
      });
    },
    [commit],
  );

  return [execute, isInFlight];
};

export const DeleteAlert = ({fragmentRef, symbol}) => {
  const asset = useFragment(
    graphql`
      fragment AlertsActionsDAFragment_asset on Asset {
        hasAlerts
        alerts {
          nodes {
            id
            currency
            targetPrice
            percentageChange
            recurring
          }
        }
      }
    `,
    fragmentRef,
  );
  const alerts = asset.alerts?.nodes;

  const [deleteAlert] = useDeleteAlert();

  return alerts?.length ? (
    <Table size="medium">
      <TableBody>
        {alerts.map((node) => (
          <TableRow key={node.id} tabIndex={-1} hover>
            <TableCell>1 {symbol}</TableCell>
            <TableCell align="center">
              {inequality(node.percentageChange)}
            </TableCell>
            <TableCell align="right" sx={{width: 'auto', fontWeight: 600}}>
              {formatCurrency(node.targetPrice, {currency: node.currency})}
            </TableCell>
            <TableCell align="right" sx={{width: 46, paddingLeft: 0}}>
              <IconButton
                size="small"
                aria-label="remove alert"
                onClick={() => {
                  deleteAlert({id: node.id, symbol});
                }}
              >
                <CancelIcon />
              </IconButton>
            </TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  ) : (
    <NoData />
  );
};
