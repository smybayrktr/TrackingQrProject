using System;
using Business.Concrete;
using Entities.Concrete;
using Newtonsoft.Json;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockchainManager bm = new BlockchainManager();
            var bc = bm.InitializeBlockchain().Data;
            bm.AddBlock(bc.Chain,new Block(DateTime.Now, null, "{sender:Henry,receiver:MaHesh,amount:10}"));  
            bm.AddBlock(bc.Chain,new Block(DateTime.Now, null, "{sender:MaHesh,receiver:Henry,amount:5}"));  
            bm.AddBlock(bc.Chain,new Block(DateTime.Now, null, "{sender:Mahesh,receiver:Henry,amount:5}"));  
  
            Console.WriteLine(JsonConvert.SerializeObject(bc, Formatting.Indented));

            var a =bm.IsValid(bc.Chain);
            Console.WriteLine($"{a.Data}");
        }
    }
}