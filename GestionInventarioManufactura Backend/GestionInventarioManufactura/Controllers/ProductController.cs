using GestionInventarioManufactura.Dtos;
using GestionInventarioManufactura.Interfaces;
using GestionInventarioManufactura.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionInventarioManufactura.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct([FromQuery] int pageNumber = 1, int pageSize = 10)
        {
            var paginatedProduct = await _productServices.GetAllProduct( pageNumber,  pageSize);
            return Ok(paginatedProduct);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById( int id)
        {
            var product = await _productServices.GetById(id);
            return Ok(product);
        }

       
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] IEnumerable<ProductDto> products)
        {
            var response = await _productServices.SaveProducts(products);
            return Ok(response);
        }

      
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto updatePorductDto)
        {
            var response = await _productServices.UpdateProduct(id, updatePorductDto);
            return Ok(response);
        }

        [HttpPatch("changesStatus/{id}")]
        public async Task<IActionResult> changesStatus(int id)
        {
            var response = await _productServices.ChangeStatus(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productServices.DeleteProduct(id);
            return Ok(response);
        }
    }
}
