using Model.Inventory;
using Model.PetModule;
using Model.Purchase;
using Model.Purchase.Money;

namespace Model.ModelStarters
{
    public class RealModelStarter: BaseModelStarter //abstract factory variant 1
    {
        private RealModelStarter()
        {
            CreateNewPlayer();
        }
        public static BaseModelStarter GetModel()
        {
            if (Model is null)
            {
                Model = new RealModelStarter();
            }
            return Model;
        }

        private IInventory CreateInventory()
        {
            return new SimpleInventory();
        }
        private IPet CreatePet()
        {
            return new Pet();
        }
        protected override void CreateNewPlayer()
        {
            MyPlayer = new Player.Player(CreateInventory(), CreatePet(), new Wallet());
            Shop shop = new Shop();
            MyPlayer.Put(shop.OpenStorage.Show());
        }
    }
}