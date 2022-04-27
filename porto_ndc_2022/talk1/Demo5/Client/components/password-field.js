import {IconButton, InputAdornment, TextField} from '@mui/material';
import {useState} from 'react';

import {HidePasswordIcon, ShowPasswordIcon} from '@/icons';

export const PasswordField = (props) => {
  const [type, setType] = useState('password');

  return (
    <TextField
      type={type}
      InputProps={{
        endAdornment: (
          <InputAdornment position="end">
            <IconButton
              size="small"
              aria-label="toggle visibility"
              onClick={() => {
                setType(type === 'password' ? 'text' : 'password');
              }}
              onMouseDown={(e) => {
                e.preventDefault();
              }}
              edge="end"
            >
              {type === 'password' ? (
                <HidePasswordIcon fontSize="inherit" />
              ) : (
                <ShowPasswordIcon fontSize="inherit" />
              )}
            </IconButton>
          </InputAdornment>
        ),
      }}
      {...props}
    />
  );
};
