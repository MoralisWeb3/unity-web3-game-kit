using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using Moralis.Web3Api.Client;
using Moralis.Web3Api.Interfaces;
using Moralis.Web3Api.Models;

namespace Moralis.Web3Api.Api
{
	/// <summary>
	/// Represents a collection of functions to interact with the API endpoints
	/// </summary>
	public class DefiApi : IDefiApi
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DefiApi"/> class.
		/// </summary>
		/// <param name="apiClient"> an instance of ApiClient (optional)</param>
		/// <returns></returns>
		public DefiApi(ApiClient apiClient = null)
		{
			if (apiClient == null) // use the default one in Configuration
				this.ApiClient = Configuration.DefaultApiClient; 
			else
				this.ApiClient = apiClient;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DefiApi"/> class.
		/// </summary>
		/// <returns></returns>
		public DefiApi(String basePath)
		{
			this.ApiClient = new ApiClient(basePath);
		}

		/// <summary>
		/// Sets the base path of the API client.
		/// </summary>
		/// <param name="basePath">The base path</param>
		/// <value>The base path</value>
		public void SetBasePath(String basePath)
		{
			this.ApiClient.BasePath = basePath;
		}

		/// <summary>
		/// Gets the base path of the API client.
		/// </summary>
		/// <param name="basePath">The base path</param>
		/// <value>The base path</value>
		public String GetBasePath(String basePath)
		{
			return this.ApiClient.BasePath;
		}

		/// <summary>
		/// Gets or sets the API client.
		/// </summary>
		/// <value>An instance of the ApiClient</value>
		public ApiClient ApiClient {get; set;}


		/// <summary>
		/// Get the liquidity reserves for a given pair address
		/// </summary>
		/// <param name="pairAddress">Liquidity pair address</param>
		/// <param name="chain">The chain to query</param>
		/// <param name="toBlock">To get the reserves at this block number</param>
		/// <param name="toDate">Get the reserves to this date (any format that is accepted by momentjs)
		/// * Provide the param 'to_block' or 'to_date'
		/// * If 'to_date' and 'to_block' are provided, 'to_block' will be used.
		/// </param>
		/// <param name="providerUrl">web3 provider url to user when using local dev chain</param>
		/// <returns>Returns the pair reserves</returns>
		public ReservesCollection GetPairReserves (string pairAddress, ChainList chain, string toBlock=null, string toDate=null, string providerUrl=null)
		{

			// Verify the required parameter 'pairAddress' is set
			if (pairAddress == null) throw new ApiException(400, "Missing required parameter 'pairAddress' when calling GetNFTs");

			var postBody = new Dictionary<String, String>();
			var queryParams = new Dictionary<String, String>();
			var headerParams = new Dictionary<String, String>();
			var formParams = new Dictionary<String, String>();
			var fileParams = new Dictionary<String, FileParameter>();

			var path = "/{pair_address}/reserves";
			path = path.Replace("{format}", "json");
			path = path.Replace("{" + "pairAddress" + "}", ApiClient.ParameterToString(pairAddress));
			if(chain != null) queryParams.Add("chain", ApiClient.ParameterToString(chain));
			if(toBlock != null) queryParams.Add("toBlock", ApiClient.ParameterToString(toBlock));
			if(toDate != null) queryParams.Add("toDate", ApiClient.ParameterToString(toDate));
			if(providerUrl != null) queryParams.Add("providerUrl", ApiClient.ParameterToString(providerUrl));

			// Authentication setting, if any
			String[] authSettings = new String[] { "ApiKeyAuth" };

			string bodyData = postBody.Count > 0 ? JsonConvert.SerializeObject(postBody) : null;

			IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, bodyData, headerParams, formParams, fileParams, authSettings);

			if (((int)response.StatusCode) >= 400)
				throw new ApiException((int)response.StatusCode, "Error calling GetNFTs: " + response.Content, response.Content);
			else if (((int)response.StatusCode) == 0)
				throw new ApiException((int)response.StatusCode, "Error calling GetNFTs: " + response.ErrorMessage, response.ErrorMessage);

			return (ReservesCollection)ApiClient.Deserialize(response.Content, typeof(ReservesCollection), response.Headers);
		}
		/// <summary>
		/// Fetches and returns pair data of the provided token0+token1 combination.
		/// The token0 and token1 options are interchangable (ie. there is no different outcome in "token0=WETH and token1=USDT" or "token0=USDT and token1=WETH")
		/// 
		/// </summary>
		/// <param name="exchange">The factory name or address of the token exchange</param>
		/// <param name="token0Address">Token0 address</param>
		/// <param name="token1Address">Token1 address</param>
		/// <param name="chain">The chain to query</param>
		/// <param name="toBlock">To get the reserves at this block number</param>
		/// <param name="toDate">Get the reserves to this date (any format that is accepted by momentjs)
		/// * Provide the param 'to_block' or 'to_date'
		/// * If 'to_date' and 'to_block' are provided, 'to_block' will be used.
		/// </param>
		/// <returns>Returns the pair address of the two tokens</returns>
		public ReservesCollection GetPairAddress (string exchange, string token0Address, string token1Address, ChainList chain, string toBlock=null, string toDate=null)
		{

			// Verify the required parameter 'exchange' is set
			if (exchange == null) throw new ApiException(400, "Missing required parameter 'exchange' when calling GetNFTs");

			// Verify the required parameter 'token0Address' is set
			if (token0Address == null) throw new ApiException(400, "Missing required parameter 'token0Address' when calling GetNFTs");

			// Verify the required parameter 'token1Address' is set
			if (token1Address == null) throw new ApiException(400, "Missing required parameter 'token1Address' when calling GetNFTs");

			var postBody = new Dictionary<String, String>();
			var queryParams = new Dictionary<String, String>();
			var headerParams = new Dictionary<String, String>();
			var formParams = new Dictionary<String, String>();
			var fileParams = new Dictionary<String, FileParameter>();

			var path = "/{token0_address}/{token1_address}/pairAddress";
			path = path.Replace("{format}", "json");
			path = path.Replace("{" + "token0Address" + "}", ApiClient.ParameterToString(token0Address));			path = path.Replace("{" + "token1Address" + "}", ApiClient.ParameterToString(token1Address));
			if(exchange != null) queryParams.Add("exchange", ApiClient.ParameterToString(exchange));
			if(chain != null) queryParams.Add("chain", ApiClient.ParameterToString(chain));
			if(toBlock != null) queryParams.Add("toBlock", ApiClient.ParameterToString(toBlock));
			if(toDate != null) queryParams.Add("toDate", ApiClient.ParameterToString(toDate));

			// Authentication setting, if any
			String[] authSettings = new String[] { "ApiKeyAuth" };

			string bodyData = postBody.Count > 0 ? JsonConvert.SerializeObject(postBody) : null;

			IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, bodyData, headerParams, formParams, fileParams, authSettings);

			if (((int)response.StatusCode) >= 400)
				throw new ApiException((int)response.StatusCode, "Error calling GetNFTs: " + response.Content, response.Content);
			else if (((int)response.StatusCode) == 0)
				throw new ApiException((int)response.StatusCode, "Error calling GetNFTs: " + response.ErrorMessage, response.ErrorMessage);

			return (ReservesCollection)ApiClient.Deserialize(response.Content, typeof(ReservesCollection), response.Headers);
		}
	}
}
