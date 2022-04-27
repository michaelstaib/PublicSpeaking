import {useLoadMore} from '@/hooks';

import {BusyButton} from './busy-button';

export const LoadMoreButton = ({busy, onClick, ...rest}) => {
  const [loaderRef, loadMore] = useLoadMore(() => {
    if (!busy) {
      onClick();
    }
  }, [busy, onClick]);

  return (
    <BusyButton
      ref={loaderRef}
      busy={busy}
      onClick={loadMore}
      children="load more"
      {...rest}
    />
  );
};
