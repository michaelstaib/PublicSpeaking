/**
 * @generated SignedSource<<382772fae8654519fbeafeb93ca77ac5>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { Fragment, ReaderFragment } from 'relay-runtime';
import type { FragmentType } from "relay-runtime";
declare export opaque type ViewerOverviewFragment_asset$fragmentType: FragmentType;
export type ViewerOverviewFragment_asset$data = {|
  +description: ?string,
  +$fragmentType: ViewerOverviewFragment_asset$fragmentType,
|};
export type ViewerOverviewFragment_asset$key = {
  +$data?: ViewerOverviewFragment_asset$data,
  +$fragmentSpreads: ViewerOverviewFragment_asset$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "ViewerOverviewFragment_asset",
  "selections": [
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "description",
      "storageKey": null
    }
  ],
  "type": "Asset",
  "abstractKey": null
};

(node/*: any*/).hash = "4a497ef77b1f964eafaee0d6d3490d85";

export default node;
