/**
 * @generated SignedSource<<ebe321dc3f7b44d5373570ef8c4dd96b>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { Fragment, ReaderFragment } from 'relay-runtime';
import type { FragmentType } from "relay-runtime";
declare export opaque type NotificationsListItemFragment_notification$fragmentType: FragmentType;
export type NotificationsListItemFragment_notification$data = {|
  +id: string,
  +message: ?string,
  +read: boolean,
  +asset: {|
    +symbol: string,
    +name: string,
    +imageUrl: ?string,
    +price: {|
      +currency: string,
      +lastPrice: number,
    |},
  |},
  +$fragmentType: NotificationsListItemFragment_notification$fragmentType,
|};
export type NotificationsListItemFragment_notification$key = {
  +$data?: NotificationsListItemFragment_notification$data,
  +$fragmentSpreads: NotificationsListItemFragment_notification$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "NotificationsListItemFragment_notification",
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
      "name": "message",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "read",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "concreteType": "Asset",
      "kind": "LinkedField",
      "name": "asset",
      "plural": false,
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
          "name": "name",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "imageUrl",
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
      "storageKey": null
    }
  ],
  "type": "Notification",
  "abstractKey": null
};

(node/*: any*/).hash = "e8bc540efb1bcd4d6c58053720454371";

export default node;
