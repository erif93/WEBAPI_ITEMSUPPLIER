using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.DataAccess.Models;

namespace Bootcamp20.DataAccess.Param
{
   public class SupplierParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsDelete { get; set; }
        public int typesearch { get; set; } 
        public SupplierParam() { }
    }

}

