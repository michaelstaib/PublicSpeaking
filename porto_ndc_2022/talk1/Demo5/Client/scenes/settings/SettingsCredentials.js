import {
  AccordionActions,
  AccordionDetails,
  Button,
  Stack,
  TextField,
} from '@mui/material';
import {memo, useRef} from 'react';

import {PasswordField} from '@/components';
import {Config, syncWithStorage} from '@/config';
import {CredentialsIcon} from '@/icons';

import {Group} from './Group';

export default memo(function SettingsCredentials({active, onChange}) {
  const usernameRef = useRef(null);
  const passwordRef = useRef(null);

  return (
    <Group
      id="credentials"
      icon={CredentialsIcon}
      title="Credentials"
      active={active}
      onChange={onChange}
    >
      <form
        name="credentials"
        onSubmit={(e) => {
          e.preventDefault();

          const username = usernameRef.current?.value?.trim();
          const password = passwordRef.current?.value?.trim();
          const token =
            username && password
              ? Buffer.from(`${username}:${password}`).toString('base64')
              : null;

          syncWithStorage({
            USERNAME: username,
            PASSWORD: password,
            AUTH_TOKEN: token,
          });
        }}
      >
        <AccordionDetails id="panel-credentials-content" sx={{p: 6}}>
          <Stack direction="column" gap={8}>
            <TextField
              inputRef={usernameRef}
              label="Username"
              defaultValue={Config.USERNAME}
              autoComplete="username"
              fullWidth
            />
            <PasswordField
              inputRef={passwordRef}
              label="Password"
              defaultValue={Config.PASSWORD}
              autoComplete="current-password"
              fullWidth
            />
          </Stack>
        </AccordionDetails>
        <AccordionActions
          sx={{flexDirection: 'row-reverse', justifyContent: 'flex-start'}}
        >
          <Button type="submit" color="primary">
            Save
          </Button>
          <Button type="reset" color="secondary">
            Cancel
          </Button>
        </AccordionActions>
      </form>
    </Group>
  );
});
