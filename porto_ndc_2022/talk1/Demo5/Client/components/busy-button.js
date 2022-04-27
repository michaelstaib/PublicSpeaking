import {Button, CircularProgress} from '@mui/material';
import {forwardRef} from 'react';

export const BusyButton = forwardRef(({busy, ...rest}, ref) => (
  <Button
    ref={ref}
    disabled={busy}
    startIcon={busy && <CircularProgress size="1em" />}
    {...rest}
  />
));
