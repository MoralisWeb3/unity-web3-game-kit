function MoralisStart(serverUrl, appId) {
    Moralis.start({ serverUrl, appId });
}

async function MoralisAuthenticate() {
    let user = Moralis.User.current();
    if (!user) {
        user = await Moralis.authenticate({ signingMessage: "Authenticate" });
    } else {
        // Refresh local data
        user = await Moralis.User.current().fetch();
    }

    if ('attributes' in user && 'sessionToken' in user.attributes) {
        unityInstance.SendMessage('WebWalletMenu', 'setUserSession', user.attributes.sessionToken.toString());
    } else {
        console.log("sessionToken not found!");
    }
}