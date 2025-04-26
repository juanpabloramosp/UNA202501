using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IProductService
    {
        ProductDTO Add(ProductDTO productDTO);  
        ProductDTO Update(ProductDTO productDTO);
        ProductDTO Delete(int ProductId);
        ProductDTO Get(int ProductId);
        List<ProductDTO> GetAll();    

    }
}
