using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bootcamp20.API.BussinessLogic.Interface;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Param;

namespace Bootcamp20.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemsController : ApiController
    {
        private readonly IItemService _iitemservice;

        public ItemsController() { }

        public ItemsController(IItemService iitemservice)
        {
            this._iitemservice = iitemservice;
        }
        // GET: api/Items
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _iitemservice.Get();
        }

        [HttpGet]
        // GET: api/Items/5
        public Item Get(int id)
        {
            return _iitemservice.Get(id);
        }

        [HttpGet]
        public IEnumerable<Item> Search(string name)
        {
            return _iitemservice.Search(name);
        }

        // POST: api/Items
        public void Post(ItemParam itemparam)
        {
            _iitemservice.Insert(itemparam);
        }



        [HttpGet]
        public IEnumerable<ItemParam> GetName(int typesearchitem, string name)
        {
            ItemParam cari = new ItemParam();
            cari.typesearchitem = typesearchitem;
            cari.Name = name;

            IEnumerable<ItemParam> listparam = _iitemservice.GetName(cari).Select(x => new ItemParam
            {
                Id = x.Id,
                Name = x.Name.ToString(),
                Price=Convert.ToInt32(x.Price),
                Stock = Convert.ToInt32(x.Stock),
                Supplier_Name=x.Supplier.Name,
                CreateDate = Convert.ToDateTime(x.CreateDate)
            });
            return listparam;
        }

        // PUT: api/Items/5
        public void Put(int id,ItemParam itemparam)
        {
            _iitemservice.Update(itemparam);
        }

        // DELETE: api/Items/5
        public void Delete(int id)
        {
            _iitemservice.Delete(id);
        }
    }
}
