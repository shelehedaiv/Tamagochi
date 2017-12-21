using System.Collections.Generic;
using Model.ConstructionModules.Observer;
using Model.Inventory.Stuff;

namespace Model.PetModule
{
    public interface IPet: ISubject
    {
        bool Eat(int value);//must be removed after refactoring
        bool Use(Item item);
        Dictionary<string, int> GetState();
        void RestartTimer();
    }
}
