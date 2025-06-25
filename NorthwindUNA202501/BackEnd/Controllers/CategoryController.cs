using BackEnd.DTO;
using BackEnd.Services.Interfaces;


using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        } 
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            return _categoryService.GetCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryDTO Get(int id)
        {
            return _categoryService.GetCategoryById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public CategoryDTO Post([FromBody]CategoryDTO category)
        {
           return _categoryService.AddCategory(category);

        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public void Put([FromBody]CategoryDTO category)
        {
            _categoryService.UpdateCategory(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}
