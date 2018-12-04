using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Param;
using Bootcamp20.API.Common.Interface;
=======
using Bootcamp20.API.Common.Interface;
using Bootcamp20.API.DataAccess.Models;
using Bootcamp20.API.DataAccess.Param;
>>>>>>> b82349580ae1a3d8e5897f31e6e880e54acf0e96

namespace Bootcamp20.API.BussinessLogic.Interface.Master
{
    public class ItemService : IItemService
    {
<<<<<<< HEAD
        private readonly IItemRepository _itemRepository;
        public ItemService() { }
        public ItemService(IItemRepository itemRepository)
        {
            this._itemRepository = itemRepository;
        }

        public bool Delete(int? id)
        {
            return _itemRepository.Delete(id);
=======
        private readonly IItemRepository _iitemrepository;

        public ItemService() { }

        public ItemService(IItemRepository iitemrepository)
        {
            this._iitemrepository = iitemrepository;
        }
        public bool Delete(int? id)
        {
            return _iitemrepository.Delete(id);
>>>>>>> b82349580ae1a3d8e5897f31e6e880e54acf0e96
        }

        public List<Item> Get()
        {
<<<<<<< HEAD
            return _itemRepository.Get();
=======
            return _iitemrepository.Get();
>>>>>>> b82349580ae1a3d8e5897f31e6e880e54acf0e96
        }

        public Item Get(int? id)
        {
<<<<<<< HEAD
            return _itemRepository.Get(id);
=======
            return _iitemrepository.Get(id);
>>>>>>> b82349580ae1a3d8e5897f31e6e880e54acf0e96
        }

        public List<Item> GetName(ItemParam _itemparam)
        {
<<<<<<< HEAD
            return _itemRepository.GetName(_itemparam);
=======
            return _iitemrepository.GetName(_itemparam);
>>>>>>> b82349580ae1a3d8e5897f31e6e880e54acf0e96
        }

        public bool Insert(ItemParam _itemparam)
        {
<<<<<<< HEAD
            return _itemRepository.Insert(_itemparam);
=======
            return _iitemrepository.Insert(_itemparam);
>>>>>>> b82349580ae1a3d8e5897f31e6e880e54acf0e96
        }

        public List<Item> Search(string name)
        {
<<<<<<< HEAD
            return _itemRepository.Search(name);
=======
            return _iitemrepository.Search(name);
>>>>>>> b82349580ae1a3d8e5897f31e6e880e54acf0e96
        }

        public bool Update(ItemParam _itemparam)
        {
<<<<<<< HEAD
            return _itemRepository.Update(_itemparam);
=======
            return _iitemrepository.Update(_itemparam);
>>>>>>> b82349580ae1a3d8e5897f31e6e880e54acf0e96
        }
    }
}
