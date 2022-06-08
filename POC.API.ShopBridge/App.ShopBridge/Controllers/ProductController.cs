using App.ShopBridge.Models;
using App.ShopBridge.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.ShopBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly ProductService productService;
        private readonly IConfiguration configuration;
        private readonly string connString;

        public ProductController(ILogger<ProductController> logger, ProductService productService, IConfiguration configuration)
        {
            this.logger = logger;
            this.productService = productService;
            this.configuration = configuration;
            connString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        // GET: api/<ShoBridgeController>
        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> Get()
        {
            try
            {
                var result = await this.productService.Get(connString);
                if (result is null)
                { 
                    return BadRequest("Result is null");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ShoBridgeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductModel>>> Get(int id)
        {
            try
            {
                var result = await this.productService.Get(id, connString);
                if (result is null)
                {
                    return BadRequest("Result is null");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ShoBridgeController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] ProductModel input)
        {
            try
            {
                var result = await this.productService.Post(input, connString);
                if (result is null)
                {
                    return BadRequest("Result is null");
                }
                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ShoBridgeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(int id, [FromBody] ProductModel input)
        {
            try
            {
                var result = await this.productService.Put(id, input, connString);
                if (result is null)
                {
                    return BadRequest("Result is null");
                }
                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ShoBridgeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                var result = await this.productService.Delete(id, connString);
                if (result is null)
                {
                    return BadRequest("Result is null");
                }
                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
