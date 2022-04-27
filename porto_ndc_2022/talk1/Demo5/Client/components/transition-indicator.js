import {Fade} from '@mui/material';

export const TransitionIndicator = ({in: inProp = false, ...rest}) => (
  <Fade
    in={inProp}
    style={{
      filter: inProp && 'blur(2px)',
      opacity: 1,
      visibility: 'visible',
    }}
    {...rest}
  />
);
