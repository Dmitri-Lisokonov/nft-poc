using MyNFT.Contracts.MyNFT;
using MyNFT.Contracts.MyNFT.ContractDefinition;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;


namespace poc_nft
{
    public class ContractFactory
    {
        public async Task<MyNFTService> CreateContract(string address)
        {
            //Account account = new Account(address, chainId: 5777);
            //Web3 web3 = new Web3(account, "HTTP://127.0.0.1:7545");
            //web3.Eth.TransactionManager.UseLegacyAsDefault = true;
            //MyNFTDeployment NftInstance = new MyNFTDeployment();
            //MyNFTService.DeployContractAsync(web3, NftInstance);
            return null;
        }
    }
}
