import {Divider, Stack} from '@mui/material';
import ErrorPage from 'next/error';
import {memo} from 'react';
import {graphql, useLazyLoadQuery} from 'react-relay';

import DashboardFeatured from './DashboardFeatured';
import DashboardSpotlight from './DashboardSpotlight';
import DashboardTicker from './DashboardTicker';

export default memo(function DashboardContainer({cacheBuster}) {
  const data = useLazyLoadQuery(
    graphql`
      query DashboardContainerQuery {
        ...DashboardTickerFragment_query
        ...DashboardFeaturedFragment_query
        ...DashboardSpotlightFragment_query @defer(label: "spotlight")
      }
    `,
    {},
    {fetchKey: cacheBuster},
  );

  if (!data) {
    return <ErrorPage statusCode={404} title="Out of service" />;
  }

  return (
    <Stack gap={2}>
      <DashboardTicker fragmentRef={data} />
      <Divider />
      <DashboardFeatured fragmentRef={data} />
      <Divider />
      <DashboardSpotlight fragmentRef={data} />
    </Stack>
  );
});
