using IMC.Product.Dto;
using IMC.Product.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMC.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductUow _unitOfWork;
        public ProductController(IProductUow unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _unitOfWork.GetAll();

            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _unitOfWork.GetByIdAsync(id);

            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto newProduct)
        {
            var isAdded = await _unitOfWork.AddAsync(newProduct);

            return Ok(isAdded);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto)
        {
            await _unitOfWork.UpdateAsync(productDto);

            return Ok();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _unitOfWork.DeleteAsync(id);

            return Ok(isDeleted);
        }
    }
}
