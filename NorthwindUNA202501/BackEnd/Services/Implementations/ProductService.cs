using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ProductService : IProductService
    {
        IUnidadDeTrabajo unidadDeTrabajo;

        public ProductService(IUnidadDeTrabajo unidadDeTrabajo)
        {
                this.unidadDeTrabajo = unidadDeTrabajo;
        }


        CategoryDTO Convertir(Category category)
        {
            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }
        ProductDTO Convertir (Product product)
        {
          var result = new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
                Discontinued = product.Discontinued
            };

            var categoryEntity = unidadDeTrabajo
                             .CategoryDAL
                             .FindById((int)result.CategoryId);


            result.Category = new CategoryDTO
            {
                CategoryId = categoryEntity.CategoryId,
                CategoryName = categoryEntity.CategoryName
            };
            return result;

        }

        Product Convertir(ProductDTO product)
        {
            return new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
                Discontinued = product.Discontinued
            };

        }

        public ProductDTO Add(ProductDTO productDTO)
        {
           var product = this.Convertir(productDTO);

            unidadDeTrabajo.ProductDAL.Add(product);
            unidadDeTrabajo.Complete();
            return productDTO;
        }

        public ProductDTO Delete(int ProductId)
        {
            var product = new Product { ProductId = ProductId };
            unidadDeTrabajo.ProductDAL.Remove(product);
            unidadDeTrabajo.Complete();
            return new ProductDTO { ProductId = ProductId };
        }

        public ProductDTO Get(int ProductId)
        {
            var product = unidadDeTrabajo
                            .ProductDAL
                            .FindById(ProductId);
            return Convertir(product);  
        }

        public List<ProductDTO> GetAll()
        {
            var products = unidadDeTrabajo
                            .ProductDAL
                            .Get();

            var list = new List<ProductDTO>();

            foreach (var item in products)
            {
                list.Add(Convertir(item));
            }
            return list;
        }

        public ProductDTO Update(ProductDTO productDTO)
        {
            var product = Convertir(productDTO);

            unidadDeTrabajo .ProductDAL .Update(product);   
            unidadDeTrabajo .Complete();
            
            return productDTO;
        }
    }
}
