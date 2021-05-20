using IMC.Product.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMC.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProductUow _unitOfWork;
        public HomeController(IProductUow unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{search}")]
        public async Task<IActionResult> Get(string search)
        {
            var products = await _unitOfWork.GetBySearchAsync(search);

            return Ok(products);
        }
    }
}
