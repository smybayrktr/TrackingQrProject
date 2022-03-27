using System;
using System.Collections.Generic;
using Core.Entities;

namespace Entities.Concrete
{
    public class Blockchain:IEntity
    {
        public int BlockchainId { get; set; }
        public List<Block> Chain { set;  get; }  
  
        public Blockchain()  
        {  
            InitializeChain();            
        }  
  
  
        public void InitializeChain()  
        {  
            Chain = new List<Block>();  
        }  
  
        public Block CreateGenesisBlock()  
        {  
            return new Block(DateTime.Now, null, null);  
        }  
  
        public void AddGenesisBlock()  
        {  
            Chain.Add(CreateGenesisBlock());  
        }  
        
    }  
}