/**
 * @generated SignedSource<<9f4a8df751c62b81c5ae8619f9bb9744>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Mutation } from 'relay-runtime';
export type RemoveAssetFromWatchlistInput = {|
  symbol: string,
|};
export type WatchlistListItemRAFWMutation$variables = {|
  input: RemoveAssetFromWatchlistInput,
|};
export type WatchlistListItemRAFWMutation$data = {|
  +removeAssetFromWatchlist: {|
    +removedAsset: ?{|
      +isInWatchlist: ?boolean,
    |},
  |},
|};
export type WatchlistListItemRAFWMutation = {|
  variables: WatchlistListItemRAFWMutation$variables,
  response: WatchlistListItemRAFWMutation$data,
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
};
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "WatchlistListItemRAFWMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "RemoveAssetFromWatchlistPayload",
        "kind": "LinkedField",
        "name": "removeAssetFromWatchlist",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Asset",
            "kind": "LinkedField",
            "name": "removedAsset",
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
    "name": "WatchlistListItemRAFWMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "RemoveAssetFromWatchlistPayload",
        "kind": "LinkedField",
        "name": "removeAssetFromWatchlist",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "Asset",
            "kind": "LinkedField",
            "name": "removedAsset",
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
    "cacheID": "759a4edf3ea8def0f3bba619ecee452c",
    "id": null,
    "metadata": {},
    "name": "WatchlistListItemRAFWMutation",
    "operationKind": "mutation",
    "text": "mutation WatchlistListItemRAFWMutation(\n  $input: RemoveAssetFromWatchlistInput!\n) {\n  removeAssetFromWatchlist(input: $input) {\n    removedAsset {\n      isInWatchlist\n      id\n    }\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "0d0063e59a05958a587181c2e464cc86";

export default node;
