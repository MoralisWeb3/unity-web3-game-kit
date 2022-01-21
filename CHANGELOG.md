# Change Log
## 1.0.3 (2022-01-xx)
- Wallet Connect Update Integration - fixes iOS and Android sign issues with Wallet Connect.
- Nethereum integration - Include wallet connect / NEthereum library to support changing chain state in game.
- Fix FileSave method, WebGL - Under WebGL the FileSave uri for the backend was incorrect, corrected this.
- Issue #10 - HttpUtility does not exist in current context
- Issue #13 - Moralis Client Delete Method not Implemented
- Issue #14 - Moralis Object DeleteAsync not Implemented
- Issue #17 - Wallet Connect Unity, move dependencies
- Issue #18 - Wallet Connect duplicate files
- Add Gif Decoder
- Re-Order folders / namespaces to better fit dependencies, etc.
- Fix issue with Web3Api call contract function to pass abi / params as seperate items instead of children of an object.
- Add Nethereum wrappers for ease of use.
- Enhance the demo so that the orcs can be killed, the chest opened, and add effects to the player's sword.
- Add an NFT that can be claimed once per address on Mumbai network.

## 1.0.2 (2022-01-01)
- Add support for WebGL applications. This release contains many updates all geared to WebGL support.

## 1.0.1 (2021-21-xx)
- Use Unity recommended .gitignore file
- Fix Chest Lid convex issue
- Fix iOS missing reference issue.

## 1.0.0 (2021-12-08)
- Re-layout whole project to group the assets into a format  recommened for a Unity Asset Package.
- Update .gitignore to ignoe Unity .meta files and Unity .log files.
- Update Moralis.Web3Api AccountApi to integrate scheme correction that fixes the return type.
- Update README to reflect the Web3Api changes and use of the Unity Asset Package.