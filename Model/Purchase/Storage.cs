using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Inventory.Stuff;
using Model.PetModule.Attribute;
using Model.Stuff;
namespace Model.Purchase
{
    class Storage
    {
        public static readonly Dictionary<int, List<Item>> OpenItems
            = new Dictionary<int, List<Item>>()
        {
                {1,
                    new List<Item>(){
                        new Item("Bread", 2,2, NeedType.Bellyful),
                        new Item("Dove",3,5, NeedType.Cleanliness),//rename!
                        new Item("Apple",5,20, NeedType.Bellyful)
                    }
                }
        };
    }
}
