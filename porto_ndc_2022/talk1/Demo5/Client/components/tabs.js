import {Box, Tab as MuiTab, Tabs as MuiTabs} from '@mui/material';

export const Tabs = (props) => (
  <MuiTabs
    textColor="inherit"
    indicatorColor="primary"
    variant="fullWidth"
    sx={{borderBottom: 1, borderColor: 'divider'}}
    {...props}
  />
);

export const Tab = ({index, ...rest}) => (
  <MuiTab id={`tab-${index}`} aria-controls={`tabpanel-${index}`} {...rest} />
);

export const TabPanel = ({value, index, ...rest}) =>
  value === index && (
    <Box
      id={`tabpanel-${index}`}
      aria-labelledby={`tab-${index}`}
      role="tabpanel"
      p={4}
      {...rest}
    />
  );
