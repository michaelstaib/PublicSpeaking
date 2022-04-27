/**
 * @generated SignedSource<<9c4441e0939de92dc07c5f03ba6b9f66>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Query } from 'relay-runtime';
import type { AlertsActionsAAFragment_asset$fragmentType } from "./AlertsActionsAAFragment_asset.graphql";
import type { AlertsActionsDAFragment_asset$fragmentType } from "./AlertsActionsDAFragment_asset.graphql";
export type AlertsContainerQuery$variables = {|
  symbol: string,
|};
export type AlertsContainerQuery$data = {|
  +assetBySymbol: ?{|
    +hasAlerts: boolean,
    +$fragmentSpreads: AlertsActionsAAFragment_asset$fragmentType & AlertsActionsDAFragment_asset$fragmentType,
  |},
|};
export type AlertsContainerQuery = {|
  variables: AlertsContainerQuery$variables,
  response: AlertsContainerQuery$data,
|};
*/

var node/*: ConcreteRequest*/ = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "symbol"
  }
],
v1 = [
  {
    "kind": "Variable",
    "name": "symbol",
    "variableName": "symbol"
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
  "name": "currency",
  "storageKey": null
},
v4 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "AlertsContainerQuery",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "Asset",
        "kind": "LinkedField",
        "name": "assetBySymbol",
        "plural": false,
        "selections": [
          (v2/*: any*/),
          {
            "args": null,
            "kind": "FragmentSpread",
            "name": "AlertsActionsAAFragment_asset"
          },
          {
            "args": null,
            "kind": "FragmentSpread",
            "name": "AlertsActionsDAFragment_asset"
          }
        ],
        "storageKey": null
      }
    ],
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Operation",
    "name": "AlertsContainerQuery",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "Asset",
        "kind": "LinkedField",
        "name": "assetBySymbol",
        "plural": false,
        "selections": [
          (v2/*: any*/),
          {
            "alias": null,
            "args": null,
            "concreteType": "AssetPrice",
            "kind": "LinkedField",
            "name": "price",
            "plural": false,
            "selections": [
              (v3/*: any*/),
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "lastPrice",
                "storageKey": null
              },
              (v4/*: any*/)
            ],
            "storageKey": null
          },
          {
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
                  (v4/*: any*/),
                  (v3/*: any*/),
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
          },
          (v4/*: any*/)
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "8d3700170cb62d30c8bcd5a0aa61de1f",
    "id": null,
    "metadata": {},
    "name": "AlertsContainerQuery",
    "operationKind": "query",
    "text": "query AlertsContainerQuery(\n  $symbol: String!\n) {\n  assetBySymbol(symbol: $symbol) {\n    hasAlerts\n    ...AlertsActionsAAFragment_asset\n    ...AlertsActionsDAFragment_asset\n    id\n  }\n}\n\nfragment AlertsActionsAAFragment_asset on Asset {\n  price {\n    currency\n    lastPrice\n    id\n  }\n}\n\nfragment AlertsActionsDAFragment_asset on Asset {\n  hasAlerts\n  alerts {\n    nodes {\n      id\n      currency\n      targetPrice\n      percentageChange\n      recurring\n    }\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "b9ccf4c28f97c4e9a3020898675bd2b0";

export default node;
