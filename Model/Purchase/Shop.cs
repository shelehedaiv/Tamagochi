using System;
using System.Collections.Generic;
using Model.Inventory;
using Model.Inventory.Stuff;
using Model.PetModule.Attribute;
using Model.Stuff;

namespace Model.Purchase
{
    class Shop
    {
        private InfiniteInventory _openStorage=new InfiniteInventory();
        public InfiniteInventory OpenStorage => _openStorage;
        private readonly List<List<Item>> _storage
            = new List<List<Item>>()
            {
                
                    new List<Item>(){
                        new Item("Bread", 2,2, NeedType.Bellyful),
                        new Item("Dove",3,5, NeedType.Cleanliness),//rename!
                        new Item("Apple",5,20, NeedType.Bellyful)
                    }   
            };
        public Shop()
        {
            _openStorage.Put(_storage[0]);
        }

        public bool Buy(ICustomer player, string itemName)
        {
            var item = _openStorage.Take(itemName);
            if (item == null) return false;
            if (player.Pay(item.Price))
            {
                player.Put(item);
                return true;
            }
            else return false;
        }
    }
}
