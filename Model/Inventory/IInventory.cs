using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Model.Inventory.Stuff;

namespace Model.Inventory
{
   
    public interface IInventory:ICollect, IGive, IShowContent
    {
        #region Methods
        
        #endregion
    }
}
