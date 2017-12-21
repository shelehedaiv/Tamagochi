using System.Collections.Generic;
using System.Runtime.Serialization;
using Model.Inventory.Stuff;

namespace Model.Inventory
{
    
    public interface IShowContent
    {
        List<Item> Show(string name);
        List<Item> Show();
        int Count(string name);
    }
}