import {Stack} from '@mui/material';
import {memo} from 'react';
import {graphql, useLazyLoadQuery} from 'react-relay';

import WatchlistList from './WatchlistList';

export default memo(function WatchlistContainer({cacheBuster}) {
  const data = useLazyLoadQuery(
    graphql`
      query WatchlistContainerQuery {
        ...WatchlistListFragment_query
      }
    `,
    {},
    {
      fetchPolicy: 'store-and-network',
      fetchKey: cacheBuster,
    },
  );

  return (
    <Stack gap={2}>
      <WatchlistList fragmentRef={data} />
    </Stack>
  );
});
