using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class SupplierDALImpl : GenericDALImpl<Supplier>, ISupplierDAL
    {
        NorthWindContext NorthWindContext { get; set; }
        public SupplierDALImpl(NorthWindContext northWind)
            : base(northWind) 
        {
                this.NorthWindContext = northWind;
        }
    }
}
