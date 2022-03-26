using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Blockchain  
    {  
        public List<Block> Chain { set;  get; }  
  
        public Blockchain()  
        {  
            InitializeChain();  
            AddGenesisBlock();  
        }  
  
  
        public void InitializeChain()  
        {  
            Chain = new List<Block>();  
        }  
  
        public Block CreateGenesisBlock()  
        {  
            return new Block(DateTime.Now, null, "{}");  
        }  
  
        public void AddGenesisBlock()  
        {  
            Chain.Add(CreateGenesisBlock());  
        }  
        
    }  
}