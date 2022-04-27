/**
 * @generated SignedSource<<b9603f99a0755ed76039a7bffd7f2a5d>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { Fragment, ReaderFragment } from 'relay-runtime';
import type { DashboardSpotlightItemFragment_asset$fragmentType } from "./DashboardSpotlightItemFragment_asset.graphql";
import type { FragmentType } from "relay-runtime";
declare export opaque type DashboardSpotlightCardFragment_asset$fragmentType: FragmentType;
export type DashboardSpotlightCardFragment_asset$data = {|
  +nodes: ?$ReadOnlyArray<{|
    +id: string,
    +$fragmentSpreads: DashboardSpotlightItemFragment_asset$fragmentType,
  |}>,
  +$fragmentType: DashboardSpotlightCardFragment_asset$fragmentType,
|};
export type DashboardSpotlightCardFragment_asset$key = {
  +$data?: DashboardSpotlightCardFragment_asset$data,
  +$fragmentSpreads: DashboardSpotlightCardFragment_asset$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "DashboardSpotlightCardFragment_asset",
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
          "name": "DashboardSpotlightItemFragment_asset"
        }
      ],
      "storageKey": null
    }
  ],
  "type": "AssetsConnection",
  "abstractKey": null
};

(node/*: any*/).hash = "1af28335a4d097776754c36ec2e715de";

export default node;
