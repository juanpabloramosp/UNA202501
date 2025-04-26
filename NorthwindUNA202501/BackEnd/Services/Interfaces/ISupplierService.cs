using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface ISupplierService
    {
        SupplierDTO Get(int id);
        List<SupplierDTO> GetAll();




    }
}
