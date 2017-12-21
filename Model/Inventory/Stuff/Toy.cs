using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Model.Inventory.Stuff;

namespace Model.Stuff
{
    [DataContract]
    class Toy:Item
    {
        #region Constructor
        public Toy(string name, int price, int value)
            : base(name, price, value)
        {
        }
        #endregion

    }
}
