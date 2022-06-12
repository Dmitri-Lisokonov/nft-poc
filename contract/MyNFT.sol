// contracts/MyNFT.sol
// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";

contract MyNFT is ERC721 {
    constructor() ERC721("MyNFT", "MNFT") {}

    function mint(
        address _to,
        uint256 _tokenId,
        bytes memory data
    ) public {
        ERC721._safeMint(_to, _tokenId, data);
    }
}
