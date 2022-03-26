using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BlockchainManager:IBlockchainService
    {
        public IDataResult<bool> IsValid(List<Block> chain)
        {
            for (int i = 1; i < chain.Count; i++)  
            {  
                Block currentBlock = chain[i];  
                Block previousBlock = chain[i - 1];  
  
                if (currentBlock.Hash != currentBlock.CalculateHash())  
                {  
                    return new ErrorDataResult<bool>(false);  
                }  
  //proofofwork blockchain
                if (currentBlock.PreviousHash != previousBlock.Hash)  
                {  
                    return new ErrorDataResult<bool>(false); 
                }  
            }  
            return new SuccessDataResult<bool>(true);  
        }

        public IDataResult<Block> GetLatestBlock(List<Block> chain)
        {
            return new SuccessDataResult<Block>(chain[chain.Count - 1]);  
        }

        public IResult AddBlock(List<Block> chain,Block block)
        {
            Block latestBlock = GetLatestBlock(chain).Data;  
            block.Index = latestBlock.Index + 1;  
            block.PreviousHash = latestBlock.Hash;  
            block.Hash = block.CalculateHash();  
            chain.Add(block);
            return new SuccessResult();
        }

        public IDataResult<Blockchain> InitializeBlockchain()
        {
            Blockchain blockchain = new Blockchain();
            return new SuccessDataResult<Blockchain>(blockchain);
        }
    }
}