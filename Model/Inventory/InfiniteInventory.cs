using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Model.Inventory.Stuff;
using Model.Stuff;

namespace Model.Inventory
{
    [DataContract]
    public class InfiniteInventory:Inventory
    {

        #region Methods
        public override void Put(Item item)
        {
            if (!Content.Any(i => i.Name == item.Name && i.GetType()==item.GetType()))
            {
                Content.Add(item);
            }
        }
        public override void Put(List<Item> box)
        {
            foreach (var item in box)
            {
                if (!Content.Any(i => i.Name == item.Name && i.GetType() == item.GetType()))
                {
                    Content.Add(item);
                }
            }
        }
        public override Item Take(string name)
        {
            if (Content.Any(i => i.Name == name))
            {
                return  Content.First(i => i.Name == name).Clone();
            }
            else return null;
        }
        public override int Count(string name)
        {
            if (Content.Any(i => i.Name == name))
                return 100000;
            else return 0;
        }
        #endregion
    }
}