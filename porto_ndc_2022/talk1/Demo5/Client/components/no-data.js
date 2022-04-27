import {Typography} from '@mui/material';

export const NoData = ({message = 'No data available.', ...rest}) => (
  <Typography
    component="div"
    variant="body2"
    align="center"
    p={4}
    children={message}
    {...rest}
  />
);
