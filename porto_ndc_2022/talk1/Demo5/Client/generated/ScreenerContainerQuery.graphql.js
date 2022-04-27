/**
 * @generated SignedSource<<6176dd66825256b4d3c6fadbf0903c5d>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Query } from 'relay-runtime';
import type { ScreenerListFragment_query$fragmentType } from "./ScreenerListFragment_query.graphql";
export type ScreenerContainerQuery$variables = {||};
export type ScreenerContainerQuery$data = {|
  +$fragmentSpreads: ScreenerListFragment_query$fragmentType,
|};
export type ScreenerContainerQuery = {|
  variables: ScreenerContainerQuery$variables,
  response: ScreenerContainerQuery$data,
|};
*/

var node/*: ConcreteRequest*/ = (function(){
var v0 = [
  {
    "kind": "Literal",
    "name": "first",
    "value": 10
  },
  {
    "kind": "Literal",
    "name": "order",
    "value": {
      "price": {
        "marketCap": "DESC"
      }
    }
  }
],
v1 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "id",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "ScreenerContainerQuery",
    "selections": [
      {
        "args": null,
        "kind": "FragmentSpread",
        "name": "ScreenerListFragment_query"
      }
    ],
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "ScreenerContainerQuery",
    "selections": [
      {
        "alias": null,
        "args": (v0/*: any*/),
        "concreteType": "AssetsConnection",
        "kind": "LinkedField",
        "name": "assets",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "AssetsEdge",
            "kind": "LinkedField",
            "name": "edges",
            "plural": true,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "Asset",
                "kind": "LinkedField",
                "name": "node",
                "plural": false,
                "selections": [
                  (v1/*: any*/),
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "symbol",
                    "storageKey": null
                  },
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "name",
                    "storageKey": null
                  },
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "imageUrl",
                    "storageKey": null
                  },
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "isInWatchlist",
                    "storageKey": null
                  },
                  {
                    "alias": null,
                    "args": null,
                    "concreteType": "AssetPrice",
                    "kind": "LinkedField",
                    "name": "price",
                    "plural": false,
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
                        "args": null,
                        "kind": "ScalarField",
                        "name": "change24Hour",
                        "storageKey": null
                      },
                      {
                        "alias": null,
                        "args": null,
                        "kind": "ScalarField",
                        "name": "marketCap",
                        "storageKey": null
                      },
                      (v1/*: any*/)
                    ],
                    "storageKey": null
                  },
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "__typename",
                    "storageKey": null
                  }
                ],
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "cursor",
                "storageKey": null
              }
            ],
            "storageKey": null
          },
          {
            "alias": null,
            "args": null,
            "concreteType": "PageInfo",
            "kind": "LinkedField",
            "name": "pageInfo",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "endCursor",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "hasNextPage",
                "storageKey": null
              }
            ],
            "storageKey": null
          }
        ],
        "storageKey": "assets(first:10,order:{\"price\":{\"marketCap\":\"DESC\"}})"
      },
      {
        "alias": null,
        "args": (v0/*: any*/),
        "filters": [
          "where",
          "order"
        ],
        "handle": "connection",
        "key": "ScreenerList_assets",
        "kind": "LinkedHandle",
        "name": "assets"
      }
    ]
  },
  "params": {
    "cacheID": "492d28fc64bcbdbd430058c60eb38491",
    "id": null,
    "metadata": {},
    "name": "ScreenerContainerQuery",
    "operationKind": "query",
    "text": "query ScreenerContainerQuery {\n  ...ScreenerListFragment_query\n}\n\nfragment ScreenerListFragment_query on Query {\n  assets(first: 10, order: {price: {marketCap: DESC}}) {\n    edges {\n      node {\n        id\n        ...ScreenerListItemFragment_asset\n        __typename\n      }\n      cursor\n    }\n    pageInfo {\n      endCursor\n      hasNextPage\n    }\n  }\n}\n\nfragment ScreenerListItemFragment_asset on Asset {\n  id\n  symbol\n  name\n  imageUrl\n  isInWatchlist\n  price {\n    currency\n    lastPrice\n    change24Hour\n    marketCap\n    id\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "c90dc624939d180141b397f1a9deeb85";

export default node;
