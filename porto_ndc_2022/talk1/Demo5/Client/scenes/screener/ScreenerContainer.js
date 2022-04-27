import {Stack} from '@mui/material';
import {memo} from 'react';
import {graphql, useLazyLoadQuery} from 'react-relay';

import ScreenerList from './ScreenerList';

export default memo(function ScreenerContainer({cacheBuster}) {
  const data = useLazyLoadQuery(
    graphql`
      query ScreenerContainerQuery {
        ...ScreenerListFragment_query
      }
    `,
    {},
    {fetchKey: cacheBuster},
  );

  return (
    <Stack gap={2}>
      <ScreenerList fragmentRef={data} />
    </Stack>
  );
});
