/**
 * @generated SignedSource<<80e0a9c9cd1d14a096afe32edb4125ed>>
 * @flow
 * @lightSyntaxTransform
 * @nogrep
 */

/* eslint-disable */

'use strict';

/*::
import type { ReaderFragment, RefetchableFragment } from 'relay-runtime';
import type { WatchlistListItemFragment_asset$fragmentType } from "./WatchlistListItemFragment_asset.graphql";
import type { FragmentType } from "relay-runtime";
declare export opaque type WatchlistListFragment_query$fragmentType: FragmentType;
import type { WatchlistListRefetchableQuery$variables } from "./WatchlistListRefetchableQuery.graphql";
export type WatchlistListFragment_query$data = {|
  +me: ?{|
    +watchlist: ?{|
      +assets: ?{|
        +edges: ?$ReadOnlyArray<{|
          +node: {|
            +id: string,
            +isInWatchlist: ?boolean,
            +$fragmentSpreads: WatchlistListItemFragment_asset$fragmentType,
          |},
        |}>,
      |},
    |},
  |},
  +$fragmentType: WatchlistListFragment_query$fragmentType,
|};
export type WatchlistListFragment_query$key = {
  +$data?: WatchlistListFragment_query$data,
  +$fragmentSpreads: WatchlistListFragment_query$fragmentType,
  ...
};
*/

import WatchlistListRefetchableQuery_graphql from './WatchlistListRefetchableQuery.graphql';
var node/*: ReaderFragment*/ = (function(){
var v0 = [
  "me",
  "watchlist",
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
      "operation": WatchlistListRefetchableQuery_graphql
    }
  },
  "name": "WatchlistListFragment_query",
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
          "concreteType": "Watchlist",
          "kind": "LinkedField",
          "name": "watchlist",
          "plural": false,
          "selections": [
            {
              "alias": "assets",
              "args": null,
              "concreteType": "AssetsConnection",
              "kind": "LinkedField",
              "name": "__WatchlistList_assets_connection",
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
                          "alias": null,
                          "args": null,
                          "kind": "ScalarField",
                          "name": "isInWatchlist",
                          "storageKey": null
                        },
                        {
                          "args": null,
                          "kind": "FragmentSpread",
                          "name": "WatchlistListItemFragment_asset"
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

(node/*: any*/).hash = "98e16b75bc83b0154efa2b1e1de7262b";

export default node;
