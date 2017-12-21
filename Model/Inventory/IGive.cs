using System;
using Model.Inventory.Stuff;
using Model.Stuff;

namespace Model.Inventory
{
    public interface IGive
    {
        Item Take(string name);
    }
}