using Moralis.Platform.Objects;
using Moralis.Web3Api.Models;
using UnityEngine;
using UnityEngine.UI;

public class WalletBalanceController : MonoBehaviour
{
    /// <summary>
    /// Text used to display the account address
    /// </summary>
    public Text addressText;

    /// <summary>
    /// Text to display the native balance
    /// </summary>
    public Text balanceText;

    /// <summary>
    /// Chain ID to fetch tokens from. Might be better to make this
    /// a drop down that is selectable at run time.
    /// </summary>
    public int ChainId;

    // Update is called once per frame
    public void PopulateBalanceValues()
    {
        // Get user object and display user name
        MoralisUser user = MoralisInterface.GetUser();

        if (user != null)
        {
            string addr = user.authData["moralisEth"]["id"].ToString();

            addressText.text = addr;

            NativeBalance bal =
                MoralisInterface.GetClient().Web3Api.Account.GetNativeBalance(addr.ToLower(),
                                            (ChainList)ChainId);
            double balance = 0.0;
            
            if (bal != null && !string.IsNullOrWhiteSpace(bal.Balance))
            {
                double.TryParse(bal.Balance, out balance);
            }

            balanceText.text = string.Format("{0:0.#####}", balance / (double)Mathf.Pow(10.0f, 18.0f));
        }
        else
        {
            balanceText.text = "0";
        }
    }
}
