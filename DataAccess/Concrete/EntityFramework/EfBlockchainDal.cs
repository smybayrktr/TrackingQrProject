using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlockchainDal:EfEntityRepositoryBase<Blockchain,TrackingQrContext>,IBlockchainDal
    {
        public Blockchain GetByProductId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}