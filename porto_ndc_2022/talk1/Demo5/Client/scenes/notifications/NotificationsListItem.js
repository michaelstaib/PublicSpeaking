import {
  Checkbox,
  Link,
  ListItem,
  ListItemAvatar,
  ListItemButton,
  ListItemText,
} from '@mui/material';
import NextLink from 'next/link';
import {memo, useCallback} from 'react';
import {
  ConnectionHandler,
  graphql,
  useFragment,
  useMutation,
} from 'react-relay';

import {CryptoIcon, UnreadIcon} from '@/icons';

const useMarkNotificationRead = () => {
  const [commit, isInFlight] = useMutation(graphql`
    mutation NotificationsListItemMNRMutation(
      $input: MarkNotificationReadInput!
    ) {
      markNotificationRead(input: $input) {
        readNotification {
          read
        }
      }
    }
  `);

  const execute = useCallback(
    ({id}) => {
      const updater = (store) => {
        const me = store.getRoot().getLinkedRecord('me');

        if (me) {
          const notifications = ConnectionHandler.getConnection(
            me,
            'NotificationsList_notifications',
            {status: 'UNREAD'},
          );

          if (notifications) {
            ConnectionHandler.deleteNode(notifications, id);
          }
        }
      };

      commit({
        variables: {input: {notificationId: id}},
        optimisticUpdater: updater,
        updater,
        onCompleted: () => {
          console.log(`notification was marked as read`);
        },
        onError: () => {
          console.log(
            `there was a problem while marking the notification as read`,
          );
        },
      });
    },
    [commit],
  );

  return [execute, isInFlight];
};

export default memo(function NotificationsListItem({fragmentRef}) {
  const notification = useFragment(
    graphql`
      fragment NotificationsListItemFragment_notification on Notification {
        id
        message
        read
        asset {
          symbol
          name
          imageUrl
          price {
            currency
            lastPrice
          }
        }
      }
    `,
    fragmentRef,
  );
  const asset = notification.asset;

  const [markNotification] = useMarkNotificationRead();

  const labelId = `notification-${notification.id}`;
  const handleRead = () => {
    markNotification({id: notification.id});
  };

  return (
    <ListItem
      secondaryAction={
        <Checkbox
          edge="end"
          checked={true}
          checkedIcon={<UnreadIcon fontSize="inherit" />}
          inputProps={{'aria-labelledby': labelId}}
          onChange={handleRead}
        />
      }
      disablePadding
    >
      <NextLink
        href="/currencies/[symbol]"
        as={`/currencies/${asset.symbol}`}
        passHref
      >
        <ListItemButton component={Link} onClick={handleRead}>
          <ListItemAvatar>
            <CryptoIcon src={asset.imageUrl} alt={asset.name} size="medium" />
          </ListItemAvatar>
          <ListItemText id={labelId} primary={notification.message} />
        </ListItemButton>
      </NextLink>
    </ListItem>
  );
});
