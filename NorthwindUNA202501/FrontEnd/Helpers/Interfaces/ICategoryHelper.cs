using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICategoryHelper
    {
        CategoryViewModel Get(int id);
        List<CategoryViewModel> GetCategories();

        CategoryViewModel Create(CategoryViewModel category);
        CategoryViewModel Update(CategoryViewModel category);
       

        void Delete(int id);

    }
}
