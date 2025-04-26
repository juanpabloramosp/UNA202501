using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BackEnd.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        ILogger<CategoryService> _logger;

        IUnidadDeTrabajo _unidadDeTrabajo;
        public CategoryService(IUnidadDeTrabajo unidad,
                        ILogger<CategoryService> logger)
        {
            _unidadDeTrabajo = unidad;
            _logger = logger;
        }

        CategoryDTO Convertir(Category category)
        {
            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        } 
        
        Category Convertir(CategoryDTO category)
        {
            return new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public CategoryDTO AddCategory(CategoryDTO category)
        {
            try
            {
                _logger.LogError("Ingresa a AddCategory");
                _unidadDeTrabajo.CategoryDAL.Add(Convertir(category));
                _unidadDeTrabajo.Complete();
                return category;

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw;
            }

            
           
        }

        public CategoryDTO DeleteCategory(int id)
        {
            var Category = new Category { CategoryId = id };
            _unidadDeTrabajo.CategoryDAL.Remove(Category);
            _unidadDeTrabajo.Complete();
            return Convertir(Category);
        }

        public List<CategoryDTO> GetCategories()
        {
            var categories = _unidadDeTrabajo.CategoryDAL.GetCategories(); 
            List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                categoryDTOs.Add(this.Convertir(category)); 
            }
            return categoryDTOs;
        }

        public CategoryDTO GetCategoryById(int id)
        {
            var result = _unidadDeTrabajo.CategoryDAL.FindById(id);
            return Convertir(result);
        }

        public CategoryDTO UpdateCategory(CategoryDTO category)
        {
            var entity = Convertir(category);
            _unidadDeTrabajo.CategoryDAL.Update(entity);
            _unidadDeTrabajo.Complete();

          

            return category;
        }
    }
}
