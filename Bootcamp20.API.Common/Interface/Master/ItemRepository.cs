using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Param;

namespace Bootcamp20.API.Common.Interface.Master
{
    public class ItemRepository : IItemRepository
    {

        MyContext context = new MyContext();
        bool status = false;
        public bool Delete(int? id)
        {
            var getItem = Get(id);
            getItem.Delete();
            context.Entry(getItem).State = System.Data.Entity.EntityState.Modified;
            var result = context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Item> Get()
        {
            return context.Items.Include("Supplier").Where(x => x.IsDelete == false).ToList();
        }


        public List<Item> Search(string name)
        {
            return context.Items.Where(x => x.Name.Contains(name)).ToList();
        }

        public Item Get(int? id)
        {
            if (id == null)
            {
                Console.Write("id is null");
            }
            Item item = context.Items.SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                Console.Write("Item Not Found");
            }
            return item;
        }

        public bool Insert(ItemParam _itemparam)
        {
            _itemparam.Supplier = context.Suppliers.Find(_itemparam.Supplier_Id);
            Item item = new Item(_itemparam);
            context.Items.Add(item);
            var result = context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(ItemParam _itemparam)
        {
            _itemparam.Supplier = context.Suppliers.Find(_itemparam.Supplier_Id);
            Item getItem = Get(_itemparam.Id);
            getItem.Update(_itemparam);
            context.Entry(getItem).State = System.Data.Entity.EntityState.Modified;
            var result = context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
 }

