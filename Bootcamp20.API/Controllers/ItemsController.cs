﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bootcamp20.API.BussinessLogic.Interface;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Param;

namespace Bootcamp20.API.Controllers
{
    public class ItemsController : ApiController
    {
        private readonly IItemService _iitemservice;

        public ItemsController() { }

        public ItemsController(IItemService iitemservice)
        {
            this._iitemservice = iitemservice;
        }
        // GET: api/Items
        public IEnumerable<Item> Get()
        {
            return _iitemservice.Get(); 
        }

        // GET: api/Items/5
        public Item Get(int id)
        {
            return _iitemservice.Get(id);
        }

        // POST: api/Items
        public void Post(ItemParam itemparam)
        {
            _iitemservice.Insert(itemparam);
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