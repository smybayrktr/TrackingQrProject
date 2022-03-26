using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBlockchainService
    {
        IDataResult<bool> IsValid(List<Block> chain);
        IDataResult<Block> GetLatestBlock(List<Block> chain);
        IResult AddBlock(List<Block> chain,Block block);
        IDataResult<Blockchain> InitializeBlockchain();
    }
}