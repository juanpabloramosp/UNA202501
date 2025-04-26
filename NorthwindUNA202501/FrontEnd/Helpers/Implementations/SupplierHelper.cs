using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class SupplierHelper : ISupplierHelper
    {
        IServiceHelper _helper;

        public SupplierHelper(IServiceHelper helper)
        {
            _helper = helper;
        }

        SupplierViewModel Convertir(SupplierAPI supplier)
        {
            return new SupplierViewModel {
                SupplierId =     supplier.SupplierId,
                CompanyName = supplier.CompanyName
            };
        }

        public List<SupplierViewModel> Get()
        {
            var response = _helper.GetResponseMessage("api/supplier");
            var lista = new List<SupplierViewModel>();
            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var suppliers = JsonConvert.DeserializeObject<List<SupplierAPI>>(content);



                foreach (var item in suppliers)
                {
                    lista.Add(Convertir(item));

                }
            }
            return lista;
        }
    }
}
