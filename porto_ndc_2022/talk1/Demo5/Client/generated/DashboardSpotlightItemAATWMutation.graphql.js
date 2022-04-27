/**
 * @generated SignedSource<<5c89fbcba3e927fc8887a5fe744dcec3>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Mutation } from 'relay-runtime';
export type AddAssetToWatchlistInput = {|
  symbol: string,
|};
export type DashboardSpotlightItemAATWMutation$variables = {|
  input: AddAssetToWatchlistInput,
|};
export type DashboardSpotlightItemAATWMutation$data = {|
  +addAssetToWatchlist: {|
    +watchlist: ?{|
      +assets: ?{|
        +nodes: ?$ReadOnlyArray<{|
          +isInWatchlist: ?boolean,
        |}>,
      |},
    |},
  |},
|};
export type DashboardSpotlightItemAATWMutation = {|
  variables: DashboardSpotlightItemAATWMutation$variables,
  response: DashboardSpotlightItemAATWMutation$data,
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
  "name": "isInWatchlist",
  "storageKey": null
},
v3 = {
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
    "name": "DashboardSpotlightItemAATWMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "AddAssetToWatchlistPayload",
        "kind": "LinkedField",
        "name": "addAssetToWatchlist",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Watchlist",
            "kind": "LinkedField",
            "name": "watchlist",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "AssetsConnection",
                "kind": "LinkedField",
                "name": "assets",
                "plural": false,
                "selections": [
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "Asset",
                    "kind": "LinkedField",
                    "name": "nodes",
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
    "name": "DashboardSpotlightItemAATWMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "AddAssetToWatchlistPayload",
        "kind": "LinkedField",
        "name": "addAssetToWatchlist",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Watchlist",
            "kind": "LinkedField",
            "name": "watchlist",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "AssetsConnection",
                "kind": "LinkedField",
                "name": "assets",
                "plural": false,
                "selections": [
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "Asset",
                    "kind": "LinkedField",
                    "name": "nodes",
                    "plural": true,
                    "selections": [
                      (v2/*: any*/),
                      (v3/*: any*/)
                    ],
                    "storageKey": null
                  }
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
    "cacheID": "bdbf38341afd6a6748bb72a83c2489fb",
    "id": null,
    "metadata": {},
    "name": "DashboardSpotlightItemAATWMutation",
    "operationKind": "mutation",
    "text": "mutation DashboardSpotlightItemAATWMutation(\n  $input: AddAssetToWatchlistInput!\n) {\n  addAssetToWatchlist(input: $input) {\n    watchlist {\n      assets {\n        nodes {\n          isInWatchlist\n          id\n        }\n      }\n      id\n    }\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "4ee83c83a1c115bf65a9bc0b5e278e2a";

export default node;
