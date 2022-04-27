import {
  AccordionActions,
  AccordionDetails,
  Button,
  Stack,
  TextField,
} from '@mui/material';
import {memo, useRef} from 'react';

import {Config, syncWithStorage} from '@/config';
import {LinksIcon} from '@/icons';

import {Group} from './Group';

export default memo(function SettingsLinks({active, onChange}) {
  const httpRef = useRef(null);
  const wsRef = useRef(null);

  return (
    <Group
      id="links"
      icon={LinksIcon}
      title="Links"
      active={active}
      onChange={onChange}
    >
      <form
        name="links"
        onSubmit={(e) => {
          e.preventDefault();

          const http = httpRef.current?.value;
          const ws = wsRef.current?.value;

          syncWithStorage({
            HTTP_ENDPOINT: http,
            WS_ENDPOINT: ws,
          });
        }}
      >
        <AccordionDetails id="panel-links-content" sx={{p: 6}}>
          <Stack direction="column" gap={8}>
            <TextField
              inputRef={httpRef}
              label="HTTP Endpoint"
              defaultValue={Config.HTTP_ENDPOINT}
              autoComplete="http"
              helperText="The URL of the server to send GraphQL queries over HTTP."
              required
              fullWidth
            />
            <TextField
              inputRef={wsRef}
              label="WS Endpoint"
              defaultValue={Config.WS_ENDPOINT}
              autoComplete="ws"
              helperText="The URL of the server to send GraphQL queries over WebSocket."
              required
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
