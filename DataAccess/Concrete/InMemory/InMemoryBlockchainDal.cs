using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBlockchainDal : IBlockchainDal
    {
        List<Blockchain> _blockchains;

        public InMemoryBlockchainDal()
        {
            var bc1 = new Blockchain();
            bc1.InitializeChain();
            bc1.Chain.Add(bc1.CreateGenesisBlock());
            AddBlock(bc1.Chain,new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 1,ProductName="Elma",ProductDescription = "Hasat yapıldı.",UnitPrice = 0.22}));
            AddBlock(bc1.Chain,new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 1,ProductName="Elma",ProductDescription = "Amasyadan yola çıktı.",UnitPrice = 0.29}));
            AddBlock(bc1.Chain,new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 1,ProductName="Elma",ProductDescription = "Ankaraya vardı.",UnitPrice = 0.35}));
            var bc2 = new Blockchain();
            bc2.InitializeChain();
            bc2.Chain.Add(bc1.CreateGenesisBlock());
            AddBlock(bc2.Chain,new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 2,ProductName="Armut",ProductDescription = "Hasat yapıldı.",UnitPrice = 0.34}));
            AddBlock(bc2.Chain,new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 2,ProductName="Armut",ProductDescription = "Yola çıktı.",UnitPrice = 0.74}));
            var bc3 = new Blockchain();
            bc3.InitializeChain();
            bc3.Chain.Add(bc1.CreateGenesisBlock());
            AddBlock(bc3.Chain,new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 3,ProductName="Karpuz",ProductDescription = "Hasat yapıldı.",UnitPrice = 0.90}));
            AddBlock(bc3.Chain,new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 3,ProductName="Karpuz",ProductDescription = "Diyarbakırdan yola çıktı.",UnitPrice = 1.14}));
            AddBlock(bc3.Chain,new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 3,ProductName="Karpuz",ProductDescription = "Alıcıya ulaştı.",UnitPrice = 2.20}));
            var bc4 = new Blockchain();
            bc4.InitializeChain();
            bc4.Chain.Add(bc1.CreateGenesisBlock());
            AddBlock(bc4.Chain,new Block(DateTime.Now,null,new Product{Guid = Guid.NewGuid(),ProductId = 4,ProductName="Domates",ProductDescription = "Hasat yapıldı.",UnitPrice = 0.23}));
            _blockchains = new List<Blockchain>()
            {
               bc1,bc2,bc3,bc4
            };
        }

        public List<Blockchain> GetAll(Expression<Func<Blockchain, bool>> filter = null)
        {
            return _blockchains;
        }
        public void AddBlock(List<Block> chain,Block block)
        {
            Block latestBlock = chain[chain.Count-1];  
            block.Index = latestBlock.Index + 1;  
            block.PreviousHash = latestBlock.Hash;  
            block.Hash = block.CalculateHash();  
            chain.Add(block);
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

        public Blockchain GetByProductId(int id)
        {
            var ent = _blockchains.SingleOrDefault(b => b.Chain[0].Data.ProductId == id);
            if (ent==null)
            {
                return null;
            }

            return ent;
        }
    }
}