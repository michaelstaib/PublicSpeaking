import {Button, List, Stack} from '@mui/material';
import {memo, useCallback} from 'react';
import {
  ConnectionHandler,
  graphql,
  useMutation,
  usePaginationFragment,
} from 'react-relay';

import {LoadMoreButton, NoData} from '@/components';
import {ReadIcon} from '@/icons';

import NotificationsListItem from './NotificationsListItem';

const useMarkNotificationsRead = () => {
  const [commit, isInFlight] = useMutation(graphql`
    mutation NotificationsListMNRMutation($input: MarkNotificationsReadInput!) {
      markNotificationsRead(input: $input) {
        readNotifications {
          read
        }
      }
    }
  `);

  const execute = useCallback(
    ({ids}) => {
      const updater = (store) => {
        const me = store.getRoot().getLinkedRecord('me');

        if (me) {
          const notifications = ConnectionHandler.getConnection(
            me,
            'NotificationsList_notifications',
            {status: 'UNREAD'},
          );

          if (notifications) {
            ids.forEach((id) => {
              ConnectionHandler.deleteNode(notifications, id);
            });
          }
        }
      };

      commit({
        variables: {input: {notificationIds: ids}},
        optimisticUpdater: updater,
        updater,
        onCompleted: () => {
          console.log(`notifications were marked as read`);
        },
        onError: () => {
          console.log(
            `there was a problem while marking the notifications as read`,
          );
        },
      });
    },
    [commit],
  );

  return [execute, isInFlight];
};

export default memo(function NotificationsList({fragmentRef}) {
  const {data, hasNext, loadNext, isLoadingNext} = usePaginationFragment(
    graphql`
      fragment NotificationsListFragment_query on Query
      @argumentDefinitions(
        cursor: {type: "String"}
        count: {type: "Int", defaultValue: 10}
      )
      @refetchable(queryName: "NotificationsListRefetchableQuery") {
        me {
          notifications(after: $cursor, first: $count, status: UNREAD)
            @connection(key: "NotificationsList_notifications") {
            edges {
              node {
                id
                read
                ...NotificationsListItemFragment_notification
              }
            }
          }
        }
      }
    `,
    fragmentRef,
  );
  const notifications = data.me?.notifications?.edges;

  const [markNotifications] = useMarkNotificationsRead();

  const handleRead = () => {
    markNotifications({ids: notifications.map(({node}) => node.id)});
  };

  return (
    <Stack py={2} px={4}>
      {notifications?.length || hasNext ? (
        <>
          <Stack direction="row" justifyContent="end" pr={2}>
            <Button
              variant="text"
              size="small"
              endIcon={<ReadIcon />}
              onClick={handleRead}
            >
              read all
            </Button>
          </Stack>
          <List>
            {notifications.map(({node}) => (
              <NotificationsListItem key={node.id} fragmentRef={node} />
            ))}
          </List>
          {hasNext && (
            <Stack alignItems="center">
              <LoadMoreButton busy={isLoadingNext} onClick={loadNext} />
            </Stack>
          )}
        </>
      ) : (
        <NoData message="You're all caught up." />
      )}
    </Stack>
  );
});
