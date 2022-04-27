import {Suspense} from 'react';

import {ActivityIndicator, ErrorBoundaryWithRetry} from '@/components';

import ScreenerContainer from './ScreenerContainer';

export const Screener = () => (
  <ErrorBoundaryWithRetry>
    {({cacheBuster}) => (
      <Suspense fallback={<ActivityIndicator />}>
        <ScreenerContainer cacheBuster={cacheBuster} />
      </Suspense>
    )}
  </ErrorBoundaryWithRetry>
);
