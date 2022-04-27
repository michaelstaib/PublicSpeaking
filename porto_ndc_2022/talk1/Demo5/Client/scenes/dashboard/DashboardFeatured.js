import {memo} from 'react';
import {graphql, useFragment} from 'react-relay';

import {Carousel} from '@/components';

import DashboardFeaturedCard from './DashboardFeaturedCard';

export default memo(function DashboardFeatured({fragmentRef}) {
  const data = useFragment(
    graphql`
      fragment DashboardFeaturedFragment_query on Query {
        featured: assets(where: {symbol: {in: ["BTC", "ADA", "ALGO"]}}) {
          nodes {
            id
            ...DashboardFeaturedCardFragment_asset
          }
        }
      }
    `,
    fragmentRef,
  );
  const assets = data.featured?.nodes;

  return (
    !!assets?.length && (
      <Carousel py={4}>
        {assets.map((node) => (
          <DashboardFeaturedCard key={node.id} fragmentRef={node} />
        ))}
      </Carousel>
    )
  );
});
