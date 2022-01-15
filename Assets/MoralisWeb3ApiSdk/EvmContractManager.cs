/**
 *           Module: EvmContractManager.cs
 *  Descriptiontion: Creates a simple way to create and access a set of contracts by chain.
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
using System.Threading.Tasks;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;


namespace MoralisWeb3ApiSdk
{
    /// <summary>
    /// Creates a simple way to create and access a set of contracts by chain.
    /// </summary>
    public class EvmContractManager
    {
        /// <summary>
        /// All defined contract instances
        /// </summary>
        public Dictionary<string, EvmContractItem> Contracts { get; set; }

        public EvmContractManager()
        {
            Contracts = new Dictionary<string, EvmContractItem>();
        }

        /// <summary>
        /// Retreives a contract instance for a specified chain.
        /// </summary>
        /// <param name="contractKey"></param>
        /// <param name="chainId"></param>
        /// <returns></returns>
        public Contract GetContractInstance(string contractKey, string chainId)
        {
            Contract contract = null;

            if (Contracts.ContainsKey(contractKey))
            {
                if (Contracts[contractKey].ChainContractMap.ContainsKey(chainId))
                {
                    contract = Contracts[contractKey].ChainContractMap[chainId].ContractInstance;
                }
            }

            return contract;
        }

        /// <summary>
        /// Retrieves an instance of a contract function.
        /// </summary>
        /// <param name="contractKey"></param>
        /// <param name="chainId"></param>
        /// <param name="functionName"></param>
        /// <returns></returns>
        public Function GetContractFunction(string contractKey, string chainId, string functionName)
        {
            Function functionInstance = null;
            Contract contract = GetContractInstance(contractKey, chainId);

            if (contract != null)
            {
                functionInstance = contract.GetFunction(functionName);
            }

            return functionInstance;
        }

        /// <summary>
        /// Executes a contract SendTransaction, used for executing contract functions that change state.
        /// </summary>
        /// <param name="contractKey"></param>
        /// <param name="chainId"></param>
        /// <param name="functionName"></param>
        /// <param name="transactionInput"></param>
        /// <param name="functionInput"></param>
        /// <returns></returns>
        public async Task<string> SendTransactionAsync(string contractKey, string chainId, string functionName, TransactionInput transactionInput, object[] functionInput)
        {
            string result = null;

            Function targetFunction = GetContractFunction(contractKey, chainId, functionName);

            if (targetFunction != null)
            {
                result = await targetFunction.SendTransactionAsync(transactionInput, functionInput);
            }

            return result;
        }

    }
}
