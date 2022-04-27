/**
 * @generated SignedSource<<75dd1791443c3509f90e19b2f5b1dd97>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { Fragment, ReaderFragment } from 'relay-runtime';
import type { DashboardFeaturedCardFragment_asset$fragmentType } from "./DashboardFeaturedCardFragment_asset.graphql";
import type { FragmentType } from "relay-runtime";
declare export opaque type DashboardFeaturedFragment_query$fragmentType: FragmentType;
export type DashboardFeaturedFragment_query$data = {|
  +featured: ?{|
    +nodes: ?$ReadOnlyArray<{|
      +id: string,
      +$fragmentSpreads: DashboardFeaturedCardFragment_asset$fragmentType,
    |}>,
  |},
  +$fragmentType: DashboardFeaturedFragment_query$fragmentType,
|};
export type DashboardFeaturedFragment_query$key = {
  +$data?: DashboardFeaturedFragment_query$data,
  +$fragmentSpreads: DashboardFeaturedFragment_query$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "DashboardFeaturedFragment_query",
  "selections": [
    {
      "alias": "featured",
      "args": [
        {
          "kind": "Literal",
          "name": "where",
          "value": {
            "symbol": {
              "in": [
                "BTC",
                "ADA",
                "ALGO"
              ]
            }
          }
        }
      ],
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
            {
              "alias": null,
              "args": null,
              "kind": "ScalarField",
              "name": "id",
              "storageKey": null
            },
            {
              "args": null,
              "kind": "FragmentSpread",
              "name": "DashboardFeaturedCardFragment_asset"
            }
          ],
          "storageKey": null
        }
      ],
      "storageKey": "assets(where:{\"symbol\":{\"in\":[\"BTC\",\"ADA\",\"ALGO\"]}})"
    }
  ],
  "type": "Query",
  "abstractKey": null
};

(node/*: any*/).hash = "0d35e9ce37c11408c4a6bbc1e0b27d9a";

export default node;
