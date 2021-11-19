# `ethereum-unity3d-boilerplate`

> Unity3d components and hooks for fast building games without running your own backend

This boilerplate is built on moralis-dotnet-sdk and [Moralis](https://moralis.io?utm_source=github&utm_medium=readme&utm_campaign=ethereum-boilerplate). Also has its own context provider for quick access to `chainId` or `ethAddress`

There are many components in this boilerplate that do not require an active web3 provider, they use Moralis Web3 API. Moralis supports the most popular blockchains and their test networks. You can find a list of all available networks in [Moralis Supported Chains](https://docs.moralis.io/moralis-server/web3-sdk/intro#supported-chains)

Please check the [official documentation of Moralis](https://docs.moralis.io/#user) for all the functionalities of Moralis.


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
- When Unity3D opens, in the "Hierachy" section expand "Menu Scene" then select "MenuCanvas"
- In the "Inspector" section find the sub-section titled "MainMenuScript".
- If the "MainMenuScript" sub-section is not expanded, expand it.
- Using the information from you Moralis Server, fill in Application Id and Server URL.
- If the Wallet Connect property is set to "None" drag WalletConnect from the "Hierarchy" section to this input.
- Click the Play icon located at the top, center of the Unity3D IDE.
