using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBlockchainDal:IEntityRepository<Blockchain>
    {
        IDataResult<Blockchain> GetByProductId(int id);
    }
}