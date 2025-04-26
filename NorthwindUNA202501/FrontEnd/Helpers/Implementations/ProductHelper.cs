using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ProductHelper : IProductHelper
    {

        IServiceHelper _helper;

        public ProductHelper(IServiceHelper helper)
        {
            _helper = helper;
        }

        ProductViewModel Convertir(ProductAPI product)
        {
            return new ProductViewModel
            {
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Discontinued = product.Discontinued,
                CategoryName = product.Category.CategoryName
            };
        }

        ProductAPI Convertir(ProductViewModel product)
        {
            return new ProductAPI
            {
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Discontinued = product.Discontinued
            };
        }

        public void Add(ProductViewModel product)
        {
            var response = _helper.Post("api/Product", Convertir(product));
        }

        public void Delete(int id)
        {
            _helper.Delete("api/product/" +  id);
        }

        public ProductViewModel Get(int id)
        {
            var response = _helper.GetResponseMessage("api/product/" + id.ToString());
            var product = new ProductViewModel();
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<ProductAPI>(content);

                product = Convertir(result);


            }
            return product;
        }

        public List<ProductViewModel> GetProducts()
        {
            var response = _helper.GetResponseMessage("api/product");
            var lista = new List<ProductViewModel>();
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var results = JsonConvert.DeserializeObject<List<ProductAPI>>(content);



                foreach (var item in results)
                {
                    lista.Add(Convertir(item));

                }
            }
            return lista;
        }

        public void Update(ProductViewModel product)
        {
            var response = _helper.Put("api/Product", Convertir(product));
        }
    }
}
