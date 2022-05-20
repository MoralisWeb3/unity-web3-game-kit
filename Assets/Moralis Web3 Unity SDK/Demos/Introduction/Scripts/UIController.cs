using MoralisUnity;
using MoralisUnity.Kits.AuthenticationKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoralisUnity.Demos.Introduction
{
    public class UIController : MonoBehaviour
    {

        [SerializeField]
        private GameObject authenticationKitObject = null;

        [SerializeField]
        private GameObject congratulationUiObject = null;

        [SerializeField]
        private GameObject fireworksObject = null;

        private AuthenticationKit authKit = null;

        private void Start()
        {
            authKit = authenticationKitObject.GetComponent<AuthenticationKit>();
        }
        public void Authentication_OnConnect()
        {
            authenticationKitObject.SetActive(false);
            congratulationUiObject.SetActive(true);
            fireworksObject.SetActive(true);
        }

        public void LogoutButton_OnClicked()
        {
            // Logout the Moralis User.
            authKit.Disconnect();

            authenticationKitObject.SetActive(true);
            congratulationUiObject.SetActive(false);
            fireworksObject.SetActive(false);
        }
    }
}
