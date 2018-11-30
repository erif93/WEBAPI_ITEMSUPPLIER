using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.Common.Interface;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.DataAccess.Param;

namespace Bootcamp20.API.BussinessLogic.Interface.Master
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _isupplierrepository;

        public SupplierService() { }

        public SupplierService(ISupplierRepository isupplierrepository)
        {
            this._isupplierrepository = isupplierrepository;
        }
        public bool Delete(int? id)
        {
            return _isupplierrepository.Delete(id);
        }

        public List<Supplier> Get()
        {
            return _isupplierrepository.Get();
        }

        public Supplier Get(int? id)
        {
            return _isupplierrepository.Get(id);
        }

        public List<Supplier> Search(string name)
        {
            return _isupplierrepository.Search(name);
        }

        public bool Insert(SupplierParam _supplierparam)
        {
            return _isupplierrepository.Insert(_supplierparam);
        }

        public bool Update(SupplierParam _supplierparam)
        {
            return _isupplierrepository.Update(_supplierparam);
        }
    }
}
