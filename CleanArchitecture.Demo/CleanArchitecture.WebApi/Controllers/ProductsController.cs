using CleanArchitecture.Application;
using CleanArchitecture.Application.DTOs.Product;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Application.Interfaces.UnitOfWork;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService _productService)
        {
            this._productService = _productService;
        }

        [HttpGet]
        public ActionResult<List<ProductDetailsDto>> GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
            } 
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server Error, {ex.Message}");
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDetailsDto> GetProduct([FromRoute]int id)
        {
            try
            {
                var product = _productService.GetProduct(id);

                if(product is null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server Error, {ex.Message}");
            }
        }

        [HttpPost("add")]
        public ActionResult AddProduct([FromBody] CreateProductDto product)
        {
            
            var Result = _productService.AddProduct(product);

            if(Result == (int)OperationStatus.SuccessfullyDone)
                return CreatedAtAction(nameof(GetProduct), product);
            else
                return StatusCode(500, $"Internal server Error");

        }

        [HttpPost("update/{id}")]
        public ActionResult<Product> UpdateProduct([FromRoute]int id, [FromBody] CreateProductDto product)
        {
            
            var Result = _productService.UpdateProduct(id, product);

            if(Result == (int)OperationStatus.NotFound)
                return NotFound();
            else if(Result == (int)OperationStatus.SuccessfullyDone)
                return Ok(product);
            else
                return StatusCode(500, $"Internal server Error");
        }
        [HttpDelete("delete/{id}")]

        public ActionResult<Product> deleteProduct([FromRoute]int id)
        {

            var Result = _productService.deleteProduct(id);

            if (Result == (int)OperationStatus.SuccessfullyDone)
                return NoContent();
            else
                return StatusCode(500, $"Internal server Error");
            
        }
    }
}
