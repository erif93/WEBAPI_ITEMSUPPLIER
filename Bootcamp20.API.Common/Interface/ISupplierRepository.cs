using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.DataAccess.Param;

namespace Bootcamp20.API.Common.Interface
{
   public interface ISupplierRepository
    {
        List<Supplier> Get();
        Supplier Get(int? id);
        List<Supplier> Search(string name);
        List<Supplier> GetSearch(SupplierParam _supplierparam);
        bool Insert(SupplierParam _supplierparam);
        bool Update(SupplierParam _supplierparam);
        bool Delete(int? id);
    }
}
