/**
 * @generated SignedSource<<70380df7fd2a998f3e360d0efb557ef4>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { Fragment, ReaderFragment } from 'relay-runtime';
import type { FragmentType } from "relay-runtime";
declare export opaque type ViewerHeaderFragment_asset$fragmentType: FragmentType;
export type ViewerHeaderFragment_asset$data = {|
  +id: string,
  +symbol: string,
  +name: string,
  +imageUrl: ?string,
  +isInWatchlist: ?boolean,
  +hasAlerts: boolean,
  +$fragmentType: ViewerHeaderFragment_asset$fragmentType,
|};
export type ViewerHeaderFragment_asset$key = {
  +$data?: ViewerHeaderFragment_asset$data,
  +$fragmentSpreads: ViewerHeaderFragment_asset$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "ViewerHeaderFragment_asset",
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
      "kind": "ScalarField",
      "name": "isInWatchlist",
      "storageKey": null
    },
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "hasAlerts",
      "storageKey": null
    }
  ],
  "type": "Asset",
  "abstractKey": null
};

(node/*: any*/).hash = "c9c29a12a666f2a95958709da29c6908";

export default node;
