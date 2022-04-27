import styled from '@emotion/styled';
import {Box, Link, Stack, Typography} from '@mui/material';
import {memo} from 'react';
import {graphql, useFragment} from 'react-relay';

import {WebsiteIcon, WhitepaperIcon} from '@/icons';

const $Link = styled(Link)(
  ({theme}) => `
  margin-right: auto;
  display: flex;
  align-items: center;
  gap: ${theme.spacing(2)};

  .MuiSvgIcon-root {
    fill: ${theme.palette.text.secondary};
  }
`,
);

export default memo(function ViewerResources({fragmentRef}) {
  const asset = useFragment(
    graphql`
      fragment ViewerResourcesFragment_asset on Asset {
        website
        whitePaper
      }
    `,
    fragmentRef,
  );

  return (
    <Stack p={2}>
      <Typography variant="h3" gutterBottom>
        Resources
      </Typography>
      <Box sx={{display: 'flex', flexDirection: 'column', py: 1, px: 2}}>
        {asset.whitePaper && (
          <$Link
            href={asset.whitePaper}
            target="_blank"
            rel="noopener"
            variant="body2"
            underline="none"
            gutterBottom
          >
            <WhitepaperIcon fontSize="small" />
            Whitepaper
          </$Link>
        )}
        {asset.website && (
          <$Link
            href={asset.website}
            target="_blank"
            rel="noopener"
            variant="body2"
            underline="none"
          >
            <WebsiteIcon fontSize="small" />
            Official website
          </$Link>
        )}
      </Box>
    </Stack>
  );
});
