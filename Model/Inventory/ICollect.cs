using System.Collections.Generic;
using Model.Inventory.Stuff;
using Model.Stuff;

namespace Model.Inventory
{
    public interface ICollect
    {
        #region Methods
        void Put(Item item);
        void Put(List<Item> box);
        #endregion
    }
}