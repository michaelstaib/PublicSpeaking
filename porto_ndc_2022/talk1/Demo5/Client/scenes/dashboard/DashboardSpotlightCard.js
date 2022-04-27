import {
  Card,
  CardContent,
  CardHeader,
  IconButton,
  Table,
  TableBody,
} from '@mui/material';
import {useState} from 'react';
import {graphql, useFragment} from 'react-relay';

import {NoData} from '@/components';
import {SwapIcon} from '@/icons';

import DashboardSpotlightItem from './DashboardSpotlightItem';

const Views = {
  CHANGE: 'change',
  PRICE: 'price',
};

export default function DashboardSpotlightCard({fragmentRef, avatar, title}) {
  const data = useFragment(
    graphql`
      fragment DashboardSpotlightCardFragment_asset on AssetsConnection {
        nodes {
          id
          ...DashboardSpotlightItemFragment_asset
        }
      }
    `,
    fragmentRef,
  );
  const assets = data?.nodes;

  const [view, setView] = useState(Views.CHANGE);

  return (
    <Card elevation={0} sx={{minWidth: 250}}>
      <CardHeader
        sx={{p: 2}}
        avatar={avatar}
        title={title}
        action={
          <IconButton
            aria-label={view}
            onClick={() => {
              setView(view === Views.CHANGE ? Views.PRICE : Views.CHANGE);
            }}
          >
            <SwapIcon />
          </IconButton>
        }
      />
      <CardContent sx={{'&:last-child': {pt: 0, pb: 2, px: 4}}}>
        {assets?.length ? (
          <Table size="medium">
            <TableBody>
              {assets.map((node) => (
                <DashboardSpotlightItem
                  key={node.id}
                  fragmentRef={node}
                  view={view}
                />
              ))}
            </TableBody>
          </Table>
        ) : (
          <NoData />
        )}
      </CardContent>
    </Card>
  );
}
