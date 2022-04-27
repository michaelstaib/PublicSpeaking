/**
 * @generated SignedSource<<1b2fe5dfb4375d7331f23eb4713de791>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Mutation } from 'relay-runtime';
export type CreateAlertInput = {|
  currency?: ?string,
  recurring: boolean,
  symbol: string,
  targetPrice: number,
|};
export type AlertsActionsCAMutation$variables = {|
  input: CreateAlertInput,
|};
export type AlertsActionsCAMutation$data = {|
  +createAlert: {|
    +createdAlert: ?{|
      +asset: {|
        +hasAlerts: boolean,
        +alerts: ?{|
          +nodes: ?$ReadOnlyArray<{|
            +id: string,
            +currency: string,
            +targetPrice: number,
            +percentageChange: number,
            +recurring: boolean,
          |}>,
        |},
      |},
    |},
  |},
|};
export type AlertsActionsCAMutation = {|
  variables: AlertsActionsCAMutation$variables,
  response: AlertsActionsCAMutation$data,
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
  "name": "hasAlerts",
  "storageKey": null
},
v3 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
},
v4 = {
  "alias": null,
  "args": null,
  "concreteType": "AssetAlertsConnection",
  "kind": "LinkedField",
  "name": "alerts",
  "plural": false,
  "selections": [
    {
      "alias": null,
      "args": null,
      "concreteType": "Alert",
      "kind": "LinkedField",
      "name": "nodes",
      "plural": true,
      "selections": [
        (v3/*: any*/),
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "currency",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "targetPrice",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "percentageChange",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "recurring",
          "storageKey": null
        }
      ],
      "storageKey": null
    }
  ],
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "AlertsActionsCAMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "CreateAlertPayload",
        "kind": "LinkedField",
        "name": "createAlert",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Alert",
            "kind": "LinkedField",
            "name": "createdAlert",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "Asset",
                "kind": "LinkedField",
                "name": "asset",
                "plural": false,
                "selections": [
                  (v2/*: any*/),
                  (v4/*: any*/)
                ],
                "storageKey": null
              }
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
    "name": "AlertsActionsCAMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "CreateAlertPayload",
        "kind": "LinkedField",
        "name": "createAlert",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Alert",
            "kind": "LinkedField",
            "name": "createdAlert",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "Asset",
                "kind": "LinkedField",
                "name": "asset",
                "plural": false,
                "selections": [
                  (v2/*: any*/),
                  (v4/*: any*/),
                  (v3/*: any*/)
                ],
                "storageKey": null
              },
              (v3/*: any*/)
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "f65b9f141a43b49401ce4f404e8f3bdc",
    "id": null,
    "metadata": {},
    "name": "AlertsActionsCAMutation",
    "operationKind": "mutation",
    "text": "mutation AlertsActionsCAMutation(\n  $input: CreateAlertInput!\n) {\n  createAlert(input: $input) {\n    createdAlert {\n      asset {\n        hasAlerts\n        alerts {\n          nodes {\n            id\n            currency\n            targetPrice\n            percentageChange\n            recurring\n          }\n        }\n        id\n      }\n      id\n    }\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "a5cef29832ee6d722e0f0b2db4f93374";

export default node;
