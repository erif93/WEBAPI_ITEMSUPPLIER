using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Param;

namespace Bootcamp20.API.BussinessLogic.Interface
{
   public interface IItemService
    {
        List<Item> Get();
        Item Get(int? id);
        List<Item> Search(string name);
        bool Insert(ItemParam _itemparam);
        bool Update(ItemParam _itemparam);
        bool Delete(int? id);
    }
}
