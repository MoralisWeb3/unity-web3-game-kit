
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Runtime.InteropServices;
using MoralisWeb3ApiSdk;

#if UNITY_WEBGL
using Cysharp.Threading.Tasks;
using Moralis.WebGL.Platform.Objects;
#endif 

[AddComponentMenu("Moralis/WebWalletConnect")]
public class WebWalletConnect : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void UnityMoralisStart(string serverUrl, string appId);

    [DllImport("__Internal")]
    private static extern void UnityMoralisAuthenticate();

    [SerializeField]
    private MoralisController moralisController;

    public UnityEvent OnIsLoggedInIsTrue;
    public UnityEvent OnIsLoggedInIsFalse;
    public UnityEvent OnUserFromSessionIsTrue;
    public UnityEvent OnUserFromSessionIsFalse;

    #if UNITY_WEBGL
    async void Start()
    { 
        #if UNITY_WEBGL && !UNITY_EDITOR
        // Start Moralis in the browser
        UnityMoralisStart(moralisController.MoralisServerURI, moralisController.MoralisApplicationId);
        #endif

        if (moralisController != null && moralisController)
        {
            await moralisController.Initialize();
        }
        else
        {
            // Moralis values not set or initialized.
            Debug.LogError("The MoralisInterface has not been set up, please check you MoralisController in the scene.");
        }

        // Invoke events if the user is logged in our out
        if (MoralisInterface.IsLoggedIn())
        {
            if(OnIsLoggedInIsTrue != null)
            {
                OnIsLoggedInIsTrue.Invoke();
            }
        }
        else
        {
            if(OnUserFromSessionIsFalse != null)
            {
                OnUserFromSessionIsFalse.Invoke();
            }
        }   
    }

    public void MetaMaskConnect()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
        UnityMoralisAuthenticate();
        #endif
    }

    public async UniTask setUserSession(string sessionToken)
    {        
        MoralisUser user = await MoralisInterface.GetClient().UserFromSession(sessionToken);
        
         // Invoke events if the UserFromSession succeeded or failed
        if (user != null)
        {
            if(OnUserFromSessionIsTrue != null)
            {
                OnUserFromSessionIsTrue.Invoke();
            }    
        }
        else
        {
            if(OnUserFromSessionIsFalse != null)
            {
                OnUserFromSessionIsFalse.Invoke();
            }
        }
    }
    #endif
}