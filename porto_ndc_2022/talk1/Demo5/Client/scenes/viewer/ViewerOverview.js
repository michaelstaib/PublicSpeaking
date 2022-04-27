import {Stack, Typography} from '@mui/material';
import {memo} from 'react';
import {graphql, useFragment} from 'react-relay';

export default memo(function ViewerOverview({fragmentRef}) {
  const asset = useFragment(
    graphql`
      fragment ViewerOverviewFragment_asset on Asset {
        description
      }
    `,
    fragmentRef,
  );

  return (
    <Stack p={2}>
      <Typography variant="h3" gutterBottom>
        Overview
      </Typography>
      <Typography variant="body2" py={1} px={2}>
        {asset.description}
      </Typography>
    </Stack>
  );
});
