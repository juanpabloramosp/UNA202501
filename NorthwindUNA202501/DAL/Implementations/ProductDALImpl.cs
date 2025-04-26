using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class ProductDALImpl: GenericDALImpl<Product>, IProductDAL
    {
        NorthWindContext NorthWindContext { get; set; }

        public ProductDALImpl(NorthWindContext northWindContext)
            : base(northWindContext)
        {
                this.NorthWindContext = northWindContext;
        }

    }
}
