/**
 * @generated SignedSource<<c866ceaa670456f3132d1c1c04c0533b>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ReaderFragment, RefetchableFragment } from 'relay-runtime';
import type { ScreenerListItemFragment_asset$fragmentType } from "./ScreenerListItemFragment_asset.graphql";
import type { FragmentType } from "relay-runtime";
declare export opaque type ScreenerListFragment_query$fragmentType: FragmentType;
import type { ScreenerListRefetchableQuery$variables } from "./ScreenerListRefetchableQuery.graphql";
export type ScreenerListFragment_query$data = {|
  +assets: ?{|
    +edges: ?$ReadOnlyArray<{|
      +node: {|
        +id: string,
        +$fragmentSpreads: ScreenerListItemFragment_asset$fragmentType,
      |},
    |}>,
  |},
  +$fragmentType: ScreenerListFragment_query$fragmentType,
|};
export type ScreenerListFragment_query$key = {
  +$data?: ScreenerListFragment_query$data,
  +$fragmentSpreads: ScreenerListFragment_query$fragmentType,
  ...
};
*/

import ScreenerListRefetchableQuery_graphql from './ScreenerListRefetchableQuery.graphql';
var node/*: ReaderFragment*/ = (function(){
var v0 = [
  "assets"
];
return {
  "argumentDefinitions": [
    {
      "defaultValue": 10,
      "kind": "LocalArgument",
      "name": "count"
    },
    {
      "defaultValue": null,
      "kind": "LocalArgument",
      "name": "cursor"
    },
    {
      "defaultValue": {
        "price": {
          "marketCap": "DESC"
        }
      },
      "kind": "LocalArgument",
      "name": "order"
    },
    {
      "defaultValue": null,
      "kind": "LocalArgument",
      "name": "where"
    }
  ],
  "kind": "Fragment",
  "metadata": {
    "connection": [
      {
        "count": "count",
        "cursor": "cursor",
        "direction": "forward",
        "path": (v0/*: any*/)
      }
    ],
    "refetch": {
      "connection": {
        "forward": {
          "count": "count",
          "cursor": "cursor"
        },
        "backward": null,
        "path": (v0/*: any*/)
      },
      "fragmentPathInResult": [],
      "operation": ScreenerListRefetchableQuery_graphql
    }
  },
  "name": "ScreenerListFragment_query",
  "selections": [
    {
      "alias": "assets",
      "args": [
        {
          "kind": "Variable",
          "name": "order",
          "variableName": "order"
        },
        {
          "kind": "Variable",
          "name": "where",
          "variableName": "where"
        }
      ],
      "concreteType": "AssetsConnection",
      "kind": "LinkedField",
      "name": "__ScreenerList_assets_connection",
      "plural": false,
      "selections": [
        {
          "alias": null,
          "args": null,
          "concreteType": "AssetsEdge",
          "kind": "LinkedField",
          "name": "edges",
          "plural": true,
          "selections": [
            {
              "alias": null,
              "args": null,
              "concreteType": "Asset",
              "kind": "LinkedField",
              "name": "node",
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
                  "args": null,
                  "kind": "FragmentSpread",
                  "name": "ScreenerListItemFragment_asset"
                },
                {
                  "alias": null,
                  "args": null,
                  "kind": "ScalarField",
                  "name": "__typename",
                  "storageKey": null
                }
              ],
              "storageKey": null
            },
            {
              "alias": null,
              "args": null,
              "kind": "ScalarField",
              "name": "cursor",
              "storageKey": null
            }
          ],
          "storageKey": null
        },
        {
          "alias": null,
          "args": null,
          "concreteType": "PageInfo",
          "kind": "LinkedField",
          "name": "pageInfo",
          "plural": false,
          "selections": [
            {
              "alias": null,
              "args": null,
              "kind": "ScalarField",
              "name": "endCursor",
              "storageKey": null
            },
            {
              "alias": null,
              "args": null,
              "kind": "ScalarField",
              "name": "hasNextPage",
              "storageKey": null
            }
          ],
          "storageKey": null
        }
      ],
      "storageKey": null
    }
  ],
  "type": "Query",
  "abstractKey": null
};
})();

(node/*: any*/).hash = "35a34d660d7155895c77082e8a7c5436";

export default node;
