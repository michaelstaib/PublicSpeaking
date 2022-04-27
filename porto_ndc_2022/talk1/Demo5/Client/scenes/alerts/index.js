import {Suspense} from 'react';

import {ActivityIndicator, Drawer, ErrorBoundaryWithRetry} from '@/components';
import {useAlerts} from '@/hooks';

import AlertsContainer from './AlertsContainer';

export const Alerts = ({symbol}) => {
  const {active, hide} = useAlerts();

  return (
    <Drawer
      anchor="bottom"
      open={active}
      PaperProps={{sx: {minHeight: 300}}}
      onClose={hide}
    >
      <ErrorBoundaryWithRetry key={symbol}>
        {({cacheBuster}) => (
          <Suspense fallback={<ActivityIndicator />}>
            <AlertsContainer symbol={symbol} cacheBuster={cacheBuster} />
          </Suspense>
        )}
      </ErrorBoundaryWithRetry>
    </Drawer>
  );
};
