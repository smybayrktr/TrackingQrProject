using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class InMemoryBlockchainDal : IBlockchainDal
    {
        List<Blockchain> _blockchains;

        public InMemoryBlockchainDal()
        {
            _blockchains = new List<Blockchain>()
            {
                new Blockchain{Chain = new List<Block>{new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 1,ProductName="Elma",ProductDescription = "Elma aciklama",UnitPrice = 0.22})}},
                new Blockchain{Chain = new List<Block>{new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 2,ProductName="Armut",ProductDescription = "Armut aciklama",UnitPrice = 0.22})}},
                new Blockchain{Chain = new List<Block>{new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 3,ProductName="Karpuz",ProductDescription = "Karpuz aciklama",UnitPrice = 0.22})}},
                new Blockchain{Chain = new List<Block>{new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 4,ProductName="Karpuz",ProductDescription = "Karpuz aciklama",UnitPrice = 0.22})}},
                new Blockchain{Chain = new List<Block>{new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 5,ProductName="Patates",ProductDescription = "Patates aciklama",UnitPrice = 0.22})}}
            };
        }

        public List<Blockchain> GetAll(Expression<Func<Blockchain, bool>> filter = null)
        {
            return _blockchains;
        }

        public Blockchain Get(Expression<Func<Blockchain, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Blockchain entity)
        {
            _blockchains.Add(entity);
        }

        public void Update(Blockchain entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blockchain entity)
        {
            throw new NotImplementedException();

        }

        public IDataResult<Blockchain> GetByProductId(int id)
        {
            var ent = _blockchains.SingleOrDefault(b => b.Chain[0].Data.ProductId == id);
            if (ent==null)
            {
                return new ErrorDataResult<Blockchain>(ent);
            }

            return new SuccessDataResult<Blockchain>(ent);
        }
    }
}