# `ethereum-unity-boilerplate`

> Unity components and hooks for fast building of web3 games. With this SDK you can build web3 games for mobile, desktop, Xbox, Playstation and other platforms.
This boilerplate allows you to authenticate users using crypto wallets on any platform.

This boilerplate is built on moralis-dotnet-sdk and [Moralis](https://moralis.io?utm_source=github&utm_medium=readme&utm_campaign=ethereum-boilerplate). Also has its own context provider for quick access to `chainId` or `ethAddress`

There are many components in this boilerplate that do not require an active web3 provider, they use Moralis Web3 API. Moralis supports the most popular blockchains and their test networks. You can find a list of all available networks in [Moralis Supported Chains](https://docs.moralis.io/moralis-server/web3-sdk/intro#supported-chains)

Please check the [official documentation of Moralis](https://docs.moralis.io/#user) for all the functionalities of Moralis.

![Demo](https://github.com/ethereum-boilerplate/ethereum-unity-boilerplate/blob/main/moralis-unity-boilerplate.gif)

# ⭐️ `Star us`
If this boilerplate helps you build Ethereum dapps faster - please star this project, every star makes us very happy!

# 🤝 `Need help?`
If you need help with setting up the boilerplate or have other questions - don't hesitate to write in our community forum and we will check asap. [Forum link](https://forum.moralis.io/t/ethereum-unity3d-boilerplate-questions/4553). The best thing about this boilerplate is the super active community ready to help at any time! We help each other.

# 🚀 Quick Start
📄 Clone or fork `ethereum-boilerplate`:
```sh
git clone https://github.com/ethereum-boilerplate/ethereum-unity-boilerplate.git
```
💿 Install all dependencies:
- [Unity Hub](https://unity3d.com/get-unity/download)
- [Visual Studio](https://visualstudio.microsoft.com/)

💿 Open Unity Hub and Add the Project
- Open Unity Hub
- click on the 'ADD' button.
- Navigate to the folder you cloned the boiler plate project to.
- Click on the "Select Folder" button.
- The project named "Boilerplate" will now be in the "Projects List". Click on it.
- When Unity3D opens, in the "Hierachy" section expand "DemoScene" then select "UICanvas" then "UIPanel"
- In the "Inspector" section find the sub-section titled "MainMenuScript".
- If the "MainMenuScript" sub-section is not expanded, expand it.
- Using the information from your Moralis Server, fill in Application Id and Server URL.
- If the Wallet Connect property is set to "None" drag WalletConnect from the "Hierarchy" section to this input.
- Click the Play icon located at the top, center of the Unity3D IDE.

This boilerplate project has been tested with the following Unity3D Releases:
1. 2020.2
2. 2020.3.24f1 (latest)

# 🧭 Table of contents

- [`ethereum-unity-boilerplate`](#ethereum-unity-boilerplate)
- [🚀 Quick Start](#-quick-start)
- [🧭 Table of contents](#-table-of-contents)
- [🧰 Moralis SDK](#-moralis-sdk)
    - [`Client`](#client)
    - [`Authentication`](#authentication)  
    - [`Queries`](#queries)  
    - [`Live Queries`](#live-queries)
    - [`Custom Objects`](custom-objects)
    - [`User Object`](#user-object)
    - [`Authentication Data`](#authentication-data)
    - [`HostManifestData`](#hostmanifestdata)
    - [`ServerConnectionData`](#server-connectiondata)
- [🏗 Ethereum Web3Api Methods](#-ethereum-web3api-methods)
    - [`Web3Api Notes`](#web3api-notes)
    - [`Chains`](#chains)
    - [`Account`](#account)
        - [`GetNativeBalance`](#getnativebalance)
        - [`GetNFTs`](#getnfts)
        - [`GetNFTsForContract`](#getnftsforcontract)
        - [`GetNFTTransfers`](#getnfttransfers)
        - [`GetTokenBalances`](#gettokenbalances)
        - [`GetTokenTransfers`](#gettokentransfers)
        - [`GetTransactions`](#gettransactions)
    - [`Defi`](#defi)
        - [`GetPairAddress`](#getpairaddress)
        - [`GetPairReserves`](#getpairreserves)
    - [`Native`](#native)
        - [`GetBlock`](#GetBlock)
        - [`GetContractEvents`](#GetContractEvents)
        - [`GetDateToBloc`](#GetDateToBloc)
        - [`GetLogsByAddress`](#GetLogsByAddress)
        - [`GetNFTTransfersByBlock`](#GetNFTTransfersByBlock)
        - [`GetTransaction`](#GetTransaction)
        - [`RunContractFunction`](#RunContractFunction)
    - [`Resolve`](#resolve)
        - [`ResolveDomain`](#resolvedomain)
    - [`Storage`](#erc20balance)
    - [`Token`](#erc20transfers)
        - [`GetAllTokenIds`](#getalltokenids)
        - [`GetContractNFTTransfers`](#getcontractnfttransfers)
        - [`GetNFTLowestPrice`](#getnftlowestprice)
        - [`GetNFTMetadata`](#getnftmetadata)
        - [`GetNFTOwners`](#getnftowners)
        - [`GetNFTTrades`](#getnfttrades)
        - [`GetNftTransfersFromToBlock`](#getnfttransfersfromtoblock)
        - [`GetTokenAdressTransfers`](#gettokenaddrestransfers)
        - [`GetTokenAllowance`](#gettokenallowance)
        - [`GetTokenIdMetadata`](#gettokenidmetadata)
        - [`GetTokenIdOwners`](#gettokenidowners)
        - [`GetTokenMetadata`](#gettokenmetadata)
        - [`GetTokenMetadataBySymbol`](#gettokenmetadatabysymbol)
        - [`GetTokenPrice`](#gettokenprice)
        - [`GetWalletTokenIdTransfers`](#getwallettokenidtransfers)
        - [`SearchNFTs`](#searchnfts)
- [Helpful Tools](#helpful-tools)
  
# 🏗 Moralis SDK
  The.NET Moralis SDK provides easy to use method that make integrating your application with Moralis a snap. You will find that the.NET SDK works much the same as in JavaScript. For use in Unity3D we have added additional quick start objects that make integrating the Moralis SDK in a Unity3D application. 
  For the examples that follow we provide examples of how to use the Moralis.NET SDK directly and perform the same functionality using the provided Moralis Unity3D quick start tools.
  
## `Client`
  The Moralis SDK Client provides a way to easily interact with Moralis database and the Web3API. In .NET we use the *MoralisClient*
  to interact with Moralis. For Unity3D we have provided a signleton wrapper named *MoralisInterface* that makes it easy to initialize the MoralisClient and then access it from anywhere in your Unity3D application. With either option you can initialize the Moralis Client with a single line of code
  
### SDK Client Initialization
**Required Using Statements**
```
using Moralis;
using Moralis.Platform; 
using Moralis.Web3Api.Client;
```
**Initialize Client**
```
MoralisClient moralis = new MoralisClient(new ServerConnectionData() { ApplicationID = "YOUR_APPLICATION_ID_HERE", ServerURI = "YOUR_SERER_URL_HERE"}, new Web3ApiClient());
```
_note: The **new Web3ApiClient()** parameter is optional and should be included only when you will be using functionality fromt the Moralis Web3AP REST service._

### Unity3D Client Initialization
**Initialize Client**
```
MoralisInterface.Initialize(MoralisApplicationId, MoralisServerURI, hostManifestData);
```
_note: For the **hostManifestData** parameter see [`HostManifestData`](#hostmanifestdata). This is requried for Unity3D applications._
_note: See [`User Object`](#userobject) for information about initializing the Moralis Client for a custom User Object._

## `Authentication`
Authentication is handled in a similar manner in both the SDK and the Unity3d. There is not direct manner to interact securely with a wallet in a .NET application so the Moralis SDK interacts with wallets in a lose cupled manner. For the Unity3D boilerplate application, and the other examples we provide, we use Wallet Connect to facilitate interaction with wallets. 

### Basic Moralis Authentication
Here are the statements used to authenticate with Moralis:
#### SDK
```
MoralisUser user = await moralis.LogInAsync(authenticationData, CancellationToken.None);
```
#### Unity3D
```
MoralisUser user = await MoralisInterface.LogInAsync(authentication-Data);
```
_note: See [`Authentication Data`](#authentication-data) for information about the authenticationData parameter._

The Unity3D Boilerplate application provides a detailed example of how to integrate with Wallet Connect and is worth examining in detail.
Here are the relevant sections from the Boiler Plate Application:
1. **Wallet Selecttion** This is initiated when the _MainMenuScript.Play_ method is called. This method redirects to either a view with a QR Code or, if built for iOS or Android, a Wallet Select list (generated by Wallet Connect)
2. **Signature** When the connect response from the wallet is received, Wallet Connect fires a WalletConnectEvent. This is handled by the _MainMenuScript.WalletConnectHandler_ method. 
#### _MainMenuScript.WalletConnectHandler_ Signature Example
```
// Extract wallet address from the Wallet Connect Session data object.
string address = data.accounts[0].ToLower();

string response = await walletConnect.Session.EthPersonalSign(address, "Moralis Authentication");
```
#### _MainMenuScript.WalletConnectHandler_ Authentication Example
```
// Create moralis auth data from message signing response.
Dictionary<string, object> authData = new Dictionary<string, object> { { "id", address }, { "signature", response }, { "data", "Moralis Authentication" } };

// Attempt to login user.
MoralisUser user = await MoralisInterface.LogInAsync(authData);
```

## `Queries`
Queries provide a way to retrieve informaition from your Moralis database.
#### Required Using Statement(s)
```
using Moralis;
using Moralis.Platform.Objects;
```
The following example will return all Hero records where 'Level' is equal to 3.
#### SDK Example Query
```
MoralisQuery<Hero> q = moralis.Query<Hero>().WhereEqualTo("Level", 3);
IEnumerable<Hero> result = await q.FindAsync();
```
#### Unity3D Example
```
MoralisQuery<Hero> q = MoralisInterface.GetClient().Query<Hero>().WhereEqualTo("Level", 3);
IEnumerable<Hero> result = await q.FindAsync();
```

The Moralis Dot Net SDK supports the same query methods as the JS SDK. For example creating 'OR', 'AND', and 'NOR' queries.
For this example we will take the query from the above example and construct a 'OR' query that also returns records where the hero's name is 'Zuko'.
Furthermore we will sort (order) the result set by the hero's strength, descending.
#### SDK Example OR query
```
MoralisQuery<Hero> q1 = moralis.BuildOrQuery<Hero>(new MoralisQuery<Hero>[] { q, moralis.Query<Hero>().WhereEqualTo("Name", "Zuko") })
    .OrderByDescending("Strength");
IEnumerable<Hero> result = await q1.FindAsync();
```
#### Unity3D Example OR query
```
MoralisQuery<Hero> q1 = MoralisInterface.GetClient()
    .BuildOrQuery<Hero>(new MoralisQuery<Hero>[] { q, MoralisInterface.GetClient().Query<Hero>().WhereEqualTo("Name", "Zuko") })
    .OrderByDescending("Strength");
IEnumerable<Hero> result = await q1.FindAsync();
```

## `Live Queries`
Live Queries are queries that include a subscription that provide updates whenever the data targeted by the query are updated.
A Live Query subscription emits events that indicate the state of the client and changes to the data. For more information please see
the [docs](https://docs.moralis.io/moralis-server/database/live-queries).

The foloowing examples use the [query example from above](#queries)
### Live Query Example (SDK)
```
MoralisLiveQueryClient<Hero> heroSubscription = moralis.Query<Hero>().Subscribe(callbacks);
```
_note: the **callbacks** parameter is optional. Please see [Callbacks Explained](#live-query-callbacks-explained) bellow.
### Live Query Example (Unity3D)
Since Unity3d is mainly used to create games, Unity3D apps generaly have life cycle events you do not usually need to worray about in a normal program.
We have created a special Live Query wrapper object that automatically handles your subscriptions for pause, unpause, close, etc.
This example shows how to create your subscription using this wrapper class.
```
MoralisQuery<Hero> q = MoralisInterface.GetClient().Query<Hero>();
MoralisLiveQueryController.AddSubscription<Hero>("Hero", q, callbacks);
```
_note: the **callbacks** parameter is optional. Please see [Callbacks Explained](#live-query-callbacks-explained) bellow.

The _**MoralisLiveQueryController**_ is a singleton object and so is available anywhere within your application.
The first parameter ("Hero" above") is a key that you can use to retrieve a subscription (to check its status for example) or to remove a subscription.

By using the The _**MoralisLiveQueryController**_ object you do not need to worry about properly closing or disposing of your scubscriptions as this wrapper object handles all of that for you.

### Live Query Callbacks Explained.
Callbacks are used to handle the events emitted by a subscription. You can set the callbacks directly agains a subscription. However it is usually cleaner to 
seperate these from the main code. To facilitate this we have included the _**MoralisLiveQueryCallbacks**_ object. This optional object can be passed to the subscription.
#### Example MoralisLiveQueryCallbacks Use
```
MoralisLiveQueryCallbacks<Hero> callbacks = new MoralisLiveQueryCallbacks<Hero>();
callbacks.OnConnectedEvent += (() => { Console.WriteLine("Connection Established."); });
callbacks.OnSubscribedEvent += ((requestId) => { Console.WriteLine($"Subscription {requestId} created."); });
callbacks.OnUnsubscribedEvent += ((requestId) => { Console.WriteLine($"Unsubscribed from {requestId}."); });
callbacks.OnErrorEvent += ((ErrorMessage em) =>
{
    Console.WriteLine($"ERROR: code: {em.code}, msg: {em.error}, requestId: {em.requestId}");
});
callbacks.OnCreateEvent += ((item, requestId) =>
{
    Console.WriteLine($"Created hero: name: {item.Name}, level: {item.Level}, strength: {item.Strength} warcry: {item.Warcry}");
});
callbacks.OnUpdateEvent += ((item, requestId) =>
{
    Console.WriteLine($"Updated hero: name: {item.Name}, level: {item.Level}, strength: {item.Strength} warcry: {item.Warcry}");
});
callbacks.OnDeleteEvent += ((item, requestId) =>
{
    Console.WriteLine($"Hero {item.Name} has been defeated and removed from the roll!");
});
callbacks.OnGeneralMessageEvent += ((text) =>
{
    Console.WriteLine($"Websocket message: {text}");
});
```

## `Custom Object`
Creating your own objects to support NPCs, characters, and game objects is a simple as creating a Plain Old C# Object (POCO). The only stipulation is that your custom object must be a child of Moralis Object and when you create an instance of the object it should be made via _**moralis.Create**_ method. This associates some extensions to your object that enable you to perform Moralis functions such as _Save_ directly on the object.
#### Required Using Statement(s)
```
using Moralis;
using Moralis.Platform.Objects;
```
#### Sample Object
``` 
public class Hero : MoralisObject
{
    public int Strength { get; set; }
    public int Level { get; set; }
    public string Name { get; set; }
    public string Warcry { get; set; }
    public List<string> Bag { get; set; }

    public Hero() : base("Hero") 
    {
        Bag = new List<string>();
    }
}
```
#### Create and Save Instance of Object (SDK)
```
Hero h = moralis.Create<Hero>();
h.Name = "Zuko";
h.Strength = 50;
h.Level = 15;
h.Warcry = "Honor!!!";
h.Bag.Add("Leather Armor");
h.Bag.Add("Crown Prince Hair clip.");

await h.SaveAsync();
```
#### Create and Save Instance of Object (Unity3D)
```
Hero h = MoralisInterface.GetClient().Create<Hero>();
h.Name = "Zuko";
h.Strength = 50;
h.Level = 15;
h.Warcry = "Honor!!!";
h.Bag.Add("Leather Armor");
h.Bag.Add("Crown Prince Hair clip.");

await h.SaveAsync();
```

## `User Object`
The user object contains information about the currently logged in user. Upon successful login, the user is stored in local storage until logout. This allows a user to log in once and not login again until their session expires or they logout.

If you create a custom user object it must descend from MoralisUser.

Since C# is a typed language the compiler must know what types are used at compile time. Due to this, since the MoralisUser is integral to internal functions in the Moralis SDK, when you create a custom User Object you must initialize the Moralis client using your custom User Object. After this step you can use the Moralis Client as usual.

#### Initialize Moralis Client with Custom User Object
```
MoralisClient<YourUserObject> moralis = new MoralisClient<YourUserObject>(new ServerConnectionData() { ApplicationID = "YOUR_APPLICATION_ID_HERE", ServerURI = "YOUR_SERER_URL_HERE"}, new Web3ApiClient());
```
_note: for Unity3D you will need to make the above change in the **MoralisInterface.Initialize** object. You will also need to replace the MoralisUser object elsewhere in the Boilerplate code._
_**WARNING** do not make any replacements to any files under the MoralisDtoNet folder_

## `Authentication Data`
Authentucation data is a _**Dictionary<string, string>**_ object that contains the information required by Moralis to authenticate a user.
As a minimum the authentication data dictionary must contain the following entries:
1. **id** The wallet address of the wallet used to sign the message.
2. **signature** The signature data returned by the Sign request sent to the wallet.
3. **data** The message that was sent to the wallet to be signed.
#### Example
```
Dictionary<string, object> authData = new Dictionary<string, object> { { "id", "ADDRESS_HERE".ToLower() }, { "signature", "SIGNATURE_DATA_HERE" }, { "data", "MESSAGE_HERE" } };
```

## `HostManifestData`
In Unity3D applications the HostManifestData object is used to pass information to Moralis that is usually autogenerated from Windows system variables. Since Unity3D supports multiple platforms this information is not always available. 

## `ServerConnectionData`
Description here


# 🏗 Ethereum Web3Api Methods

## `Web3Api Notes`
The complete Moralis Web3API schema including endpoints, operations and models, can be found by loggining into your Moralis Server and selecting **Web3 API***

For use with either Moralis SDK or in Unity3d, the following using statements are requried:
```
using System.Collections.Generic;
using Moralis.Web3Api.Models;
```

## `Chains`
Use the code snippet below to retrieve a list of EVM chains supported in the Moralis Web3API. This list can be used for populating dropdown lists etc.
#### Example
```
List<ChainEntry> chains = MoralisInterface.SupportedChains;
```

## `Account`
Code examples demonstrating how to use the Moralis Web3API Account endpoint and operations.

### `GetNativeBalance`
Gets native balance for a specific address
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **providerUrl** _string_ OPTIONAL web3 provider url to user when using local dev chain
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
#### Example
```
NativeBalance balance = MoralisInterface.GetClient().Web3Api.Account.GetNativeBalance(address.ToLower(), ChainList.eth);
```

### `GetNFTs`
Gets NFTs owned by the given address
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **format** _string_ OPTIONAL The format of the token id
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
- **order** _string_ OPTIONAL The field(s) to order on and if it should be ordered in ascending or descending order. Specified by: fieldName1.order,fieldName2.order. Example 1: "name", "name.ASC", "name.DESC", Example 2: "Name and Symbol", "name.ASC,symbol.DESC"
#### Example
```
NftOwnerCollection balance = MoralisInterface.GetClient().Web3Api.Account.GetNFTs(address.ToLower(), ChainList.eth);
```

### `GetNFTsForContract`
Gets NFTs owned by the given address
- **address** _string_ REQUIRED Target address
- **tokenAddress** _string_ REQUIRED Address of the contract
- **chain** _ChainList_ REQUIRED The chain to query
- **format** _string_ OPTIONAL The format of the token id
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
- **order** _string_ OPTIONAL The field(s) to order on and if it should be ordered in ascending or descending order. Specified by: fieldName1.order,fieldName2.order. Example 1: "name", "name.ASC", "name.DESC", Example 2: "Name and Symbol", "name.ASC,symbol.DESC"
#### Example
```
NftOwnerCollection balance = MoralisInterface.GetClient().Web3Api.Account.GetNFTsForContract(address.ToLower(), tokenAddress, ChainList.eth);
```

### `GetNFTTransfers`
Gets the transfers of the tokens matching the given parameters
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **format** _string_ OPTIONAL The format of the token id
- **direction** _string_ OPTIONAL The transfer direction
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
- **order** _string_ OPTIONAL The field(s) to order on and if it should be ordered in ascending or descending order. Specified by: fieldName1.order,fieldName2.order. Example 1: "name", "name.ASC", "name.DESC", Example 2: "Name and Symbol", "name.ASC,symbol.DESC"
#### Example
```
NftTransferCollection balance = MoralisInterface.GetClient().Web3Api.Account.GetNFTTransfers(address.ToLower(), ChainList.eth);
```

### `GetTokenBalances`
Gets token balances for a specific address
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **subdomain** _string_ OPTIONAL The subdomain of the moralis server to use (Only use when selecting local devchain as chain)
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
#### Example
```
List<Erc20TokenBalance> balance = MoralisInterface.GetClient().Web3Api.Account.GetTokenBalances(address.ToLower(), ChainList.eth);
```

### `GetTokenTransfers`
Gets ERC20 token transactions in descending order based on block number
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **subdomain** _string_ OPTIONAL The subdomain of the moralis server to use (Only use when selecting local devchain as chain)
- **fromBlock** _string_ OPTIONAL The minimum block number from where to get the logs.
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
- **fromDate** _string_ OPTIONAL The date from where to get the logs (any format that is accepted by momentjs).
- **toDate** _string_ OPTIONAL Get the logs to this date (any format that is accepted by momentjs)
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
#### Example
```
List<Erc20Transaction> balance = MoralisInterface.GetClient().Web3Api.Account.GetTokenTransfers(address.ToLower(), ChainList.eth);
```

### `GetTransactions`
Gets native transactions in descending order based on block number
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **subdomain** _string_ OPTIONAL The subdomain of the moralis server to use (Only use when selecting local devchain as chain)
- **fromBlock** _string_ OPTIONAL The minimum block number from where to get the logs.
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
- **fromDate** _string_ OPTIONAL The date from where to get the logs (any format that is accepted by momentjs).
- **toDate** _string_ OPTIONAL Get the logs to this date (any format that is accepted by momentjs)
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
#### Example
```
TransactionCollection balance = MoralisInterface.GetClient().Web3Api.Account.GetTransactions(address.ToLower(), ChainList.eth);
```

## `Defi`
Code examples demonstrating how to use the Moralis Web3API Defi endpoint and operations.

### `GetPairAddress`
Fetches and returns pair data of the provided token0+token1 combination. The token0 and token1 options are interchangable (ie. there is no different outcome in "token0=WETH and token1=USDT" or "token0=USDT and token1=WETH")
- **exchange** _string_ REQUIRED The factory name or address of the token exchange
- **token0Address** _string_ REQUIRED Token0 address
- **token1Address** _string_ REQUIRED Token1 address
- **chain** _ChainList_ REQUIRED The chain to query
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
- **toDate** _string_ OPTIONAL Get the logs to this date (any format that is accepted by momentjs)
#### Example
```
ReservesCollection nftTransers = MoralisInterface.GetClient().Web3Api.Defi.GetPairAddress(exchange, token0Address, token1Address, ChainList.eth);
```

### `GetPairReserves`
Get the liquidity reserves for a given pair address
- **pairAddress** _string_ REQUIRED Liquidity pair address
- **chain** _ChainList_ REQUIRED The chain to query
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
- **toDate** _string_ OPTIONAL Get the logs to this date (any format that is accepted by momentjs)
- **providerUrl** _string_ OPTIONAL web3 provider url to user when using local dev chain
#### Example
```
ReservesCollection nftTransers = MoralisInterface.GetClient().Web3Api.Defi.GetPairReserves(pairAddress, ChainList.eth);
```

## `Native`
Code examples demonstrating how to use the Moralis Web3API Native endpoint and operations.

### `GetBlock`
Gets the contents of a block by block hash
- **blockNumberOrHash** _string_ REQUIRED The block hash or block number
- **chain** _ChainList_ REQUIRED The chain to query
- **subdomain** _string_ OPTIONAL The subdomain of the moralis server to use (Only use when selecting local devchain as chain)
#### Example
```
Block block = MoralisInterface.GetClient().Web3Api.Native.GetBlock(blockNumberOrHash, ChainList.eth);
```

### `GetContractEvents`
Gets events in descending order based on block number
- **address** _string_ REQUIRED Target address
- **topic** _string_ REQUIRED The topic of the event
- **chain** _ChainList_ REQUIRED The chain to query
- **subdomain** _string_ OPTIONAL The subdomain of the moralis server to use (Only use when selecting local devchain as chain)
- **providerUrl** _string_ OPTIONAL web3 provider url to user when using local dev chain
- **fromBlock** _string_ OPTIONAL The minimum block number from where to get the logs.
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
- **fromDate** _string_ OPTIONAL The date from where to get the logs (any format that is accepted by momentjs).
- **toDate** _string_ OPTIONAL Get the logs to this date (any format that is accepted by momentjs)
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
#### Example
```
List<LogEvent> logEvents = MoralisInterface.GetClient().Web3Api.Native.GetContractEvents(address, topic, ChainList.eth);
```

### `GetDateToBlock`
Gets the closest block of the provided date
- **data** _string_ REQUIRED Unix date in miliseconds or a datestring (any format that is accepted by momentjs)
- **chain** _ChainList_ REQUIRED The chain to query
- **providerUrl** _string_ OPTIONAL web3 provider url to user when using local dev chain
#### Example
```
BlockDate blockDate = MoralisInterface.GetClient().Web3Api.Native.GetDateToBlock(date, ChainList.eth);
```

### `GetLogsByAddress`
Gets the logs from an address
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **subdomain** _string_ OPTIONAL The subdomain of the moralis server to use (Only use when selecting local devchain as chain)
- **blockNumber** _string_ OPTIONAL The block number.
- **fromBlock** _string_ OPTIONAL The minimum block number from where to get the logs.
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
- **fromDate** _string_ OPTIONAL The date from where to get the logs (any format that is accepted by momentjs).
- **toDate** _string_ OPTIONAL Get the logs to this date (any format that is accepted by momentjs)
- **topic0** _string_ OPTIONAL 
- **topic1** _string_ OPTIONAL 
- **topic2** _string_ OPTIONAL 
- **topic3** _string_ OPTIONAL 
#### Example
```
LogEventByAddress logEvents = MoralisInterface.GetClient().Web3Api.Native.GetLogsByAddress(address, ChainList.eth);
```

### `GetNFTTransfersByBlock`
Gets NFT transfers by block number or block hash
- **blockNumberOrHash** _string_ REQUIRED The block hash or block number
- **chain** _ChainList_ REQUIRED The chain to query
- **subdomain** _string_ OPTIONAL The subdomain of the moralis server to use (Only use when selecting local devchain as chain)
#### Example
```
NftTransferCollection nftTransfers = MoralisInterface.GetClient().Web3Api.Native.GetNFTTransfersByBlock(blockNumberOrHash, ChainList.eth);
```

### `GetTransaction`
Gets the contents of a block transaction by hash
- **transactionHash** _string_ REQUIRED The transaction hash
- **chain** _ChainList_ REQUIRED The chain to query
- **subdomain** _string_ OPTIONAL The subdomain of the moralis server to use (Only use when selecting local devchain as chain)
#### Example
```
BlockTransaction blockTransaction = MoralisInterface.GetClient().Web3Api.Native.GetTransaction(transactionHash, ChainList.eth);
```

### `RunContractFunction`
Runs a given function of a contract abi and returns readonly data
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **functionName** _string_ REQUIRED Function name of the target function.
- **subdomain** _string_ OPTIONAL The subdomain of the moralis server to use (Only use when selecting local devchain as chain)
- **providerUrl** _string_ OPTIONAL web3 provider url to user when using local dev chain
#### Example
```
string result = MoralisInterface.GetClient().Web3Api.Native.RunContractFunction(address, functionName, ChainList.eth);
```


## `Resolve`
Code examples demonstrating how to use the Moralis Web3API Resolve endpoint and operations.

### `ResolveDomain`
Resolves an Unstoppable domain and returns the address
- **domain** _string_ REQUIRED Domain to be resolved
- **currency** _string_ OPTIONAL The currency to query.
#### Example
```
Resolve result = MoralisInterface.GetClient().Web3Api.Resolve.ResolveDomain(domain);
```


## `Storage`
Code examples demonstrating how to use the Moralis Web3API Storage endpoint and operations.


## `Token`
Code examples demonstrating how to use the Moralis Web3API Token endpoint and operations.

### `GetAllTokenIds`
Gets data, including metadata (where available), for all token ids for the given contract address.
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **foramt** _string_ OPTIONAL The format of the token id
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
- **order** _string_ OPTIONAL If the order should be Ascending or Descending based on the blocknumber on which the NFT was minted. Allowed values: "ASC", "DESC"
#### Example
```
NftCollection nfts = MoralisInterface.GetClient().Web3Api.Token.GetAllTokenIds(address, ChainList.eth);
```

### `GetContractNFTTransfers`
Gets the transfers of the tokens matching the given parameters
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **foramt** _string_ OPTIONAL The format of the token id
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
- **order** _string_ OPTIONAL If the order should be Ascending or Descending based on the blocknumber on which the NFT was minted. Allowed values: "ASC", "DESC"
#### Example
```
NftTransferCollection nftTransers = MoralisInterface.GetClient().Web3Api.Token.GetContractNFTTransfers(address, ChainList.eth);
```

### `GetNFTLowestPrice`
Get the lowest price found for a nft token contract for the last x days (only trades paid in ETH)
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **days** _integer_ OPTIONAL Offset
- **providerUrl** _string_ OPTIONAL web3 provider url to user when using local dev chain
- **marketplace** _string_ OPTIONAL web3 marketplace from where to get the trades (only opensea is supported at the moment)
#### Example
```
TradesCollection trades = MoralisInterface.GetClient().Web3Api.Token.GetNFTLowestPrice(address, ChainList.eth);
```

### `GetNFTMetadata`
Gets the contract level metadata (name, symbol, base token uri) for the given contract
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
#### Example
```
NftContractMetadata metadata = MoralisInterface.GetClient().Web3Api.Token.GetNFTMetadata(address, ChainList.eth);
```

### `GetNFTOwners`
Gets all owners of NFT items within a given contract collection
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **format** _string_ OPTIONAL The format of the token id
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
- **order** _string_ OPTIONAL If the order should be Ascending or Descending based on the blocknumber on which the NFT was minted. Allowed values: "ASC", "DESC"
#### Example
```
NftOwnerCollection owners = MoralisInterface.GetClient().Web3Api.Token.GetNFTOwners(address, ChainList.eth);
```

### `GetNFTTrades`
Get the nft trades for a given contracts and marketplace
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **fromBlock** _string_ OPTIONAL The minimum block number from where to get the logs.
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
- **fromDate** _string_ OPTIONAL The date from where to get the logs (any format that is accepted by momentjs).
- **toDate** _string_ OPTIONAL Get the logs to this date (any format that is accepted by momentjs)
- **providerUrl** _string_ OPTIONAL web3 provider url to user when using local dev chain
- **marketplace** _string_ OPTIONAL web3 marketplace from where to get the trades (only opensea is supported at the moment)
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
#### Example
```
TradesCollection trades = MoralisInterface.GetClient().Web3Api.Token.GetNFTTrades(address, ChainList.eth);
```

### `GetNftTransfersFromToBlock`
Gets the transfers of the tokens from a block number to a block number
- **chain** _ChainList_ REQUIRED The chain to query
- **fromBlock** _string_ OPTIONAL The minimum block number from where to get the logs.
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
- **fromDate** _string_ OPTIONAL The date from where to get the logs (any format that is accepted by momentjs).
- **toDate** _string_ OPTIONAL Get the logs to this date (any format that is accepted by momentjs)
- **format** _string_ OPTIONAL The format of the token id
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
- **order** _string_ OPTIONAL If the order should be Ascending or Descending based on the blocknumber on which the NFT was minted. Allowed values: "ASC", "DESC"
#### Example
```
NftTransferCollection transfers = MoralisInterface.GetClient().Web3Api.Token.GetNftTransfersFromToBlock(ChainList.eth);
```

### `GetTokenAdressTransfers`
Gets ERC20 token contract transactions in descending order based on block number
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **subdomain** _string_ OPTIONAL The subdomain of the moralis server to use (Only use when selecting local devchain as chain)
- **fromBlock** _string_ OPTIONAL The minimum block number from where to get the logs.
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
- **fromDate** _string_ OPTIONAL The date from where to get the logs (any format that is accepted by momentjs).
- **toDate** _string_ OPTIONAL Get the logs to this date (any format that is accepted by momentjs)
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
#### Example
```
List<Erc20Transaction> transactions = MoralisInterface.GetClient().Web3Api.Token.GetTokenAdressTransfers(address, ChainList.eth);
```

### `GetTokenAllowance`
Gets the amount which the spender is allowed to withdraw from the spender
- **address** _string_ REQUIRED Target address
- **ownerAddress** _string_ REQUIRED Target address
- **spenderAddress** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **providerUrl** _string_ OPTIONAL web3 provider url to user when using local dev chain
#### Example
```
Erc20Allowance allowance = MoralisInterface.GetClient().Web3Api.Token.GetTokenAllowance(address, ownerAddress, spenderAddress, ChainList.eth);
```

### `GetTokenIdMetadata`
Gets data, including metadata (where available), for the given token id of the given contract address.
- **address** _string_ REQUIRED Target address
- **tokenId** _string_ REQUIRED The id of the token
- **chain** _ChainList_ REQUIRED The chain to query
- **foramt** _string_ OPTIONAL The format of the token id
#### Example
```
Nft nft = MoralisInterface.GetClient().Web3Api.Token.GetTokenIdMetadata(address, tokenId, ChainList.eth);
```

### `GetTokenIdOwners`
Gets all owners of NFT items within a given contract collection
- **address** _string_ REQUIRED Target address
- **tokenId** _string_ REQUIRED The id of the token
- **chain** _ChainList_ REQUIRED The chain to query
- **foramt** _string_ OPTIONAL The format of the token id
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
- **order** _string_ OPTIONAL If the order should be Ascending or Descending based on the blocknumber on which the NFT was minted. Allowed values: "ASC", "DESC"
#### Example
```
NftOwnerCollection owners = MoralisInterface.GetClient().Web3Api.Token.GetTokenIdOwners(address, tokenId, ChainList.eth);
```

### `GetTokenMetadata`
Returns metadata (name, symbol, decimals, logo) for a given token contract address.
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **subdomain** _string_ OPTIONAL The subdomain of the moralis server to use (Only use when selecting local devchain as chain)
- **providerUrl** _string_ OPTIONAL web3 provider url to user when using local dev chain
#### Example
```
List<Erc20Metadata> metadataList = MoralisInterface.GetClient().Web3Api.Token.GetTokenMetadata(addresses, ChainList.eth);
```

### `GetTokenMetadataBySymbol`
Returns metadata (name, symbol, decimals, logo) for a given token contract address.
- **symbols** _List<string>_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The symbols to get metadata for
- **subdomain** _string_ OPTIONAL The subdomain of the moralis server to use (Only use when selecting local devchain as chain)
#### Example
```
List<Erc20Metadata> metadataList = MoralisInterface.GetClient().Web3Api.Token.GetTokenMetadataBySymbol(symbols, ChainList.eth);
```

### `GetTokenPrice`
Returns the price nominated in the native token and usd for a given token contract address.
- **address** _string_ REQUIRED Target address
- **chain** _ChainList_ REQUIRED The chain to query
- **providerUrl** _string_ OPTIONAL web3 provider url to user when using local dev chain
- **exchange** _string_ OPTIONAL The factory name or address of the token exchange
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
#### Example
```
Erc20Price tkenPrice = MoralisInterface.GetClient().Web3Api.Token.GetTokenPrice(address, ChainList.eth);
```

### `GetWalletTokenIdTransfers`
Gets the transfers of the tokens matching the given parameters
- **address** _string_ REQUIRED Target address
- **tokenId** _string_ REQUIRED The id of the token
- **chain** _ChainList_ REQUIRED The chain to query
- **foramt** _string_ OPTIONAL The format of the token id
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
- **order** _string_ OPTIONAL If the order should be Ascending or Descending based on the blocknumber on which the NFT was minted. Allowed values: "ASC", "DESC"
#### Example
```
NftTransferCollection transfers = MoralisInterface.GetClient().Web3Api.Token.GetWalletTokenIdTransfers(address, tokenId, ChainList.eth);
```

### `SearchNFTs`
Gets NFTs that match a given metadata search.
- **q** _string_ REQUIRED The search string
- **chain** _ChainList_ REQUIRED The chain to query
- **foramt** _string_ OPTIONAL The format of the token id
- **filter** _string_ OPTIONAL What fields the search should match on. To look into the entire metadata set the value to 'global'. To have a better response time you can look into a specific field like name. Available values : name, description, attributes, global, name,description, name,attributes, description,attributes, name,description,attributes
- **fromBlock** _string_ OPTIONAL The minimum block number from where to get the logs.
- **toBlock** _string_ OPTIONAL The maximum block number from where to get the logs.
- **fromDate** _string_ OPTIONAL The date from where to get the logs (any format that is accepted by momentjs).
- **toDate** _string_ OPTIONAL Get the logs to this date (any format that is accepted by momentjs)
- **offset** _integer_ OPTIONAL Offset
- **limit** _integer_ OPTIONAL Limit
#### Example
```
NftMetadataCollection metadata = MoralisInterface.GetClient().Web3Api.Token.SearchNFTs(q, ChainList.eth);
```


# Helpful Tools
1. [Unity3d Assets](https://assetstore.unity.com/)
    The best place to find Unity3d Assets for a range of budgets.
2. [The Gimp](https://www.gimp.org/)
    Open source image editing tool
3. [Blender](https://www.blender.org/)
    Open source tool for creating 3D models, animations, textures, andeverything else you need for game characters and objects.
4. [Maximo](https://www.mixamo.com/)
    Free to use (with registration) Animations for huminoid rigged models.
