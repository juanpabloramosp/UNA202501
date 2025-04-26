using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo: IDisposable
    {
        ICategoryDAL CategoryDAL { get; }
        IShipperDAL ShipperDAL { get; }

        IProductDAL ProductDAL { get; }

        ISupplierDAL SupplierDAL { get; }

        void Complete();

    }
}
