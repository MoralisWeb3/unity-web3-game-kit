/**
 *           Module: MoralisInterface.cs
 *  Descriptiontion: Class that wraps moralis integration points. Provided as an 
 *                   example of how Moralis can be integrated into Unity
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
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Moralis;
using Moralis.Web3Api.Client;
using Moralis.Platform;
using Moralis.Platform.Objects;
using Assets.Scripts;
using Assets.Scripts.Moralis;

/// <summary>
/// Class that wraps moralis integration points. Provided as an example of 
/// how Moralis can be integrated into Unity
/// </summary>
public class MoralisInterface : MonoBehaviour
{
    // Singleton instance of Moralis so that is it is available application 
    // wide after being initialized.
    private static MoralisClient moralis;
    private static ServerConnectionData connectionData;
    // Since the user object is used so often, once the user is authenticated 
    // keep a local copy to save some cycles.
    private static MoralisUser user;

    /// <summary>
    /// Initializes the connection to a Moralis server.
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="serverUri"></param>
    /// <param name="hostData"></param>
    /// <param name="web3ApiKey"></param>
    public static void Initialize(string applicationId, string serverUri, HostManifestData hostData, string web3ApiKey = null)
    {
        // Application Id is requried.
        if (string.IsNullOrEmpty(applicationId))
        {
            Debug.LogError("Application Id is required.");
            throw new ArgumentException("Application Id was not supplied.");
        }
        // Server URI is required.
        if(string.IsNullOrEmpty(serverUri))
        {
            Debug.LogError("Server URI is required.");
            throw new ArgumentException("Server URI was not supplied.");
        }

        // CHeck that requried Host data properties are set.
        if (hostData == null || 
            string.IsNullOrEmpty(hostData.Version) || 
            string.IsNullOrEmpty(hostData.Name) || 
            string.IsNullOrEmpty(hostData.ShortVersion) || 
            string.IsNullOrEmpty(hostData.Identifier))
        {
            Debug.LogError("Complete host manifest data are required.");
            throw new ArgumentException("Complete host manifest data was not supplied.");
        }

        // Set Moralis conenction values.
        connectionData = new ServerConnectionData();
        connectionData.ApplicationID = applicationId;
        connectionData.ServerURI = serverUri;
        connectionData.ApiKey = web3ApiKey;

        // For unity apps the local storage value must also be set.
        connectionData.LocalStoragePath = Application.persistentDataPath;

        Debug.Log($"Set LocalStoragePath to {connectionData.LocalStoragePath}");

        // TODO Make this optional!
        connectionData.Key = "";

        Debug.Log("Connecting to Moralis ...");

        // Set manifest / host data required so that the Moralis Client does not
        // attempt to infer them from Assembly values not available in Unity.
        MoralisClient.ManifestData = hostData;

        // Define a Unity specific Json Serializer.
        UnityNewtosoftSerializer jsonSerializer = new UnityNewtosoftSerializer();

        // Create an instance of Moralis Server Client
        // NOTE: Web3ApiClient is optional. If you are not using the Moralis 
        // Web3Api REST API you can call the method with just connectionData
        // NOTE: If you are using a custom user object use 
        // new MoralisClient<YourUser>(connectionData, address, Web3ApiClient)
        moralis = new MoralisClient(connectionData, new Web3ApiClient(), jsonSerializer);

        if (moralis == null)
        { 
            Debug.Log("Moralis connection failed!"); 
        }
        else
        {
            Debug.Log("Connected to Moralis!");
            user = moralis.GetCurrentUser();
        }
    }

    /// <summary>
    /// Properly dispose Moralis Client, shuts down any subscriptions, etc.
    /// </summary>
    public static void Dispose() 
    { 
        moralis.Dispose(); 
    }

    /// <summary>
    /// Get the Moralis Server Client.
    /// </summary>
    /// <returns></returns>
    public static MoralisClient GetClient() 
    { 
        return moralis; 
    }

    /// <summary>
    /// Provides the current authenticated user if Moralis 
    /// authentication has been completed.
    /// </summary>
    /// <returns>MoralisUser</returns>
    public static MoralisUser GetUser()
    {
        if (user == null)
        {
            user = moralis.GetCurrentUser();
        }

        return user;
    }

    /// <summary>
    /// Idicates if user is already logged in.
    /// </summary>
    /// <returns></returns>
    public static bool IsLoggedIn() { return user != null; }

    /// <summary>
    /// Authenicate the user by logging into Moralis using message signed by 
    /// Crypto Wallat. If this is a new user, the user's record is automatically 
    /// created.
    /// EXAMPLE: { { "id", address }, { "signature", response }, { "data", "Moralis Authentication" } }
    /// </summary>
    /// <param name="authData"></param>
    /// <returns></returns>
    public static Task<MoralisUser> LogInAsync(IDictionary<string, object> authData) 
    { 
        return moralis.LogInAsync(authData, CancellationToken.None); 
    }

    /// <summary>
    /// Logout the user session.
    /// </summary>
    /// <returns></returns>
    public static Task LogOutAsync()
    {
        return moralis.LogOutAsync();
    }

    /// <summary>
    /// Provide quick access to the Moralis Web3API Supported chains list.
    /// </summary>
    public static List<ChainEntry> SupportedChains => SupportedEvmChains.SupportedChains;
}
