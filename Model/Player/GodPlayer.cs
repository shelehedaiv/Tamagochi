using Model.Inventory;
using Model.PetModule;
using Model.Purchase.Money;

namespace Model.Player
{
    public class GodPlayer:Player
    {
        public GodPlayer(IInventory inv, IPet pet) : base(inv, pet, new Wallet())
        {
            
        }
    }
}