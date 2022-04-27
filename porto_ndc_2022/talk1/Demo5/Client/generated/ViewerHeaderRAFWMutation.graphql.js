/**
 * @generated SignedSource<<24c4a0304fa5cefe7b050ace9f676db8>>
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
export type ViewerHeaderRAFWMutation$variables = {|
  input: RemoveAssetFromWatchlistInput,
|};
export type ViewerHeaderRAFWMutation$data = {|
  +removeAssetFromWatchlist: {|
    +removedAsset: ?{|
      +isInWatchlist: ?boolean,
    |},
  |},
|};
export type ViewerHeaderRAFWMutation = {|
  variables: ViewerHeaderRAFWMutation$variables,
  response: ViewerHeaderRAFWMutation$data,
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
    "name": "ViewerHeaderRAFWMutation",
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
    "name": "ViewerHeaderRAFWMutation",
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
    "cacheID": "70be11a2bc64ceda2ae325f4fb1649a7",
    "id": null,
    "metadata": {},
    "name": "ViewerHeaderRAFWMutation",
    "operationKind": "mutation",
    "text": "mutation ViewerHeaderRAFWMutation(\n  $input: RemoveAssetFromWatchlistInput!\n) {\n  removeAssetFromWatchlist(input: $input) {\n    removedAsset {\n      isInWatchlist\n      id\n    }\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "d1e28e565928844f4126fe9700035b53";

export default node;
