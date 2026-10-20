using Microsoft.AspNetCore.Mvc;
using WebShoppie.Api.Contracts.Customer;
using WebShoppie.Api.Contracts.Products;
using WebShoppieAalst.Domain.Services.Implementations;
using WebShoppieAalst.Domain.Services.Interfaces;

namespace WebShoppieAalst.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(IProductService _productService) : ControllerBase
    {
        [HttpPost]
        public ActionResult<ProductResponseContract> CreateProduct([FromBody] ProductRequestContract product)
        {
            return Ok(_productService.CreateProduct(product));
        }

        [HttpGet("{id}")]
        public ActionResult<ProductResponseContract> GetProductById([FromRoute] int id)
        {
            var product = _productService.GetProductById(id);
            if (product is not null)
                return Ok(product);
            return NotFound();
        }
    }
}
