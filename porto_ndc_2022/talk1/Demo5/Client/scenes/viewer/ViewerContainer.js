import {Stack} from '@mui/material';
import ErrorPage from 'next/error';
import {memo} from 'react';
import {graphql, useLazyLoadQuery} from 'react-relay';

import ViewerHeader from './ViewerHeader';
import ViewerOverview from './ViewerOverview';
import ViewerResources from './ViewerResources';
import ViewerSnapshot from './ViewerSnapshot';
import ViewerStats from './ViewerStats';

export default memo(function ViewerContainer({symbol, cacheBuster}) {
  const data = useLazyLoadQuery(
    graphql`
      query ViewerContainerQuery($symbol: String!) {
        assetBySymbol(symbol: $symbol) {
          ...ViewerHeaderFragment_asset
          ...ViewerSnapshotFragment_asset
          ...ViewerStatsFragment_asset
          ...ViewerOverviewFragment_asset
          ...ViewerResourcesFragment_asset
        }
      }
    `,
    {symbol},
    {fetchKey: cacheBuster},
  );

  if (!data.assetBySymbol) {
    return (
      <ErrorPage statusCode={404} title="This currency could not be found" />
    );
  }

  return (
    <Stack gap={4}>
      <ViewerHeader fragmentRef={data.assetBySymbol} />
      <ViewerSnapshot fragmentRef={data.assetBySymbol} />
      <ViewerStats fragmentRef={data.assetBySymbol} />
      <ViewerOverview fragmentRef={data.assetBySymbol} />
      <ViewerResources fragmentRef={data.assetBySymbol} />
    </Stack>
  );
});
