/**
 * @generated SignedSource<<0da7d5760debaac27484db1179cbe22c>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, GraphQLSubscription } from 'relay-runtime';
export type ChangeSpan = "ALL" | "DAY" | "HOUR" | "MONTH" | "WEEK" | "YEAR" | "%future added value";
export type ViewerSnapshotSubscription$variables = {|
  symbol: string,
  span: ChangeSpan,
|};
export type ViewerSnapshotSubscription$data = {|
  +onPriceChange: {|
    +lastPrice: number,
    +change: ?{|
      +percentageChange: number,
    |},
  |},
|};
export type ViewerSnapshotSubscription = {|
  variables: ViewerSnapshotSubscription$variables,
  response: ViewerSnapshotSubscription$data,
|};
*/

var node/*: ConcreteRequest*/ = (function(){
var v0 = {
  "defaultValue": null,
  "kind": "LocalArgument",
  "name": "span"
},
v1 = {
  "defaultValue": null,
  "kind": "LocalArgument",
  "name": "symbol"
},
v2 = [
  {
    "items": [
      {
        "kind": "Variable",
        "name": "symbols.0",
        "variableName": "symbol"
      }
    ],
    "kind": "ListValue",
    "name": "symbols"
  }
],
v3 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "lastPrice",
  "storageKey": null
},
v4 = [
  {
    "kind": "Variable",
    "name": "span",
    "variableName": "span"
  }
],
v5 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "percentageChange",
  "storageKey": null
},
v6 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": [
      (v0/*: any*/),
      (v1/*: any*/)
    ],
    "kind": "Fragment",
    "metadata": null,
    "name": "ViewerSnapshotSubscription",
    "selections": [
      {
        "alias": null,
        "args": (v2/*: any*/),
        "concreteType": "AssetPrice",
        "kind": "LinkedField",
        "name": "onPriceChange",
        "plural": false,
        "selections": [
          (v3/*: any*/),
          {
            "alias": null,
            "args": (v4/*: any*/),
            "concreteType": "AssetPriceChange",
            "kind": "LinkedField",
            "name": "change",
            "plural": false,
            "selections": [
              (v5/*: any*/)
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ],
    "type": "Subscription",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [
      (v1/*: any*/),
      (v0/*: any*/)
    ],
    "kind": "Operation",
    "name": "ViewerSnapshotSubscription",
    "selections": [
      {
        "alias": null,
        "args": (v2/*: any*/),
        "concreteType": "AssetPrice",
        "kind": "LinkedField",
        "name": "onPriceChange",
        "plural": false,
        "selections": [
          (v3/*: any*/),
          {
            "alias": null,
            "args": (v4/*: any*/),
            "concreteType": "AssetPriceChange",
            "kind": "LinkedField",
            "name": "change",
            "plural": false,
            "selections": [
              (v5/*: any*/),
              (v6/*: any*/)
            ],
            "storageKey": null
          },
          (v6/*: any*/)
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "cc4d756869d9aac2e9706758fbb7fff3",
    "id": null,
    "metadata": {},
    "name": "ViewerSnapshotSubscription",
    "operationKind": "subscription",
    "text": "subscription ViewerSnapshotSubscription(\n  $symbol: String!\n  $span: ChangeSpan!\n) {\n  onPriceChange(symbols: [$symbol]) {\n    lastPrice\n    change(span: $span) {\n      percentageChange\n      id\n    }\n    id\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "74a6145e6b027b40b0e0edd74ba07244";

export default node;
