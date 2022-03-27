using System.Collections.Generic;
using Core;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class AddBlockDto:IDto
    { 
        public List<Block> Chain { get; set; }
        public Block BlockToAdd { get; set; }
        
    }
}