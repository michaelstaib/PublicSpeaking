import {Suspense} from 'react';

import {ActivityIndicator, ErrorBoundaryWithRetry} from '@/components';

import SettingsContainer from './SettingsContainer';

export const Settings = ({symbol}) => (
  <ErrorBoundaryWithRetry key={symbol}>
    {({cacheBuster}) => (
      <Suspense fallback={<ActivityIndicator />}>
        <SettingsContainer cacheBuster={cacheBuster} />
      </Suspense>
    )}
  </ErrorBoundaryWithRetry>
);
