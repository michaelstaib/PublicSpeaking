/**
 * @generated SignedSource<<429ccee1ce9acd71706e8ff1c4e39d68>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { Fragment, ReaderFragment } from 'relay-runtime';
import type { ViewerSnapshotFragment_price$fragmentType } from "./ViewerSnapshotFragment_price.graphql";
import type { FragmentType } from "relay-runtime";
declare export opaque type ViewerSnapshotFragment_asset$fragmentType: FragmentType;
export type ViewerSnapshotFragment_asset$data = {|
  +symbol: string,
  +color: string,
  +price: {|
    +$fragmentSpreads: ViewerSnapshotFragment_price$fragmentType,
  |},
  +$fragmentType: ViewerSnapshotFragment_asset$fragmentType,
|};
export type ViewerSnapshotFragment_asset$key = {
  +$data?: ViewerSnapshotFragment_asset$data,
  +$fragmentSpreads: ViewerSnapshotFragment_asset$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "ViewerSnapshotFragment_asset",
  "selections": [
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
          "args": null,
          "kind": "FragmentSpread",
          "name": "ViewerSnapshotFragment_price"
        }
      ],
      "storageKey": null
    }
  ],
  "type": "Asset",
  "abstractKey": null
};

(node/*: any*/).hash = "462507023398de412e8025ba261f72bd";

export default node;
