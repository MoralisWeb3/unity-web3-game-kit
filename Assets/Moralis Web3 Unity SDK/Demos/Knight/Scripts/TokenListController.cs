/**
 *           Module: MoralisSessionTokenResponse.cs
 *  Descriptiontion: Sample game controller that demonstrates how to use the Moralis 
 *                   Web3Api to retieve and display a list of ERC20 Tokens..
 *           Author: Moralis Web3 Technology AB, 559307-5988 - David B. Goodrich
 *  
 *  MIT License
 *  
 *  Copyright (c) 2021 Moralis Web3 Technology AB, 559307-5988
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in all
 *  copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *  SOFTWARE.
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using MoralisUnity.Platform.Objects;
using MoralisUnity.Web3Api.Models;
using MoralisUnity;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

namespace MoralisUnity.Demos.Knight
{
    /// <summary>
    /// Sample game controller that demonstrates how to use the Moralis Web3Api to retieve 
    /// and display a list of ERC20 Tokens..
    /// </summary>
    public class TokenListController : MonoBehaviour
    {
        /// <summary>
        /// Prefab of the item to draw the token to and show in the list.
        /// </summary>
        public GameObject ListItemPrefab;

        /// <summary>
        /// Vertical layout to hold the Token item list.
        /// </summary>
        public Transform TokenListTransform;

        /// <summary>
        /// Chain ID to fetch tokens from. Might be better to make this
        /// a drop down that is selectable at run time.
        /// </summary>
        public int ChainId;

        private bool tokensLoaded;

        public async void PopulateWallet()
        {
            if (!tokensLoaded)
            {
                // Make sure that duplicate tokens are not loaded.
                tokensLoaded = true;

                // Get user object and display user name
                MoralisUser user = await Moralis.GetUserAsync();

                List<Erc20TokenBalance> balances = await RetreiveBalances(user);

                await BuildTokenList(balances);
            }
        }

        private async UniTask<List<Erc20TokenBalance>> RetreiveBalances(MoralisUser user)
        {
            List<Erc20TokenBalance> tokens = new List<Erc20TokenBalance>();

            if (user != null)
            {
                string addr = user.ethAddress;

                tokens = await Moralis.GetClient().Web3Api.Account.GetTokenBalances(addr.ToLower(),
                                                (ChainList)ChainId);
            }

            return tokens;
        }

        async UniTask BuildTokenList(List<Erc20TokenBalance> tokens)
        {
            foreach (Erc20TokenBalance token in tokens)
            {
                // Ignor entry without symbol or without thumbnail image
                if (string.IsNullOrWhiteSpace(token.Symbol))
                {
                    continue;
                }

                // Create and add an Token button to the display list. 
                var tokenObj = Instantiate(ListItemPrefab, TokenListTransform);
                var tokenSymbol = tokenObj.GetFirstChildComponentByName<Text>("TokenSymbolText", false);
                var tokenBalanace = tokenObj.GetFirstChildComponentByName<Text>("TokenCountText", false);
                var tokenImage = tokenObj.GetFirstChildComponentByName<Image>("TokenThumbNail", false);
                var tokenButton = tokenObj.GetComponent<Button>();

                var parentTransform = TokenListTransform.GetComponent<RectTransform>();
                double balance = 0.0;
                float tokenDecimals = 18.0f;

                // Make sure a response to the balanace request weas received. The 
                // IsNullOrWhitespace check may not be necessary ...
                if (token != null && !string.IsNullOrWhiteSpace(token.Balance))
                {
                    double.TryParse(token.Balance, out balance);
                    float.TryParse(token.Decimals, out tokenDecimals);
                }

                tokenSymbol.text = token.Symbol;
                tokenBalanace.text = string.Format("{0:0.##} ", balance / (double)Mathf.Pow(10.0f, tokenDecimals));

                // When button clicked display theCoingecko page for that token.
                tokenButton.onClick.AddListener(delegate
                {
                // Display token CoinGecko page on click.
                Application.OpenURL($"https://coinmarketcap.com/currencies/{token.Name}");
                });

                // If token has a thumbnail image try to retrieve the image
                if (!string.IsNullOrWhiteSpace(token.Thumbnail))
                {
                    // Field(s) for the cloud function.
                    IDictionary<string, object> pars = new Dictionary<string, object>();
                    pars.Add("url", token.Thumbnail);
                    string bodyData = JsonConvert.SerializeObject(pars);

                    ResourceResponse resourceResponse = await Moralis.GetClient().Cloud.RunAsync<ResourceResponse>("loadResource", pars);

                    Texture2D tokenTexture = new Texture2D(64, 64);
                    ResourceData rData = resourceResponse.resourceData;

                    tokenTexture.LoadImage(rData.data);

                    var sprite = Sprite.Create(tokenTexture,
                                new Rect(0.0f, 0.0f, tokenTexture.width, tokenTexture.height),
                                new Vector2(0.75f, 0.75f), 100.0f);

                    tokenImage.sprite = sprite;
                }
            }
        }
    }
}
