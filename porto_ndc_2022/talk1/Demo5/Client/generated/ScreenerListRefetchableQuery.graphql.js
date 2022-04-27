/**
 * @generated SignedSource<<8bf27bfdf3003a8ce6eee8e557c25d7c>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Query } from 'relay-runtime';
import type { FragmentType } from "relay-runtime";
import type { ScreenerListFragment_query$fragmentType } from "./ScreenerListFragment_query.graphql";
export type SortEnumType = "ASC" | "DESC" | "%future added value";
export type AssetSortInput = {|
  name?: ?SortEnumType,
  price?: ?AssetPriceSortInput,
  slug?: ?SortEnumType,
  symbol?: ?SortEnumType,
|};
export type AssetPriceSortInput = {|
  asset?: ?AssetSortInput,
  assetId?: ?SortEnumType,
  change24Hour?: ?SortEnumType,
  circulatingSupply?: ?SortEnumType,
  currency?: ?SortEnumType,
  high24Hour?: ?SortEnumType,
  id?: ?SortEnumType,
  lastPrice?: ?SortEnumType,
  low24Hour?: ?SortEnumType,
  marketCap?: ?SortEnumType,
  maxSupply?: ?SortEnumType,
  modifiedAt?: ?SortEnumType,
  open24Hour?: ?SortEnumType,
  symbol?: ?SortEnumType,
  tradableMarketCapRank?: ?SortEnumType,
  tradingActivity?: ?SortEnumType,
  volume24Hour?: ?SortEnumType,
  volumePercentChange24Hour?: ?SortEnumType,
|};
export type AssetFilterInput = {|
  and?: ?$ReadOnlyArray<AssetFilterInput>,
  description?: ?StringOperationFilterInput,
  name?: ?StringOperationFilterInput,
  or?: ?$ReadOnlyArray<AssetFilterInput>,
  price?: ?AssetPriceFilterInput,
  slug?: ?StringOperationFilterInput,
  symbol?: ?StringOperationFilterInput,
  website?: ?StringOperationFilterInput,
|};
export type StringOperationFilterInput = {|
  and?: ?$ReadOnlyArray<StringOperationFilterInput>,
  contains?: ?string,
  endsWith?: ?string,
  eq?: ?string,
  in?: ?$ReadOnlyArray<?string>,
  ncontains?: ?string,
  nendsWith?: ?string,
  neq?: ?string,
  nin?: ?$ReadOnlyArray<?string>,
  nstartsWith?: ?string,
  or?: ?$ReadOnlyArray<StringOperationFilterInput>,
  startsWith?: ?string,
|};
export type AssetPriceFilterInput = {|
  and?: ?$ReadOnlyArray<AssetPriceFilterInput>,
  asset?: ?AssetFilterInput,
  assetId?: ?ComparableInt32OperationFilterInput,
  change24Hour?: ?ComparableDoubleOperationFilterInput,
  circulatingSupply?: ?ComparableDoubleOperationFilterInput,
  currency?: ?StringOperationFilterInput,
  high24Hour?: ?ComparableDoubleOperationFilterInput,
  id?: ?ComparableInt32OperationFilterInput,
  lastPrice?: ?ComparableDoubleOperationFilterInput,
  low24Hour?: ?ComparableDoubleOperationFilterInput,
  marketCap?: ?ComparableDoubleOperationFilterInput,
  maxSupply?: ?ComparableDoubleOperationFilterInput,
  modifiedAt?: ?ComparableNullableOfDateTimeOperationFilterInput,
  open24Hour?: ?ComparableDoubleOperationFilterInput,
  or?: ?$ReadOnlyArray<AssetPriceFilterInput>,
  symbol?: ?StringOperationFilterInput,
  tradableMarketCapRank?: ?ComparableDoubleOperationFilterInput,
  tradingActivity?: ?ComparableDoubleOperationFilterInput,
  volume24Hour?: ?ComparableDoubleOperationFilterInput,
  volumePercentChange24Hour?: ?ComparableDoubleOperationFilterInput,
|};
export type ComparableInt32OperationFilterInput = {|
  eq?: ?number,
  gt?: ?number,
  gte?: ?number,
  in?: ?$ReadOnlyArray<number>,
  lt?: ?number,
  lte?: ?number,
  neq?: ?number,
  ngt?: ?number,
  ngte?: ?number,
  nin?: ?$ReadOnlyArray<number>,
  nlt?: ?number,
  nlte?: ?number,
|};
export type ComparableDoubleOperationFilterInput = {|
  eq?: ?number,
  gt?: ?number,
  gte?: ?number,
  in?: ?$ReadOnlyArray<number>,
  lt?: ?number,
  lte?: ?number,
  neq?: ?number,
  ngt?: ?number,
  ngte?: ?number,
  nin?: ?$ReadOnlyArray<number>,
  nlt?: ?number,
  nlte?: ?number,
|};
export type ComparableNullableOfDateTimeOperationFilterInput = {|
  eq?: ?String,
  gt?: ?String,
  gte?: ?String,
  in?: ?$ReadOnlyArray<?String>,
  lt?: ?String,
  lte?: ?String,
  neq?: ?String,
  ngt?: ?String,
  ngte?: ?String,
  nin?: ?$ReadOnlyArray<?String>,
  nlt?: ?String,
  nlte?: ?String,
|};
export type ScreenerListRefetchableQuery$variables = {|
  count?: ?number,
  cursor?: ?string,
  order?: ?$ReadOnlyArray<AssetSortInput>,
  where?: ?AssetFilterInput,
|};
export type ScreenerListRefetchableQuery$data = {|
  +$fragmentSpreads: ScreenerListFragment_query$fragmentType,
|};
export type ScreenerListRefetchableQuery = {|
  variables: ScreenerListRefetchableQuery$variables,
  response: ScreenerListRefetchableQuery$data,
|};
*/

