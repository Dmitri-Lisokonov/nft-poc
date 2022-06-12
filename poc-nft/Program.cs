using MyNFT.Contracts.MyNFT;
using MyNFT.Contracts.MyNFT.ContractDefinition;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.Text;

Console.WriteLine("--------------NFT-POC--------------");
Console.WriteLine("Select one of these options:");
Console.WriteLine("1: Create contract");
Console.WriteLine("2: Create NFT");
Console.WriteLine("3: Check balance");
Console.WriteLine("4: Transfer NFT");
Console.WriteLine("-----------------------------------");
var selection = Convert.ToInt32(Console.ReadLine());


// Setup
string privateKey = "f182e64b90499730b2a17918589352f2a4e051f7bb334c8762bd887d2ff03c5a";
string userAddress = "0xc6A8cE43B5928866C95083ae97cae2b0518B6FB6";
string contract = "0xaC72099b3660d215b3e7C21f0ECf6a5a25d02181";
Account account = new Account(privateKey, chainId: 5777);
Web3 web3 = new Web3(account, "HTTP://127.0.0.1:7545");
web3.Eth.TransactionManager.UseLegacyAsDefault = true;

if(selection == 1)
{
    // Create Contract
    MyNFTDeployment NftInstance = new MyNFTDeployment();
    await MyNFTService.DeployContractAndGetServiceAsync(web3, NftInstance);
    Console.WriteLine("You created a new contract");
}
else if (selection == 2)
{
    MyNFTDeployment NftInstance = new MyNFTDeployment();
    var service = new MyNFTService(web3, contract);
    string data = "my new NFT!";
    Random random = new Random();
    var something = await service.MintRequestAndWaitForReceiptAsync(userAddress, 1, Encoding.ASCII.GetBytes(data));
    Console.WriteLine("NFT Created");
}
else if(selection == 3)
{
    MyNFTDeployment NftInstance = new MyNFTDeployment();
    var service = new MyNFTService(web3, contract);
    var balance = await service.BalanceOfQueryAsync(userAddress);
    Console.WriteLine($"You currently own {balance} NFTs");

}
else if(selection == 4)
{
    MyNFTDeployment NftInstance = new MyNFTDeployment();
    var service = new MyNFTService(web3, contract);
    Console.WriteLine("Send to address:");
    var to = Console.ReadLine();
    Console.WriteLine("Token id:");
    var token = Convert.ToInt32(Console.ReadLine());
    await service.TransferFromRequestAndWaitForReceiptAsync(userAddress, to, token);
    Console.WriteLine("Transfer successfull");
}


