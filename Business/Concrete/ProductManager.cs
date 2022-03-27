using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IBlockchainService _blockchainService;
        public ProductManager(IProductDal productDal,IBlockchainService blockchainService)
        {
            _productDal = productDal;
            _blockchainService = blockchainService;
        }
        [SecuredOperation("product.add,admin")]
        //Metot çağırıldığında Attribute varmı diye bakar. Varsa gider attribute çalıştırır.
        [ValidationAspect(typeof(ProductValidator))] // Add metotunu ProductValidator a göre doğrulama yapar.
        [CacheRemoveAspect("IProductService.Get")]
        [TransactionScopeAspect]
        
        public IResult Add(Product product)
        {
            //IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
            //                                   CheckIfProductNameExists(product.ProductName), CheckIfCategoryLimitExceded());
            //if (result != null)
            //{
            //    return result;
            //}
            _productDal.Add(product);
            var bc =_blockchainService.InitializeBlockchain();
            if (!bc.Success)
            {
                return new ErrorResult(Messages.BlockchainCreateError);
            }
            product.Guid = Guid.NewGuid();
            _blockchainService.AddBlock(bc.Data.Chain, new Block(DateTime.Now, null,product));
            return new SuccessResult(Messages.ProductAdded);

        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //Buraya iş kodlarımızı, kurallarımızı yazdık eğer oluyorsa GetAll() tümünü listele dedik.
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(double min, double max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

       
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new SuccessResult(Messages.ProductNameAlreadyExists);
            }
            return new ErrorResult();
        }

        
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
    } 
}