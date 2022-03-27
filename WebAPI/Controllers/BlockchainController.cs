using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockchainController:ControllerBase
    {
        private IBlockchainService _blockchainService;

        public BlockchainController(IBlockchainService blockchainService)
        {
            _blockchainService = blockchainService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _blockchainService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Blockchain chain)
        {
            var result = _blockchainService.Add(chain);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyproductid")]
        public IActionResult GetByProductId(int id)
        {
            var result = _blockchainService.GetByProductId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addblock")]
        public IActionResult AddBlock(AddBlockDto dto)
        {
            var result = _blockchainService.AddBlock(dto.Chain, dto.BlockToAdd);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
    }
}