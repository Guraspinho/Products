using System.Reflection.Metadata.Ecma335;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;

namespace WebApiSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        ProductsService _productsService;
        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpPost("/create")]
        public void CreateProduct(ProductModel product)
        {
            _productsService.CreateProduct(product);
        }

        [HttpGet("/get")]
        public List<ProductModel> GetProducts()
        {
            return _productsService.GetProducts();
        }

        [HttpGet("/get/{id}")]
        public ProductModel GetProductById(int id)
        {
            return _productsService.GetProductById(id);
        }

        [HttpGet("/search")]
        public List<ProductModel> GetProductByCategory([FromQuery] int categoryId)
        {
            return _productsService.GetProductByCategory(categoryId);
        }

        [HttpGet("/by-category")]
        public decimal GetProductPriceByCategory([FromQuery] int categoryId)
        {
            return _productsService.GetProductPriceByCategory(categoryId); 
        }

        [HttpGet("/price")]
        public List<decimal> GetProductPricePerCategory()
        {
            return _productsService.GetProductPricePerCategory();
        }

        [HttpPut("/update")]
        public void UpdateProduct(ProductModel product)
        {
           _productsService.UpdateProduct(product);

        }


        [HttpDelete("/delete/{id}")]
        public void DeleteProduct(int id)
        {
            _productsService.DeleteProduct(id);
        }
    }
}
