# Change Log
## 1.2.1 (2022-05-30)
- Issue #84 Web3Api Token Endpoint Missing Operations
```
The Web3Api Token Endpoint is missing the SyncNftContract and ResyncMetadata oppperations
```
- Issue #87 MoralisUser Should be Fully Functional Using Default Constructor
```
Update MoralisObject so that MoralisUser and other objects derived from MoralisObject are
fully function when an instance is created from the default constructor when in a Unity context

_MoralisUser user = new MoralisUser();_ now is the same as _MoralisUser user = Moralis.Create<MoralisUser>();_
```
- Issue #88 TaskQueue Causes Unexpected Behavior but is No Longer Needed
```
When _user.SignUpAsync()_ is called, if _user.LogInAsync()_ is called immediately, the login was being called before the SignUpAsync was complete.
```

- Issue #89 Cronos Integration - Added support for Cronos chain.
# 1.2.0 (2022-05-20)
- Changed namespace from MoralisWeb3ApiSdk to MoralisUnity
- Changed MoralisInterface to Moralis
- Changed Moralis.Initialize to Moralis.Start
- Added new Setup Wizard (Settings are stored in a ScriptableObject)
- Removed knight demo and added new Introduction demo
- Seperated core functionality into web3-unity-sdk package (UPM): https://github.com/MoralisWeb3/web3-unity-sdk
- Added new web3-unity-sdk package as dependency with NPMJS: https://www.npmjs.com/package/io.moralis.web3-unity-sdk
- Updated Newtonsoft dependency to 3.0.2
- Updated WalletConnect
- Fixed warnings / removed debugs
- Issue #26 - Updating Version Control in Package Manager causes errors
- Issue #42 - Please release this as a UPM-compatible package
- Issue #56 - WebGL Error with Unity 2021.2.11f1
- Issue #71 - With Unity 2020.3.30 Newtonsoft Missing
- Issue #76 - Compile error after adding Unity Collections package
- Issue #92 - WalletConnect Session Fails to Reconnect
- Issue #93 - [WebSocket] Exception Unexpected character encountered while parsing value: M. Path '', line 0, position 0.
- Issue #95 - MoralisInterface.LogInAsync(user, pass) Does Not Set Current User

# 1.1.0 (2022-03-30)
- Issue #90 - iOS Wallet Images not loaded and displayed
- Issue #81 - WebGL LiveQuery Callbacks are not fired.
- Issue #77 - How to login with just username/email and password?
- Issue #72 - User SignUp, Without Wallet, Fails
- Issue #56 - WebGL Error with Unity 2021.2.11f1
- Issue #41 - Error on quit
- Issue #15 - Live Queries Throw Unexpected Exception when Network Connection is Dropped.

# 1.0.9 (2022-03-09)
- Issue #82 - Web3Api Native RunContractFunction Deserialization fails
- Issue #80 - WebGL, LiveQuery - DELETE: Good response has an Empty content
- Issue #75 - eature Request: CreateAsync
- Issue #69 - Detecting failed SaveAsync
- Issue #50 - On Object Create ACL not instantiated

# 1.0.8 (2022-03-02)
- Issue #32 - Replace Wallet Connect with In-Browser Wallet Interface for WebGL
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
