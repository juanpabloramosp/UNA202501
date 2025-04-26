using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }


        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            var result = _productService.GetAll();

            return result;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductDTO Get(int id)
        {
            var result = _productService.Get(id);
            return result;
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductDTO product)
        {
            _productService.Add(product);

        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public void Put([FromBody] ProductDTO product)
        {
            _productService.Update(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.Delete(id);
        }
    }
}
