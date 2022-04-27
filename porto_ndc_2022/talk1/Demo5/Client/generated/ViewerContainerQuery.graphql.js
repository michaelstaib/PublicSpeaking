/**
 * @generated SignedSource<<add5285301080d3100264cd8a9680cf5>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Query } from 'relay-runtime';
import type { ViewerHeaderFragment_asset$fragmentType } from "./ViewerHeaderFragment_asset.graphql";
import type { ViewerOverviewFragment_asset$fragmentType } from "./ViewerOverviewFragment_asset.graphql";
import type { ViewerResourcesFragment_asset$fragmentType } from "./ViewerResourcesFragment_asset.graphql";
import type { ViewerSnapshotFragment_asset$fragmentType } from "./ViewerSnapshotFragment_asset.graphql";
import type { ViewerStatsFragment_asset$fragmentType } from "./ViewerStatsFragment_asset.graphql";
export type ViewerContainerQuery$variables = {|
  symbol: string,
|};
export type ViewerContainerQuery$data = {|
  +assetBySymbol: ?{|
    +$fragmentSpreads: ViewerHeaderFragment_asset$fragmentType & ViewerSnapshotFragment_asset$fragmentType & ViewerStatsFragment_asset$fragmentType & ViewerOverviewFragment_asset$fragmentType & ViewerResourcesFragment_asset$fragmentType,
  |},
|};
export type ViewerContainerQuery = {|
  variables: ViewerContainerQuery$variables,
  response: ViewerContainerQuery$data,
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
  "name": "id",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "ViewerContainerQuery",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "Asset",
        "kind": "LinkedField",
        "name": "assetBySymbol",
        "plural": false,
        "selections": [
          {
            "args": null,
            "kind": "FragmentSpread",
            "name": "ViewerHeaderFragment_asset"
          },
          {
            "args": null,
            "kind": "FragmentSpread",
            "name": "ViewerSnapshotFragment_asset"
          },
          {
            "args": null,
            "kind": "FragmentSpread",
            "name": "ViewerStatsFragment_asset"
          },
          {
            "args": null,
            "kind": "FragmentSpread",
            "name": "ViewerOverviewFragment_asset"
          },
          {
            "args": null,
            "kind": "FragmentSpread",
            "name": "ViewerResourcesFragment_asset"
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
    "name": "ViewerContainerQuery",
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
            "kind": "ScalarField",
            "name": "hasAlerts",
            "storageKey": null
          },
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "color",
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
                "args": [
                  {
                    "kind": "Literal",
                    "name": "span",
                    "value": "DAY"
                  }
                ],
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
                  (v2/*: any*/)
                ],
                "storageKey": "change(span:\"DAY\")"
              },
              (v2/*: any*/),
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "marketCap",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "volume24Hour",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "volumePercentChange24Hour",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "maxSupply",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "circulatingSupply",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "tradingActivity",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "tradableMarketCapRank",
                "storageKey": null
              }
            ],
            "storageKey": null
          },
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "description",
            "storageKey": null
          },
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "website",
            "storageKey": null
          },
          {
            "alias": null,
            "args": null,
            "kind": "ScalarField",
            "name": "whitePaper",
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "22dcf112fafe0d1c752015618d0702ef",
    "id": null,
    "metadata": {},
    "name": "ViewerContainerQuery",
    "operationKind": "query",
    "text": "query ViewerContainerQuery(\n  $symbol: String!\n) {\n  assetBySymbol(symbol: $symbol) {\n    ...ViewerHeaderFragment_asset\n    ...ViewerSnapshotFragment_asset\n    ...ViewerStatsFragment_asset\n    ...ViewerOverviewFragment_asset\n    ...ViewerResourcesFragment_asset\n    id\n  }\n}\n\nfragment ViewerHeaderFragment_asset on Asset {\n  id\n  symbol\n  name\n  imageUrl\n  isInWatchlist\n  hasAlerts\n}\n\nfragment ViewerOverviewFragment_asset on Asset {\n  description\n}\n\nfragment ViewerResourcesFragment_asset on Asset {\n  website\n  whitePaper\n}\n\nfragment ViewerSnapshotFragment_asset on Asset {\n  symbol\n  color\n  price {\n    ...ViewerSnapshotFragment_price\n    id\n  }\n}\n\nfragment ViewerSnapshotFragment_price on AssetPrice {\n  currency\n  lastPrice\n  change(span: DAY) {\n    percentageChange\n    history {\n      nodes {\n        epoch\n        price\n      }\n    }\n    id\n  }\n  id\n}\n\nfragment ViewerStatsFragment_asset on Asset {\n  price {\n    currency\n    marketCap\n    volume24Hour\n    volumePercentChange24Hour\n    maxSupply\n    circulatingSupply\n    tradingActivity\n    tradableMarketCapRank\n    id\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "c51a6066c025de0209dec5f13da460ef";

export default node;
