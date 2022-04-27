import {
  AccordionActions,
  AccordionDetails,
  Avatar,
  Button,
  IconButton,
  Stack,
  TextField,
} from '@mui/material';
import {memo, useCallback, useEffect, useRef, useState} from 'react';
import {useDropzone} from 'react-dropzone';
import {graphql, useFragment, useMutation} from 'react-relay';

import {DeleteIcon, FileUploadIcon, ProfileIcon} from '@/icons';

import {Group} from './Group';

const useUpdateUserProfile = () => {
  const [commit, isInFlight] = useMutation(graphql`
    mutation SettingsProfileUUPMutation($input: UpdateUserProfileInput!) {
      updateUserProfile(input: $input) {
        updatedUser {
          displayName
          imageUrl
        }
      }
    }
  `);

  const execute = useCallback(
    ({id, displayName, image, previewUrl}) => {
      commit({
        variables: {
          input: Object.assign({displayName}, image !== undefined && {image}),
        },
        optimisticUpdater(store) {
          const record = store.get(id);

          record.setValue(displayName, 'displayName');

          if (previewUrl !== undefined) {
            record.setValue(previewUrl, 'imageUrl');
          }
        },
        onCompleted() {
          console.log('profile was updated');
        },
        onError() {
          console.log('there was a problem while updating the profile');
        },
      });
    },
    [commit],
  );

  return [execute, isInFlight];
};

export default memo(function SettingsProfile({active, onChange, fragmentRef}) {
  const data = useFragment(
    graphql`
      fragment SettingsProfileFragment_query on Query {
        me {
          id
          name
          displayName
          imageUrl
        }
      }
    `,
    fragmentRef,
  );
  const me = data.me;

  const [updateUserProfile] = useUpdateUserProfile();

  const [[image, previewUrl], setAvatar] = useState([]);

  const {getRootProps, getInputProps, open} = useDropzone({
    accept: 'image/*',
    multiple: false,
    maxFiles: 1,
    maxSize: 1_024_000,
    onDropAccepted: ([file]) => {
      console.log('image drop accepted');

      setAvatar([file, URL.createObjectURL(file)]);
    },
    onDropRejected: (fileRejections) => {
      console.log('image drop rejected', fileRejections);
    },
  });

  const displaynameRef = useRef(null);

  useEffect(() => {
    if (previewUrl) {
      return () => {
        URL.revokeObjectURL(previewUrl);
      };
    }
  }, [previewUrl]);

  return (
    <Group
      id="profile"
      icon={ProfileIcon}
      title="Profile"
      active={active}
      disabled={!me}
      onChange={onChange}
    >
      {me && (
        <form
          name="links"
          onSubmit={(e) => {
            e.preventDefault();

            const displayName = displaynameRef.current?.value || null;

            updateUserProfile({
              id: me.id,
              displayName,
              image,
              previewUrl,
            });
          }}
        >
          <AccordionDetails id="panel-profile-content" sx={{p: 6}}>
            <Stack direction="column" alignItems="center" gap={8}>
              <input {...getInputProps()} />
              <Avatar
                src={previewUrl === undefined ? me.imageUrl : previewUrl}
                sx={(theme) => ({
                  width: 192,
                  height: 192,
                  border: `1px solid ${theme.palette.action.focus}`,
                  backgroundColor: theme.palette.action.focus,
                  outline: 0,
                  '&:hover': {
                    borderColor: theme.palette.text.primary,
                  },
                  '&:focus': {
                    borderWidth: 2,
                    borderColor: theme.palette.primary.main,
                  },
                })}
                {...getRootProps()}
              />
              <Stack direction="row">
                <IconButton
                  size="medium"
                  aria-label="remove image"
                  disabled={!previewUrl && !me.imageUrl}
                  onClick={() => {
                    setAvatar([null, null]);
                  }}
                >
                  <DeleteIcon fontSize="inherit" />
                </IconButton>
                <IconButton
                  size="medium"
                  aria-label="upload image"
                  onClick={open}
                >
                  <FileUploadIcon fontSize="inherit" />
                </IconButton>
              </Stack>
              <TextField
                inputRef={displaynameRef}
                label="Displayname"
                defaultValue={me.displayName}
                autoComplete="displayname"
                helperText="Your name may appear around where you contribute or are mentioned. You can remove it at any time."
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
            <Button
              type="reset"
              color="secondary"
              onClick={() => {
                setAvatar([]);
              }}
            >
              Cancel
            </Button>
          </AccordionActions>
        </form>
      )}
    </Group>
  );
});
