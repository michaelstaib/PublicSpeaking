/**
 * @generated SignedSource<<dcd8f9e545a082e73cf0c6a63c7a0500>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { Fragment, ReaderFragment } from 'relay-runtime';
import type { DashboardSpotlightCardFragment_asset$fragmentType } from "./DashboardSpotlightCardFragment_asset.graphql";
import type { FragmentType } from "relay-runtime";
declare export opaque type DashboardSpotlightLosersFragment_query$fragmentType: FragmentType;
export type DashboardSpotlightLosersFragment_query$data = {|
  +losers: ?{|
    +$fragmentSpreads: DashboardSpotlightCardFragment_asset$fragmentType,
  |},
  +$fragmentType: DashboardSpotlightLosersFragment_query$fragmentType,
|};
export type DashboardSpotlightLosersFragment_query$key = {
  +$data?: DashboardSpotlightLosersFragment_query$data,
  +$fragmentSpreads: DashboardSpotlightLosersFragment_query$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "DashboardSpotlightLosersFragment_query",
  "selections": [
    {
      "alias": "losers",
      "args": [
        {
          "kind": "Literal",
          "name": "first",
          "value": 5
        },
        {
          "kind": "Literal",
          "name": "order",
          "value": {
            "price": {
              "change24Hour": "ASC"
            }
          }
        },
        {
          "kind": "Literal",
          "name": "where",
          "value": {
            "price": {
              "change24Hour": {
                "lt": 0
              }
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
          "kind": "Defer",
          "selections": [
            {
              "args": null,
              "kind": "FragmentSpread",
              "name": "DashboardSpotlightCardFragment_asset"
            }
          ]
        }
      ],
      "storageKey": "assets(first:5,order:{\"price\":{\"change24Hour\":\"ASC\"}},where:{\"price\":{\"change24Hour\":{\"lt\":0}}})"
    }
  ],
  "type": "Query",
  "abstractKey": null
};

(node/*: any*/).hash = "19f11d0101e887bfd7c7dfb49ab9c2c0";

export default node;
