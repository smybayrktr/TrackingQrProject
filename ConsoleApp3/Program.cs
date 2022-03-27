using System;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Newtonsoft.Json;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockchainManager bm = new BlockchainManager(new InMemoryBlockchainDal());
            var bc = bm.InitializeBlockchain().Data;
            bm.AddBlock(bc.Chain,new Block(DateTime.Now, null, new Product{ProductId = 1,ProductName = "test",UnitPrice = 10}));  
            bm.AddBlock(bc.Chain,new Block(DateTime.Now, null, new Product{ProductId = 1,ProductName = "test",UnitPrice = 10}));  
            bm.AddBlock(bc.Chain,new Block(DateTime.Now, null, new Product{ProductId = 1,ProductName = "test",UnitPrice = 10}));

            var list = bm.GetAll();
            Console.WriteLine(JsonConvert.SerializeObject(list.Data[0].Chain, Formatting.Indented));
            Console.WriteLine("---------------");
            bm.AddBlock(list.Data[0].Chain,
                new Block(DateTime.Now, null, new Product {ProductId = 1, ProductName = "test", UnitPrice = 10}));
            Console.WriteLine(JsonConvert.SerializeObject(list.Data[0].Chain, Formatting.Indented));
           
        }
    }
}