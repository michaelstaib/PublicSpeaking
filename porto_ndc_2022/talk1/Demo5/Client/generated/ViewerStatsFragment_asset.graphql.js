/**
 * @generated SignedSource<<35b841bc9e8289ff9da24d1d34382b99>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { Fragment, ReaderFragment } from 'relay-runtime';
import type { FragmentType } from "relay-runtime";
declare export opaque type ViewerStatsFragment_asset$fragmentType: FragmentType;
export type ViewerStatsFragment_asset$data = {|
  +price: {|
    +currency: string,
    +marketCap: number,
    +volume24Hour: number,
    +volumePercentChange24Hour: number,
    +maxSupply: number,
    +circulatingSupply: number,
    +tradingActivity: number,
    +tradableMarketCapRank: number,
  |},
  +$fragmentType: ViewerStatsFragment_asset$fragmentType,
|};
export type ViewerStatsFragment_asset$key = {
  +$data?: ViewerStatsFragment_asset$data,
  +$fragmentSpreads: ViewerStatsFragment_asset$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "ViewerStatsFragment_asset",
  "selections": [
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
    }
  ],
  "type": "Asset",
  "abstractKey": null
};

(node/*: any*/).hash = "665255c3e58189f68d75003981770f1f";

export default node;
