//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bootcamp20.API.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using Param;

    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Stock { get; set; }
        public int? Price { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool? IsDelete { get; set; }
        public int? Supplier_Id { get; set; }
    
        public virtual Supplier Supplier { get; set; }

        public Item() { }

        public Item(ItemParam _ItemParam)
        {
            this.Name = _ItemParam.Name;
            this.Stock = _ItemParam.Stock;
            this.Price = _ItemParam.Price;
            this.Supplier = _ItemParam.Supplier;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
            this.IsDelete = false;
        }
        public virtual void Update(ItemParam _ItemParam)
        {
            this.Id = _ItemParam.Id;
            this.Name = _ItemParam.Name;
            this.Price = _ItemParam.Price;
            this.Stock = _ItemParam.Stock;
            //this.Supplier_Id = Convert.ToInt16(_ItemParam.Supplier);
            this.Supplier = _ItemParam.Supplier;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public virtual void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
