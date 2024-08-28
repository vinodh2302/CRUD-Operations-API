using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService  _productService;

        public ProductController(ILogger<ProductController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        [Route("api/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var results = await _productService.GetProducts();
                return Ok(results);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("api/products/{prodid}")]
        public async Task<ActionResult<Product>> GetProductsById([FromRoute] int prodid)
        {
            try
            {
                var results = await _productService.GetProductsById(prodid);
                if(results == null)
                {
                    return StatusCode(404, "Not Found");
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("api/products/name/{prodname}")]
        public async Task<ActionResult<Product>> GetProductsByName([FromRoute] string prodname)
        {
            try
            {
                var results = await _productService.GetProductsByName(prodname);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("api/products/count")]
        public async Task<ActionResult<Product>> GetProductsCount()
        {
            try
            {
                var results = await _productService.GetProductsCount();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message.ToString());
            }
        }



        [HttpPost]
        [Route("api/product/post")]
        public async Task<ActionResult<bool>> AddProduct([FromBody] Product p)
        {
            try
            {
                var results = await _productService.AddProduct(p);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("api/product/update")]
        public async Task<ActionResult<bool>> UpdateProduct([FromBody] Product p)
        {
            try
            {
                var results = await _productService.UpdateProduct(p);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("api/product/delete/{prodname}")]
        public async Task<ActionResult<bool>> DeleteProduct([FromRoute] string prodname)
        {
            try
            {
                var results = await _productService.DeleteProduct(prodname);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("api/product/deleteall")]
        public async Task<ActionResult<bool>> DeleteAll()
        {
            try
            {
                var results = await _productService.DeleteAll();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("api/product/sortbyname")]
        public async Task<ActionResult<IEnumerable<Product>>> SortProductByName()
        {
            try
            {
                var results = await _productService.SortProductsByNameDescending();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message.ToString());
            }
        }
    }
}