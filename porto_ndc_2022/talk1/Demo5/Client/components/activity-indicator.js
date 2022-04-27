import {CircularProgress, Fade} from '@mui/material';

export const ActivityIndicator = ({
  in: inProp = true,
  timeout = 300,
  sx,
  ...rest
}) => (
  <Fade
    in={inProp}
    mountOnEnter
    unmountOnExit
    style={{transitionDelay: timeout}}
  >
    <CircularProgress sx={{margin: 'auto', ...sx}} {...rest} />
  </Fade>
);
