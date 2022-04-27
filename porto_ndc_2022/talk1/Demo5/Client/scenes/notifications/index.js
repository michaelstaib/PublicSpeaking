import {Suspense} from 'react';

import {ActivityIndicator, Drawer, ErrorBoundaryWithRetry} from '@/components';
import {useNotifications} from '@/hooks';

import NotificationsContainer from './NotificationsContainer';
import NotificationsManager from './NotificationsManager';

export const Notifications = () => {
  const {active, show, hide} = useNotifications();

  return (
    <>
      <NotificationsManager onClick={show} />
      <Drawer open={active} onClose={hide}>
        <ErrorBoundaryWithRetry>
          {({cacheBuster}) => (
            <Suspense fallback={<ActivityIndicator />}>
              <NotificationsContainer cacheBuster={cacheBuster} />
            </Suspense>
          )}
        </ErrorBoundaryWithRetry>
      </Drawer>
    </>
  );
};
