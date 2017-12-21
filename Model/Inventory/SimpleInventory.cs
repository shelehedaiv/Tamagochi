using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Model.Inventory.Stuff;

namespace Model.Inventory
{
    [DataContract]
    public class SimpleInventory:Inventory, IInventory
    {
       #region Methods
        public override void Put(Item item)
        {
            Content.Add(item);
        }
        public override void Put(List<Item> box)
        {
            Content.AddRange(box);

        }
        public override Item Take(string name)
        {
            if (Content.Any(i => i.Name == name))
            {
                Item removeItem = Content.First(i => i.Name == name);
                Content.Remove(removeItem);
                return removeItem;
            }
            else return null;
        }
        public override int Count(string name)
        {
            return Content.Count(i => i.Name == name);
        }
        #endregion
    }
}
