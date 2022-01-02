/**
 *           Module: MoralisSetup.cs
 *  Descriptiontion: Example class that demonstrates a game menu that incorporates
 *                   Wallet Connect and Moralis Authentication.
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
#if UNITY_WEBGL
using Moralis.WebGL.Platform;
using System.Collections.Generic;
#else
using Moralis.Platform;
using System.Collections.Generic;
#endif
using UnityEngine;

public class MoralisSetup : MonoBehaviour
{
    public string MoralisApplicationId;
    public string MoralisServerURI;
    public string ApplicationName;
    public string Version;

    async void Start()
    {
        HostManifestData hostManifestData = new HostManifestData()
        {
            Version = Version,
            Identifier = ApplicationName,
            Name = ApplicationName,
            ShortVersion = Version
        };

        await MoralisInterface.Initialize(MoralisApplicationId, MoralisServerURI, hostManifestData);

        var authData = new Dictionary<string, object> { { "id", "0x26841E928b5b89BB257CCCeC06d8d63951f2507b".ToLower() }, { "signature", "0x7589245bd712ccdcaa9f946c1052b169569fecaf5beed44d916acc0361be16b63f9ad8fb8526c276a1869a314ca7f9a0becee334aadca2e62ccd656cd1379c041b" }, { "data", "Moralis Authentication" } };
        await MoralisInterface.GetClient().LogInAsync(authData);
    }
}
