/**
 * @generated SignedSource<<10f9997066ccb1ce8631cef075520cb0>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, GraphQLSubscription } from 'relay-runtime';
export type NotificationsManagerSubscription$variables = {||};
export type NotificationsManagerSubscription$data = {|
  +onNotification: {|
    +unreadNotifications: number,
  |},
|};
export type NotificationsManagerSubscription = {|
  variables: NotificationsManagerSubscription$variables,
  response: NotificationsManagerSubscription$data,
|};
*/

var node/*: ConcreteRequest*/ = (function(){
var v0 = [
  {
    "alias": null,
    "args": null,
    "concreteType": "NotificationUpdate",
    "kind": "LinkedField",
    "name": "onNotification",
    "plural": false,
    "selections": [
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "unreadNotifications",
        "storageKey": null
      }
    ],
    "storageKey": null
  }
];
return {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "NotificationsManagerSubscription",
    "selections": (v0/*: any*/),
    "type": "Subscription",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "NotificationsManagerSubscription",
    "selections": (v0/*: any*/)
  },
  "params": {
    "cacheID": "838cc0897535518d7290c027f1d1c494",
    "id": null,
    "metadata": {},
    "name": "NotificationsManagerSubscription",
    "operationKind": "subscription",
    "text": "subscription NotificationsManagerSubscription {\n  onNotification {\n    unreadNotifications\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "6769e0d8becc841d9a494f9de8603c8f";

export default node;
