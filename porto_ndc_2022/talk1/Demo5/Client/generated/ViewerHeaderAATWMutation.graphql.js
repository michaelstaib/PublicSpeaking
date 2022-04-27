/**
 * @generated SignedSource<<6161465e8cbdfac0074e8ef29263b5ce>>
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
export type ViewerHeaderAATWMutation$variables = {|
  input: AddAssetToWatchlistInput,
|};
export type ViewerHeaderAATWMutation$data = {|
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
export type ViewerHeaderAATWMutation = {|
  variables: ViewerHeaderAATWMutation$variables,
  response: ViewerHeaderAATWMutation$data,
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
    "name": "ViewerHeaderAATWMutation",
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
    "name": "ViewerHeaderAATWMutation",
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
    "cacheID": "1d939b1a5a5e211c40e7802bd52e4f4e",
    "id": null,
    "metadata": {},
    "name": "ViewerHeaderAATWMutation",
    "operationKind": "mutation",
    "text": "mutation ViewerHeaderAATWMutation(\n  $input: AddAssetToWatchlistInput!\n) {\n  addAssetToWatchlist(input: $input) {\n    watchlist {\n      assets {\n        nodes {\n          isInWatchlist\n          id\n        }\n      }\n      id\n    }\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "949249bf7a15677ec04ab5b09cd090cf";

export default node;
