/**
 * @generated SignedSource<<d02dff793dd8e5f772d461e71cc6f3ed>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { Fragment, ReaderFragment } from 'relay-runtime';
import type { FragmentType } from "relay-runtime";
declare export opaque type SettingsProfileFragment_query$fragmentType: FragmentType;
export type SettingsProfileFragment_query$data = {|
  +me: ?{|
    +id: string,
    +name: string,
    +displayName: ?string,
    +imageUrl: ?string,
  |},
  +$fragmentType: SettingsProfileFragment_query$fragmentType,
|};
export type SettingsProfileFragment_query$key = {
  +$data?: SettingsProfileFragment_query$data,
  +$fragmentSpreads: SettingsProfileFragment_query$fragmentType,
  ...
};
*/

var node/*: ReaderFragment*/ = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "SettingsProfileFragment_query",
  "selections": [
    {
      "alias": null,
      "args": null,
      "concreteType": "User",
      "kind": "LinkedField",
      "name": "me",
      "plural": false,
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
          "name": "name",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "displayName",
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "kind": "ScalarField",
          "name": "imageUrl",
          "storageKey": null
        }
      ],
      "storageKey": null
    }
  ],
  "type": "Query",
  "abstractKey": null
};

(node/*: any*/).hash = "44e477a33e75832ed8eac68415b459a6";

export default node;
