/**
 * @generated SignedSource<<43b29160223b643279aef6800850834f>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ReaderFragment, RefetchableFragment } from 'relay-runtime';
import type { NotificationsListItemFragment_notification$fragmentType } from "./NotificationsListItemFragment_notification.graphql";
import type { FragmentType } from "relay-runtime";
declare export opaque type NotificationsListFragment_query$fragmentType: FragmentType;
import type { NotificationsListRefetchableQuery$variables } from "./NotificationsListRefetchableQuery.graphql";
export type NotificationsListFragment_query$data = {|
  +me: ?{|
    +notifications: ?{|
      +edges: ?$ReadOnlyArray<{|
        +node: {|
          +id: string,
          +read: boolean,
          +$fragmentSpreads: NotificationsListItemFragment_notification$fragmentType,
        |},
      |}>,
    |},
  |},
  +$fragmentType: NotificationsListFragment_query$fragmentType,
|};
export type NotificationsListFragment_query$key = {
  +$data?: NotificationsListFragment_query$data,
  +$fragmentSpreads: NotificationsListFragment_query$fragmentType,
  ...
};
*/

import NotificationsListRefetchableQuery_graphql from './NotificationsListRefetchableQuery.graphql';
var node/*: ReaderFragment*/ = (function(){
var v0 = [
  "me",
  "notifications"
];
return {
  "argumentDefinitions": [
    {
      "defaultValue": 10,
      "kind": "LocalArgument",
      "name": "count"
    },
    {
      "defaultValue": null,
      "kind": "LocalArgument",
      "name": "cursor"
    }
  ],
  "kind": "Fragment",
  "metadata": {
    "connection": [
      {
        "count": "count",
        "cursor": "cursor",
        "direction": "forward",
        "path": (v0/*: any*/)
      }
    ],
    "refetch": {
      "connection": {
        "forward": {
          "count": "count",
          "cursor": "cursor"
        },
        "backward": null,
        "path": (v0/*: any*/)
      },
      "fragmentPathInResult": [],
      "operation": NotificationsListRefetchableQuery_graphql
    }
  },
  "name": "NotificationsListFragment_query",
  "selections": [
    {
      "alias": null,
      "args": null,
      "concreteType": "User",
      "kind": "LinkedField",
      "name": "me",
      "plural": false,
      "selections": [
        {
          "alias": "notifications",
          "args": [
            {
              "kind": "Literal",
              "name": "status",
              "value": "UNREAD"
            }
          ],
          "concreteType": "NotificationsConnection",
          "kind": "LinkedField",
          "name": "__NotificationsList_notifications_connection",
          "plural": false,
          "selections": [
            {
              "alias": null,
              "args": null,
              "concreteType": "NotificationsEdge",
              "kind": "LinkedField",
              "name": "edges",
              "plural": true,
              "selections": [
                {
                  "alias": null,
                  "args": null,
                  "concreteType": "Notification",
                  "kind": "LinkedField",
                  "name": "node",
                  "plural": false,
                  "selections": [
                    {
                      "alias": null,
                      "args": null,
                      "kind": "ScalarField",
                      "name": "id",
                      "storageKey": null
                    },
                    {
                      "alias": null,
                      "args": null,
                      "kind": "ScalarField",
                      "name": "read",
                      "storageKey": null
                    },
                    {
                      "args": null,
                      "kind": "FragmentSpread",
                      "name": "NotificationsListItemFragment_notification"
                    },
                    {
                      "alias": null,
                      "args": null,
                      "kind": "ScalarField",
                      "name": "__typename",
                      "storageKey": null
                    }
                  ],
                  "storageKey": null
                },
                {
                  "alias": null,
                  "args": null,
                  "kind": "ScalarField",
                  "name": "cursor",
                  "storageKey": null
                }
              ],
              "storageKey": null
            },
            {
              "alias": null,
              "args": null,
              "concreteType": "PageInfo",
              "kind": "LinkedField",
              "name": "pageInfo",
              "plural": false,
              "selections": [
                {
                  "alias": null,
                  "args": null,
                  "kind": "ScalarField",
                  "name": "endCursor",
                  "storageKey": null
                },
                {
                  "alias": null,
                  "args": null,
                  "kind": "ScalarField",
                  "name": "hasNextPage",
                  "storageKey": null
                }
              ],
              "storageKey": null
            }
          ],
          "storageKey": "__NotificationsList_notifications_connection(status:\"UNREAD\")"
        }
      ],
      "storageKey": null
    }
  ],
  "type": "Query",
  "abstractKey": null
};
})();

(node/*: any*/).hash = "0e5e27789efaf889e60a6859c7c162b3";

export default node;
