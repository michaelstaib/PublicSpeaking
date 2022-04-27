import {
  Alert,
  AlertTitle,
  Button,
  IconButton,
  Portal,
  Snackbar,
  Tooltip,
} from '@mui/material';

import {useCounter, useSlots, useToggle} from '@/hooks';
import {PlayIcon, RefetchIcon, RerenderIcon, StopIcon} from '@/icons';

import {ErrorBoundary} from './error-boundary';

const Fallback = ({error, dismiss, retry}) => (
  <Snackbar
    anchorOrigin={{vertical: 'bottom', horizontal: 'center'}}
    open={!!error}
    sx={{position: 'absolute'}}
  >
    <Alert
      severity="error"
      action={
        <>
          <Button color="inherit" size="small" onClick={dismiss}>
            dismiss
          </Button>
          <Button color="error" size="small" onClick={retry}>
            retry
          </Button>
        </>
      }
    >
      {error.name && <AlertTitle>{error.name}</AlertTitle>}
      {error.message || 'Something went wrong!'}
    </Alert>
  </Snackbar>
);

const Commands = ({active, toggle, refetch, rerender}) => {
  const {statusbar: statusbarRef} = useSlots();

  return (
    <Portal container={statusbarRef.current}>
      <Tooltip title="Toggle">
        <IconButton aria-label="toggle" size="small" onClick={toggle}>
          {active ? (
            <StopIcon fontSize="inherit" />
          ) : (
            <PlayIcon fontSize="inherit" />
          )}
        </IconButton>
      </Tooltip>
      <Tooltip title="Rerender">
        <span>
          <IconButton
            aria-label="rerender"
            size="small"
            disabled={!active}
            onClick={rerender}
          >
            <RerenderIcon fontSize="inherit" />
          </IconButton>
        </span>
      </Tooltip>
      <Tooltip title="Refetch">
        <span>
          <IconButton
            aria-label="refetch"
            size="small"
            disabled={!active}
            onClick={refetch}
          >
            <RefetchIcon fontSize="inherit" />
          </IconButton>
        </span>
      </Tooltip>
    </Portal>
  );
};

export const ErrorBoundaryWithRetry = ({children}) => {
  const [active, toggle] = useToggle(true);
  const [cacheBuster, refetch] = useCounter();
  const [, rerender] = useCounter();
  const [key, retry] = useCounter();

  return (
    <>
      {active && (
        <ErrorBoundary
          key={key}
          fallback={({error}) => (
            <Fallback {...{error, dismiss: toggle, retry}} />
          )}
        >
          {children({cacheBuster})}
        </ErrorBoundary>
      )}
      <Commands {...{active, toggle, refetch, rerender}} />
    </>
  );
};