var node/*: ConcreteRequest*/ = (function(){
var v0 = [
  {
    "defaultValue": 10,
    "kind": "LocalArgument",
    "name": "count"
  },
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "cursor"
  },
  {
    "defaultValue": {
      "price": {
        "marketCap": "DESC"
      }
    },
    "kind": "LocalArgument",
    "name": "order"
  },
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "where"
  }
],
v1 = {
  "kind": "Variable",
  "name": "order",
  "variableName": "order"
},
v2 = {
  "kind": "Variable",
  "name": "where",
  "variableName": "where"
},
v3 = [
  {
    "kind": "Variable",
    "name": "after",
    "variableName": "cursor"
  },
  {
    "kind": "Variable",
    "name": "first",
    "variableName": "count"
  },
  (v1/*: any*/),
  (v2/*: any*/)
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
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "ScreenerListRefetchableQuery",
    "selections": [
      {
        "args": [
          {
            "kind": "Variable",
            "name": "count",
            "variableName": "count"
          },
          {
            "kind": "Variable",
            "name": "cursor",
            "variableName": "cursor"
          },
          (v1/*: any*/),
          (v2/*: any*/)
        ],
        "kind": "FragmentSpread",
        "name": "ScreenerListFragment_query"
      }
    ],
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Operation",
    "name": "ScreenerListRefetchableQuery",
    "selections": [
      {
        "alias": null,
        "args": (v3/*: any*/),
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
                  (v4/*: any*/),
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
                      (v4/*: any*/)
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
        "storageKey": null
      },
      {
        "alias": null,
        "args": (v3/*: any*/),
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
    "cacheID": "39c80309903fdd0eb6fc6fc7020847b5",
    "id": null,
    "metadata": {},
    "name": "ScreenerListRefetchableQuery",
    "operationKind": "query",
    "text": "query ScreenerListRefetchableQuery(\n  $count: Int = 10\n  $cursor: String\n  $order: [AssetSortInput!] = {price: {marketCap: DESC}}\n  $where: AssetFilterInput\n) {\n  ...ScreenerListFragment_query_2KVBjJ\n}\n\nfragment ScreenerListFragment_query_2KVBjJ on Query {\n  assets(after: $cursor, first: $count, where: $where, order: $order) {\n    edges {\n      node {\n        id\n        ...ScreenerListItemFragment_asset\n        __typename\n      }\n      cursor\n    }\n    pageInfo {\n      endCursor\n      hasNextPage\n    }\n  }\n}\n\nfragment ScreenerListItemFragment_asset on Asset {\n  id\n  symbol\n  name\n  imageUrl\n  isInWatchlist\n  price {\n    currency\n    lastPrice\n    change24Hour\n    marketCap\n    id\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "35a34d660d7155895c77082e8a7c5436";

export default node;
