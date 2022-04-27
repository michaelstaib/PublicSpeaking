/**
 * @generated SignedSource<<6a665444c02091a6a758714b47e43636>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { Fragment, ReaderFragment } from 'relay-runtime';
import type { FragmentType } from "relay-runtime";
declare export opaque type AlertsActionsAAFragment_asset$fragmentType: FragmentType;
export type AlertsActionsAAFragment_asset$data = {|
  +price: {|
    +currency: string,
    +lastPrice: number,
  |},
  +$fragmentType: AlertsActionsAAFragment_asset$fragmentType,
|};
export type AlertsActionsAAFragment_asset$key = {
  +$data?: AlertsActionsAAFragment_asset$data,
  +$fragmentSpreads: AlertsActionsAAFragment_asset$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "AlertsActionsAAFragment_asset",
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
          "name": "lastPrice",
          "storageKey": null
        }
      ],
      "storageKey": null
    }
  ],
  "type": "Asset",
  "abstractKey": null
};

(node/*: any*/).hash = "035ad6d339f50f68a2191741f786b006";

export default node;
