mergeInto(LibraryManager.library, {

  UnityMoralisStart: function (unityServerUrl, unityAppId) {
    const serverUrl = UTF8ToString(unityServerUrl);
    const appId = UTF8ToString(unityAppId);

    MoralisStart(serverUrl,appId);
  },

  UnityMoralisAuthenticate: function () {
    MoralisAuthenticate();
  },

});