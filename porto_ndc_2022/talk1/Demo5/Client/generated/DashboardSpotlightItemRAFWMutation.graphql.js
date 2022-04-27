/**
 * @generated SignedSource<<ef85392ff89f3814e3d6f5d96b52dab3>>
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
export type DashboardSpotlightItemRAFWMutation$variables = {|
  input: RemoveAssetFromWatchlistInput,
|};
export type DashboardSpotlightItemRAFWMutation$data = {|
  +removeAssetFromWatchlist: {|
    +removedAsset: ?{|
      +isInWatchlist: ?boolean,
    |},
  |},
|};
export type DashboardSpotlightItemRAFWMutation = {|
  variables: DashboardSpotlightItemRAFWMutation$variables,
  response: DashboardSpotlightItemRAFWMutation$data,
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
    "name": "DashboardSpotlightItemRAFWMutation",
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
    "name": "DashboardSpotlightItemRAFWMutation",
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
    "cacheID": "60ed51f0b6702a39d92a34f8ff578106",
    "id": null,
    "metadata": {},
    "name": "DashboardSpotlightItemRAFWMutation",
    "operationKind": "mutation",
    "text": "mutation DashboardSpotlightItemRAFWMutation(\n  $input: RemoveAssetFromWatchlistInput!\n) {\n  removeAssetFromWatchlist(input: $input) {\n    removedAsset {\n      isInWatchlist\n      id\n    }\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "60863eaa03ebbbbac4b6b845f1222bc8";

export default node;
