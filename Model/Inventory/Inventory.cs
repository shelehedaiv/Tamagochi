using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Model.Inventory.Stuff;
using Model.Stuff;

namespace Model.Inventory
{
    [DataContract]
    [KnownType(typeof(SimpleInventory))]
    [KnownType(typeof(Inventory))]
    public abstract class Inventory:IInventory //cope with serialization
    {
        [DataMember]
        protected List<Item> Content = new List<Item>();

        #region Abstract Methods

        public abstract void Put(Item item);

        public abstract void Put(List<Item> box);

        public abstract Item Take(string name);

        public abstract int Count(string name);
        #endregion
        #region Working Methods
        public List<Item> Show(string name)
        {
            if (Content.Any(i => i.Name == name))
            {
                return Content.Where(i => i.Name == name).OrderBy(i => i.Name).ToList();
            }
            else return new List<Item>();
        }
        public List<Item> Show()
        {
           return Content;
        } 
        #endregion
    }
}
