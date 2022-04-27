/**
 * @generated SignedSource<<585f443e588ef03ec417afb17cac1f02>>
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
declare export opaque type DashboardSpotlightGainersFragment_query$fragmentType: FragmentType;
export type DashboardSpotlightGainersFragment_query$data = {|
  +gainers: ?{|
    +$fragmentSpreads: DashboardSpotlightCardFragment_asset$fragmentType,
  |},
  +$fragmentType: DashboardSpotlightGainersFragment_query$fragmentType,
|};
export type DashboardSpotlightGainersFragment_query$key = {
  +$data?: DashboardSpotlightGainersFragment_query$data,
  +$fragmentSpreads: DashboardSpotlightGainersFragment_query$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "DashboardSpotlightGainersFragment_query",
  "selections": [
    {
      "alias": "gainers",
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
              "change24Hour": "DESC"
            }
          }
        },
        {
          "kind": "Literal",
          "name": "where",
          "value": {
            "price": {
              "change24Hour": {
                "gt": 0
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
      "storageKey": "assets(first:5,order:{\"price\":{\"change24Hour\":\"DESC\"}},where:{\"price\":{\"change24Hour\":{\"gt\":0}}})"
    }
  ],
  "type": "Query",
  "abstractKey": null
};

(node/*: any*/).hash = "8524be778a4196c5e8b8d56d8d8bfee7";

export default node;
