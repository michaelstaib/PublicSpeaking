/**
 * @generated SignedSource<<3699babae7f4e2e294b2bab2b594aee5>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest, Mutation } from 'relay-runtime';
export type UpdateUserProfileInput = {|
  displayName?: ?string,
  image?: ?null,
|};
export type SettingsProfileUUPMutation$variables = {|
  input: UpdateUserProfileInput,
|};
export type SettingsProfileUUPMutation$data = {|
  +updateUserProfile: {|
    +updatedUser: ?{|
      +displayName: ?string,
      +imageUrl: ?string,
    |},
  |},
|};
export type SettingsProfileUUPMutation = {|
  variables: SettingsProfileUUPMutation$variables,
  response: SettingsProfileUUPMutation$data,
|};
*/

var node/*: ConcreteRequest*/ = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "input"
  }
],
v1 = [
  {
    "kind": "Variable",
    "name": "input",
    "variableName": "input"
  }
],
v2 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "displayName",
  "storageKey": null
},
v3 = {
  "alias": null,
  "args": null,
  "kind": "ScalarField",
  "name": "imageUrl",
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "SettingsProfileUUPMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "UpdateUserProfilePayload",
        "kind": "LinkedField",
        "name": "updateUserProfile",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "User",
            "kind": "LinkedField",
            "name": "updatedUser",
            "plural": false,
            "selections": [
              (v2/*: any*/),
              (v3/*: any*/)
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ],
    "type": "Mutation",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Operation",
    "name": "SettingsProfileUUPMutation",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "UpdateUserProfilePayload",
        "kind": "LinkedField",
        "name": "updateUserProfile",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "User",
            "kind": "LinkedField",
            "name": "updatedUser",
            "plural": false,
            "selections": [
              (v2/*: any*/),
              (v3/*: any*/),
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "id",
                "storageKey": null
              }
            ],
            "storageKey": null
          }
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "5465ae30971c9b3b44211dc703959812",
    "id": null,
    "metadata": {},
    "name": "SettingsProfileUUPMutation",
    "operationKind": "mutation",
    "text": "mutation SettingsProfileUUPMutation(\n  $input: UpdateUserProfileInput!\n) {\n  updateUserProfile(input: $input) {\n    updatedUser {\n      displayName\n      imageUrl\n      id\n    }\n  }\n}\n"
  }
};
})();

(node/*: any*/).hash = "dfb0375f9e1199ed14b99df82fdde270";

export default node;
