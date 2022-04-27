import {
  Divider,
  InputAdornment,
  Stack,
  Table,
  TableBody,
  TableCell,
  TableFooter,
  TableRow,
  TextField,
} from '@mui/material';
import {
  memo,
  useDeferredValue,
  useEffect,
  useRef,
  useState,
  useTransition,
} from 'react';
import {graphql, usePaginationFragment} from 'react-relay';

import {
  LoadMoreButton,
  NoData,
  SortButton,
  TransitionIndicator,
} from '@/components';
import {useSize} from '@/hooks';
import {SearchIcon} from '@/icons';

import ScreenerListItem from './ScreenerListItem';

const Order = [
  {
    title: 'Market cap ↓',
    expression: {price: {marketCap: 'DESC'}},
  },
  {
    title: 'Change 24H ↓',
    expression: {price: {change24Hour: 'DESC'}},
  },
  {
    title: 'Change 24H ↑',
    expression: {price: {change24Hour: 'ASC'}},
  },
  {
    title: 'Symbol ↑',
    expression: {symbol: 'ASC'},
  },
  {
    title: 'Slug ↑',
    expression: {slug: 'ASC'},
  },
  {
    title: 'Name ↑',
    expression: {name: 'ASC'},
  },
];

export default memo(function ScreenerList({fragmentRef}) {
  const {data, hasNext, loadNext, isLoadingNext, refetch} =
    usePaginationFragment(
      graphql`
        fragment ScreenerListFragment_query on Query
        @argumentDefinitions(
          cursor: {type: "String"}
          count: {type: "Int", defaultValue: 10}
          where: {type: "AssetFilterInput"}
          order: {
            type: "[AssetSortInput!]"
            defaultValue: {price: {marketCap: DESC}}
          }
        )
        @refetchable(queryName: "ScreenerListRefetchableQuery") {
          assets(after: $cursor, first: $count, where: $where, order: $order)
            @connection(key: "ScreenerList_assets") {
            edges {
              node {
                id
                ...ScreenerListItemFragment_asset
              }
            }
          }
        }
      `,
      fragmentRef,
    );

  const [q, setQ] = useState('');
  const qRef = useRef(q);
  const deferredQ = useDeferredValue(q);

  const [order, setOrder] = useState(0);
  const orderRef = useRef(order);

  const [busy, startTransition] = useTransition();

  useEffect(() => {
    if (qRef.current !== deferredQ || orderRef.current !== order) {
      qRef.current = deferredQ;
      orderRef.current = order;

      startTransition(() => {
        const variables = Object.assign(
          {},
          !!deferredQ && {
            where: {
              or: [
                {symbol: {contains: deferredQ}},
                {name: {contains: deferredQ}},
                {slug: {contains: deferredQ}},
              ],
            },
          },
          !!order && {order: Order[order].expression},
        );

        refetch(variables);
      });
    }
  }, [deferredQ, order]);

  const [tableRef, size] = useSize();
  const extended = size?.width > 400;

  const assets = data.assets.edges;

  return (
    <Stack gap={2}>
      <Stack
        direction="row"
        justifyContent="space-between"
        alignItems="center"
        px={2}
        gap={20}
      >
        <TextField
          type="search"
          variant="standard"
          value={q}
          placeholder="Search all assets"
          autoComplete="off"
          size="small"
          InputProps={{
            startAdornment: (
              <InputAdornment position="start">
                <SearchIcon />
              </InputAdornment>
            ),
            disableUnderline: true,
          }}
          autoFocus
          sx={{flex: 1, border: 0}}
          onChange={(e) => {
            setQ(e.target.value);
          }}
        />
        <SortButton options={Order} active={order} onChange={setOrder} />
      </Stack>
      <Divider />
      <Stack px={4}>
        {assets?.length || hasNext ? (
          <TransitionIndicator in={busy}>
            <Table ref={tableRef} size="medium">
              <TableBody>
                {assets.map(({node}) => (
                  <ScreenerListItem
                    key={node.id}
                    fragmentRef={node}
                    extended={extended}
                  />
                ))}
              </TableBody>
              {hasNext && (
                <TableFooter>
                  <TableRow>
                    <TableCell colSpan={5} align="center">
                      <LoadMoreButton busy={isLoadingNext} onClick={loadNext} />
                    </TableCell>
                  </TableRow>
                </TableFooter>
              )}
            </Table>
          </TransitionIndicator>
        ) : (
          <NoData message="Hmm, we can't find that asset." />
        )}
      </Stack>
    </Stack>
  );
});
