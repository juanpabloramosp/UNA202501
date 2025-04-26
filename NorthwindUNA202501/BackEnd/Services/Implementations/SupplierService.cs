using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        IUnidadDeTrabajo _unidad;

        public SupplierService(IUnidadDeTrabajo unidad)
        {
                this._unidad = unidad;
        }

        SupplierDTO Convertir(Supplier supplier)
        {
            return new SupplierDTO
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName
            };
        }


        public SupplierDTO Get(int id)
        {
            var supplier = _unidad.SupplierDAL.FindById(id);

            return  Convertir(supplier);
        }

        public List<SupplierDTO> GetAll()
        {
            var list = new List<SupplierDTO>();

            var result = _unidad.SupplierDAL.Get();

            foreach (var item in result) { 
            list.Add(Convertir(item));
            }

            return list;
        }
    }
}
