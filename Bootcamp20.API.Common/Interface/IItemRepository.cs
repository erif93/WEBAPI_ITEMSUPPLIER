using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Param;

namespace Bootcamp20.API.Common.Interface
{
   public interface IItemRepository
    {
        List<Item> Get();
        Item Get(int? id);
        bool Insert(ItemParam _itemparam);
        bool Update(ItemParam _itemparam);
        bool Delete(int? id);
    }
}
