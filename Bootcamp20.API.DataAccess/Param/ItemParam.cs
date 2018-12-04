using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.DataAccess.Models;

namespace Bootcamp20.API.DataAccess.Param
{
    public class ItemParam
    {
        public int Id { get; set; }
        public int Supplier_Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int typesearchitem { get; set; }
        public string Supplier_Name { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsDelete { get; set; }

        public ItemParam() { }

        public ItemParam(Item item)
        {
            this.Id = item.Id;
            this.Name = item.Name;
            //this.Stock = Convert.ToInt16(item.Stock);
            //this.Price = Convert.ToInt16(item.Price);
            this.Supplier_Id = item.Supplier.Id;
            this.CreateDate = Convert.ToDateTime(item.CreateDate);
            this.UpdateDate = Convert.ToDateTime(item.UpdateDate);
            //this.DeleteDate = Convert.ToDateTime(item.DeleteDate);
            this.IsDelete = Convert.ToBoolean(item.IsDelete);

        }
    }

}
