import {Avatar} from '@mui/material';

import CurrencyIcon from './currency-icon';

export default function CryptoIcon({size, sx, ...rest}) {
  return (
    <Avatar
      sx={[
        {
          ...(size === 'small' && {
            height: 20,
            width: 20,
          }),
          ...(size === 'medium' && {
            height: 32,
            width: 32,
          }),
          ...(size === 'large' && {
            height: 40,
            width: 40,
          }),
        },
        sx,
      ]}
      {...rest}
    >
      <CurrencyIcon />
    </Avatar>
  );
}
