using MoralisUnity.Kits.AuthenticationKit;
using UnityEngine;

namespace MoralisUnity.Demos.Knight
{
    public class ViewSwitchController : MonoBehaviour
    {

        [SerializeField]
        private GameObject authenticationKitObject = null;

        [SerializeField]
        private GameObject gameUiObject = null;

        private AuthenticationKit authKit = null;

        private void Start()
        {
            authKit = authenticationKitObject.GetComponent<AuthenticationKit>();
        }

        public void Authentication_OnConnect()
        {
            authenticationKitObject.SetActive(false);
            gameUiObject.SetActive(true);
        }

        public void LogoutButton_OnClicked()
        {
            // Logout the Moralis User.
            authKit.Disconnect();

            authenticationKitObject.SetActive(true);
            gameUiObject.SetActive(false);
        }
    }
}
