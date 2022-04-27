/**
 * @generated SignedSource<<27c4bd80d39b78fb61f58a7a7fc12057>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Mutation } from 'relay-runtime';
export type DeleteAlertInput = {|
  alertId: string,
|};
export type AlertsActionsDAMutation$variables = {|
  input: DeleteAlertInput,
|};
export type AlertsActionsDAMutation$data = {|
  +deleteAlert: {|
    +deletedAlert: ?{|
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
export type AlertsActionsDAMutation = {|
  variables: AlertsActionsDAMutation$variables,
  response: AlertsActionsDAMutation$data,
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
    "name": "AlertsActionsDAMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "DeleteAlertPayload",
        "kind": "LinkedField",
        "name": "deleteAlert",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Alert",
            "kind": "LinkedField",
            "name": "deletedAlert",
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
    "name": "AlertsActionsDAMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "DeleteAlertPayload",
        "kind": "LinkedField",
        "name": "deleteAlert",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Alert",
            "kind": "LinkedField",
            "name": "deletedAlert",
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
    "cacheID": "66d6f71a5d1eff0fc6c1042e820127bb",
    "id": null,
    "metadata": {},
    "name": "AlertsActionsDAMutation",
    "operationKind": "mutation",
    "text": "mutation AlertsActionsDAMutation(\n  $input: DeleteAlertInput!\n) {\n  deleteAlert(input: $input) {\n    deletedAlert {\n      asset {\n        hasAlerts\n        alerts {\n          nodes {\n            id\n            currency\n            targetPrice\n            percentageChange\n            recurring\n          }\n        }\n        id\n      }\n      id\n    }\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "dea990e060d1358827de2b616879a9a2";

export default node;
