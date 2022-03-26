using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBlockchainDal:IEntityRepository<Blockchain>
    {
        Blockchain GetByProductId(int id);
    }
}