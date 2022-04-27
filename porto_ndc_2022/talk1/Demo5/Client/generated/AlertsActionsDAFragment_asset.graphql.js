/**
 * @generated SignedSource<<1b8ad6080551d2fd09c8d123029fee05>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { Fragment, ReaderFragment } from 'relay-runtime';
import type { FragmentType } from "relay-runtime";
declare export opaque type AlertsActionsDAFragment_asset$fragmentType: FragmentType;
export type AlertsActionsDAFragment_asset$data = {|
  +hasAlerts: boolean,
  +alerts: ?{|
    +nodes: ?$ReadOnlyArray<{|
      +id: string,
      +currency: string,
      +targetPrice: number,
      +percentageChange: number,
      +recurring: boolean,
    |}>,
  |},
  +$fragmentType: AlertsActionsDAFragment_asset$fragmentType,
|};
export type AlertsActionsDAFragment_asset$key = {
  +$data?: AlertsActionsDAFragment_asset$data,
  +$fragmentSpreads: AlertsActionsDAFragment_asset$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "AlertsActionsDAFragment_asset",
  "selections": [
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
      "concreteType": "AssetAlertsConnection",
      "kind": "LinkedField",
      "name": "alerts",
      "plural": false,
      "selections": [
        {
          "alias": null,
          "args": null,
          "concreteType": "Alert",
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
              "name": "targetPrice",
              "storageKey": null
            },
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
              "kind": "ScalarField",
              "name": "recurring",
              "storageKey": null
            }
          ],
          "storageKey": null
        }
      ],
      "storageKey": null
    }
  ],
  "type": "Asset",
  "abstractKey": null
};

(node/*: any*/).hash = "080afff84278c4c47872a0aaec910746";

export default node;
