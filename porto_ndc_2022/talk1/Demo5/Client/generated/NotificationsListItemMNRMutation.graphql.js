/**
 * @generated SignedSource<<97d19ba320085a7b231244266a725280>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Mutation } from 'relay-runtime';
export type MarkNotificationReadInput = {|
  notificationId: string,
|};
export type NotificationsListItemMNRMutation$variables = {|
  input: MarkNotificationReadInput,
|};
export type NotificationsListItemMNRMutation$data = {|
  +markNotificationRead: {|
    +readNotification: ?{|
      +read: boolean,
    |},
  |},
|};
export type NotificationsListItemMNRMutation = {|
  variables: NotificationsListItemMNRMutation$variables,
  response: NotificationsListItemMNRMutation$data,
|};
*/

var node/*: ConcreteRequest*/ = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "input"
  }
],
v1 = [
  {
    "kind": "Variable",
    "name": "input",
    "variableName": "input"
  }
],
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "read",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "NotificationsListItemMNRMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "MarkNotificationReadPayload",
        "kind": "LinkedField",
        "name": "markNotificationRead",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Notification",
            "kind": "LinkedField",
            "name": "readNotification",
            "plural": false,
            "selections": [
              (v2/*: any*/)
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ],
    "type": "Mutation",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Operation",
    "name": "NotificationsListItemMNRMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "MarkNotificationReadPayload",
        "kind": "LinkedField",
        "name": "markNotificationRead",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Notification",
            "kind": "LinkedField",
            "name": "readNotification",
            "plural": false,
            "selections": [
              (v2/*: any*/),
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "id",
                "storageKey": null
              }
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "672486cd6dc6e99f20753218686b83eb",
    "id": null,
    "metadata": {},
    "name": "NotificationsListItemMNRMutation",
    "operationKind": "mutation",
    "text": "mutation NotificationsListItemMNRMutation(\n  $input: MarkNotificationReadInput!\n) {\n  markNotificationRead(input: $input) {\n    readNotification {\n      read\n      id\n    }\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "ac35bf7e019ba0540f4502d49a7c00c1";

export default node;
