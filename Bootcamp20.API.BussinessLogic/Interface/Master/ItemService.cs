using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Param;
using Bootcamp20.API.Common.Interface;

namespace Bootcamp20.API.BussinessLogic.Interface.Master
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService() { }
        public ItemService(IItemRepository itemRepository)
        {
            this._itemRepository = itemRepository;
        }

        public bool Delete(int? id)
        {
            return _itemRepository.Delete(id);
        }
        public List<Item> Get()
        {
            return _itemRepository.Get();
        }

        public Item Get(int? id)
        {
            return _itemRepository.Get(id);
        }

        public List<Item> GetName(ItemParam _itemparam)
        {
            return _itemRepository.GetName(_itemparam);
        }
        public List<Item> Search(string name)
        {
            return _itemRepository.Search(name);
        }
        public bool Insert(ItemParam _itemparam)
        {
            return _itemRepository.Insert(_itemparam);
        }
        public bool Update(ItemParam _itemparam)
        {
            return _itemRepository.Update(_itemparam);
        }
    }
}
