# Change Log
# WebGL / Wallet Browser Pre-Release
- Issue #32 - Replace Wallet Connect with In-Browser Wallet Interface for WebGL
- Issue #39 - Web3: Add Integrated Transfer Method
- Issue #70 - User Save Fails
- Fixed WebGL error: Unsupported internal call for IL2CPP:RuntimeInformation::GetRuntimeArchitecture
- Check if the user has setup the Server URI and Application Id
- Remove Speedy Node Requirement and Defects

# 1.0.7 (2022-02-18)
- Issue #57 - WalletConnect.AppData not automatically set
- Issue #59 - Web3Api.Native.GetContractEvents - invalid parameter
- Issue #61 - Speedynode Should not be used in Client 

# 1.0.6 (2022-02-14)
- Critical auth bug.
- Issue #49 - Cannot set public access in ACL

## 1.0.5 (2022-02-11)
- Issue #43 - Authentication - retrieve and add server time to authentication message.

## 1.0.4 (2022-02-08)
- Issue #19 - Moralis User and Moralis Object both have a session token property
- Issue #23 - Moralis Web3Api (non WebGl) API Clients are not Asynchronous. 
- Issue #25 - iOS XCODE Update Causes Build Error 
- Issue #27 - Create Object Does Not Set ClassName 
- Issue #31 - Integrate SolanaAPI into Moralis / Unity SDK 
- Issue #34 - Null ObjectService in MoralisObjects loaded via Query 

## 1.0.3 (2022-01-21)
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
