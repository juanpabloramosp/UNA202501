using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoryHelper : ICategoryHelper
    {
        IServiceHelper _helper;

        public CategoryHelper(IServiceHelper helper)
        {
                _helper = helper;
        }

        CategoryViewModel Convertir(CategoryAPI category)
        {
            return new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        CategoryAPI Convertir(CategoryViewModel category)
        {
            return new CategoryAPI
            {
                CategoryId = category.CategoryId,

                CategoryName = category.CategoryName
            };
        }

        public CategoryViewModel Create(CategoryViewModel category)
        {
            var response = _helper.Post("api/Category", Convertir(category));

            return category;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryViewModel Get(int id)
        {
            var response = _helper.GetResponseMessage("api/category/" + id.ToString());
            var category = new CategoryViewModel();
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var result  = JsonConvert.DeserializeObject<CategoryAPI>(content);

                category = Convertir(result);

                
            }
            return category;
        }

        public List<CategoryViewModel> GetCategories()
        {
            var response = _helper.GetResponseMessage("api/category");
            var lista = new List<CategoryViewModel>();
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var categories = JsonConvert.DeserializeObject<List<CategoryAPI>>(content);
            
           

            foreach (var item in categories)
                {
                    lista.Add(Convertir(item));

                }
            }
            return lista;
        }

        public CategoryViewModel Update(CategoryViewModel category)
        {
            var response = _helper.Put("api/Category", Convertir(category));

            return category;
        }
    }
}
