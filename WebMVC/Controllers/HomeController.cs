using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Newtonsoft.Json;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBlockchainService _blockchainService;

        public HomeController(ILogger<HomeController> logger, IBlockchainService blockchainService)
        {
            _logger = logger;
            _blockchainService = blockchainService;
        }

        public IActionResult Products(string chain)
        {
            var bc = JsonConvert.DeserializeObject<Blockchain>(chain);
            return View(bc);
        }
        public IActionResult Where()
        {
            var data = TempData["blockchain"];
            var chain = JsonConvert.DeserializeObject<Blockchain>((string)data);
            return View(chain);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitQr(BlockchainViewModel bvm)
        {
            var chains = _blockchainService.GetAll().Data;
            foreach (var chain in chains)    
            {
                if (chain.Chain[1].Data.ProductId==bvm.Id)
                {
                    TempData["blockchain"] = JsonConvert.SerializeObject(chain);
                    return RedirectToAction("Where", "Home",chain);
                }
            }
            return RedirectToAction("Index","Home");
        }
    }
}
