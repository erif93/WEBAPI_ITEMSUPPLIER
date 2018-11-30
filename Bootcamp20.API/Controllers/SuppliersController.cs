using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Bootcamp20.API.BussinessLogic.Interface;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.DataAccess.Param;

namespace Bootcamp20.API.Controllers
{
    [EnableCors(origins:"*", headers:"*",methods:"*")]
    public class SuppliersController : ApiController
    {
       
        private readonly ISupplierService _isupplierservice;

        public SuppliersController() { }

        public SuppliersController(ISupplierService isupplierservice)
        {
            this._isupplierservice = isupplierservice;
        }
        // GET: api/Suppliers
        public IEnumerable<Supplier> Get()
        {
            return _isupplierservice.Get();
            //var a = context.Suppliers.Where(x => x.IsDelete == false).ToList();
            //return a;
        }

        public IEnumerable<Supplier> Search(string name)
        {
            return _isupplierservice.Search(name);
        }

        // GET: api/Suppliers/5
        [HttpGet]
        public Supplier Get(int id)
        {
            return _isupplierservice.Get(id);
            //return context.Suppliers.SingleOrDefault(x => x.Id == id);
        }


        // POST: api/Suppliers
        [HttpPost]
        public void Post(SupplierParam supplierparam)
        {
            _isupplierservice.Insert(supplierparam);
            //context.Suppliers.Add(supplier);
            //context.SaveChanges();
        }

        // PUT: api/Suppliers/5
        [HttpPut]
        public void Put(int id, SupplierParam supplierparam)
        {

            _isupplierservice.Update(supplierparam);
            //var getsupp = context.Suppliers.Find(id);
            //getsupp.Name = supplier.Name;
            //context.Entry(getsupp).State = System.Data.Entity.EntityState.Modified;
            //context.SaveChanges();
        }

        // DELETE: api/Suppliers/5
        [HttpDelete]
        public void Delete(int id)
        {
            _isupplierservice.Delete(id);
            //var getsupp = context.Suppliers.Find(id);
            //getsupp.IsDelete = true;
            //context.Entry(getsupp).State = System.Data.Entity.EntityState.Modified;
            //context.SaveChanges();
        }
    }
}
