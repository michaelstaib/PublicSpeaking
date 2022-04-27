/**
 * @generated SignedSource<<cc53bd479e00b2f224ffc5ad330a33f2>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { Fragment, ReaderFragment } from 'relay-runtime';
import type { DashboardSpotlightGainersFragment_query$fragmentType } from "./DashboardSpotlightGainersFragment_query.graphql";
import type { DashboardSpotlightLosersFragment_query$fragmentType } from "./DashboardSpotlightLosersFragment_query.graphql";
import type { FragmentType } from "relay-runtime";
declare export opaque type DashboardSpotlightFragment_query$fragmentType: FragmentType;
export type DashboardSpotlightFragment_query$data = {|
  +$fragmentSpreads: DashboardSpotlightGainersFragment_query$fragmentType & DashboardSpotlightLosersFragment_query$fragmentType,
  +$fragmentType: DashboardSpotlightFragment_query$fragmentType,
|};
export type DashboardSpotlightFragment_query$key = {
  +$data?: DashboardSpotlightFragment_query$data,
  +$fragmentSpreads: DashboardSpotlightFragment_query$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "DashboardSpotlightFragment_query",
  "selections": [
    {
      "args": null,
      "kind": "FragmentSpread",
      "name": "DashboardSpotlightGainersFragment_query"
    },
    {
      "args": null,
      "kind": "FragmentSpread",
      "name": "DashboardSpotlightLosersFragment_query"
    }
  ],
  "type": "Query",
  "abstractKey": null
};

(node/*: any*/).hash = "464d0a49a14335a60f0253914af8fd9e";

export default node;
