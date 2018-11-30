using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.DataAccess.Param;

namespace Bootcamp20.API.Common.Interface.Master
{
    public class SupplierRepository : ISupplierRepository
    {
        MyContext context = new MyContext();
        bool status = false;
        public bool Delete(int? id)
        {
            var getSupplier = Get(id);
            getSupplier.Delete();
            context.Entry(getSupplier).State = System.Data.Entity.EntityState.Modified;
            var result = context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }


        public List<Supplier> Get()
        {
            return context.Suppliers.Where(x => x.IsDelete == false).ToList();
        }

        public List<Supplier> Search(string name)
        {
            return context.Suppliers.Where(x => x.Name.Contains(name)).ToList();
        }


        public Supplier Get(int? id)
        {
            if (id == null)
            {
                Console.Write("id is null");
            }
            Supplier supplier = context.Suppliers.SingleOrDefault(x => x.Id == id);
            if (supplier == null)
            {
                Console.Write("Supplier has not value");
            }
            return supplier;
        }

        public bool Insert(SupplierParam _supplierparam)
        {
            var push = new Supplier(_supplierparam);
            context.Suppliers.Add(push);
            var result = context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(SupplierParam _supplierparam)
        {
            var getSupplier = Get(_supplierparam.Id);
            getSupplier.Update(_supplierparam);
            context.Entry(getSupplier).State = System.Data.Entity.EntityState.Modified;
            var result = context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
