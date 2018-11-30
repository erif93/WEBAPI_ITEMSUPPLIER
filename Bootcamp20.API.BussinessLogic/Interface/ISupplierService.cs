using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.DataAccess.Param;

namespace Bootcamp20.API.BussinessLogic.Interface
{
   public interface ISupplierService
    {
        List<Supplier> Get();
        Supplier Get(int? id);
        List<Supplier> Search(string name);
        bool Insert(SupplierParam _supplierparam);
        bool Update(SupplierParam _supplierparam);
        bool Delete(int? id);

    }
}
