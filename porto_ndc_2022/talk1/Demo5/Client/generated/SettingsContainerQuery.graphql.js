/**
 * @generated SignedSource<<209ad39deb7bef604bf502e896f9e111>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Query } from 'relay-runtime';
import type { SettingsProfileFragment_query$fragmentType } from "./SettingsProfileFragment_query.graphql";
export type SettingsContainerQuery$variables = {||};
export type SettingsContainerQuery$data = {|
  +$fragmentSpreads: SettingsProfileFragment_query$fragmentType,
|};
export type SettingsContainerQuery = {|
  variables: SettingsContainerQuery$variables,
  response: SettingsContainerQuery$data,
|};
*/

var node/*: ConcreteRequest*/ = {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "SettingsContainerQuery",
    "selections": [
      {
        "args": null,
        "kind": "FragmentSpread",
        "name": "SettingsProfileFragment_query"
      }
    ],
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "SettingsContainerQuery",
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
    ]
  },
  "params": {
    "cacheID": "3c305dd58e01fc7eb0971f73ca979d49",
    "id": null,
    "metadata": {},
    "name": "SettingsContainerQuery",
    "operationKind": "query",
    "text": "query SettingsContainerQuery {\n  ...SettingsProfileFragment_query\n}\n\nfragment SettingsProfileFragment_query on Query {\n  me {\n    id\n    name\n    displayName\n    imageUrl\n  }\n}\n"
  }
};

(node/*: any*/).hash = "6c34ee5545809f6e1770ecf4fb9a68a5";

export default node;
