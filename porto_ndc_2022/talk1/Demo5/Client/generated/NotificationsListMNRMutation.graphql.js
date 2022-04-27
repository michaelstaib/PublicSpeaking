/**
 * @generated SignedSource<<3d3be665a53a02d9eb661d0448f5df43>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Mutation } from 'relay-runtime';
export type MarkNotificationsReadInput = {|
  notificationIds: $ReadOnlyArray<string>,
|};
export type NotificationsListMNRMutation$variables = {|
  input: MarkNotificationsReadInput,
|};
export type NotificationsListMNRMutation$data = {|
  +markNotificationsRead: {|
    +readNotifications: ?$ReadOnlyArray<{|
      +read: boolean,
    |}>,
  |},
|};
export type NotificationsListMNRMutation = {|
  variables: NotificationsListMNRMutation$variables,
  response: NotificationsListMNRMutation$data,
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
    "name": "NotificationsListMNRMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "MarkNotificationsReadPayload",
        "kind": "LinkedField",
        "name": "markNotificationsRead",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Notification",
            "kind": "LinkedField",
            "name": "readNotifications",
            "plural": true,
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
    "name": "NotificationsListMNRMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "MarkNotificationsReadPayload",
        "kind": "LinkedField",
        "name": "markNotificationsRead",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Notification",
            "kind": "LinkedField",
            "name": "readNotifications",
            "plural": true,
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
    "cacheID": "085f00913c28ee2a2b574cafcc7bfbc3",
    "id": null,
    "metadata": {},
    "name": "NotificationsListMNRMutation",
    "operationKind": "mutation",
    "text": "mutation NotificationsListMNRMutation(\n  $input: MarkNotificationsReadInput!\n) {\n  markNotificationsRead(input: $input) {\n    readNotifications {\n      read\n      id\n    }\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "67f385474585dce1ef1f4bce0b4f85f9";

export default node;
