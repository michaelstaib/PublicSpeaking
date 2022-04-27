/**
 * @generated SignedSource<<afaf3ff36580e2467ec40a2375755e2a>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Query } from 'relay-runtime';
import type { FragmentType } from "relay-runtime";
import type { ViewerSnapshotFragment_price$fragmentType } from "./ViewerSnapshotFragment_price.graphql";
export type ChangeSpan = "ALL" | "DAY" | "HOUR" | "MONTH" | "WEEK" | "YEAR" | "%future added value";
export type ViewerSnapshotRefetchableQuery$variables = {|
  span?: ?ChangeSpan,
  id: string,
|};
export type ViewerSnapshotRefetchableQuery$data = {|
  +node: ?{|
    +$fragmentSpreads: ViewerSnapshotFragment_price$fragmentType,
  |},
|};
export type ViewerSnapshotRefetchableQuery = {|
  variables: ViewerSnapshotRefetchableQuery$variables,
  response: ViewerSnapshotRefetchableQuery$data,
|};
*/

var node/*: ConcreteRequest*/ = (function(){
var v0 = {
  "defaultValue": null,
  "kind": "LocalArgument",
  "name": "id"
},
v1 = {
  "defaultValue": "DAY",
  "kind": "LocalArgument",
  "name": "span"
},
v2 = [
  {
    "kind": "Variable",
    "name": "id",
    "variableName": "id"
  }
],
v3 = [
  {
    "kind": "Variable",
    "name": "span",
    "variableName": "span"
  }
],
v4 = {
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
    "name": "ViewerSnapshotRefetchableQuery",
    "selections": [
      {
        "alias": null,
        "args": (v2/*: any*/),
        "concreteType": null,
        "kind": "LinkedField",
        "name": "node",
        "plural": false,
        "selections": [
          {
            "args": (v3/*: any*/),
            "kind": "FragmentSpread",
            "name": "ViewerSnapshotFragment_price"
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
    "argumentDefinitions": [
      (v1/*: any*/),
      (v0/*: any*/)
    ],
    "kind": "Operation",
    "name": "ViewerSnapshotRefetchableQuery",
    "selections": [
      {
        "alias": null,
        "args": (v2/*: any*/),
        "concreteType": null,
        "kind": "LinkedField",
        "name": "node",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "__typename",
            "storageKey": null
          },
          (v4/*: any*/),
          {
            "kind": "InlineFragment",
            "selections": [
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
                "name": "lastPrice",
                "storageKey": null
              },
              {
                "alias": null,
                "args": (v3/*: any*/),
                "concreteType": "AssetPriceChange",
                "kind": "LinkedField",
                "name": "change",
                "plural": false,
                "selections": [
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
                    "concreteType": "HistoryConnection",
                    "kind": "LinkedField",
                    "name": "history",
                    "plural": false,
                    "selections": [
                      {
                        "alias": null,
                        "args": null,
                        "concreteType": "AssetPriceHistory",
                        "kind": "LinkedField",
                        "name": "nodes",
                        "plural": true,
                        "selections": [
                          {
                            "alias": null,
                            "args": null,
                            "kind": "ScalarField",
                            "name": "epoch",
                            "storageKey": null
                          },
                          {
                            "alias": null,
                            "args": null,
                            "kind": "ScalarField",
                            "name": "price",
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
            ],
            "type": "AssetPrice",
            "abstractKey": null
          }
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "e215f0850fd457c5ca1ffa318aad506f",
    "id": null,
    "metadata": {},
    "name": "ViewerSnapshotRefetchableQuery",
    "operationKind": "query",
    "text": "query ViewerSnapshotRefetchableQuery(\n  $span: ChangeSpan = DAY\n  $id: ID!\n) {\n  node(id: $id) {\n    __typename\n    ...ViewerSnapshotFragment_price_brhWz\n    id\n  }\n}\n\nfragment ViewerSnapshotFragment_price_brhWz on AssetPrice {\n  currency\n  lastPrice\n  change(span: $span) {\n    percentageChange\n    history {\n      nodes {\n        epoch\n        price\n      }\n    }\n    id\n  }\n  id\n}\n"
  }
};
})();

(node/*: any*/).hash = "92f04f73a86ad17b385a146cb370f432";

export default node;
