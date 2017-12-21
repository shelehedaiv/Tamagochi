using Model.Inventory;
using Model.PetModule;
using Model.Player;
using Model.Purchase;

namespace Model.ModelStarters
{
    public class AdminModelStarter:BaseModelStarter //abstract factory variant 2
    {
        private AdminModelStarter()
        {
            CreateNewPlayer();
        }
        
        public static BaseModelStarter GetModel()
        {
            if (Model is null)
            {
                Model = new AdminModelStarter();
            }
            return Model;
        }

        private IInventory CreateInventory()
        {
            return new InfiniteInventory();
        }
        private IPet CreatePet()
        {
            return new Pet();
        }

        protected override void CreateNewPlayer()
        {
            MyPlayer = new GodPlayer(CreateInventory(), CreatePet());
            Shop shop=new Shop();
            MyPlayer.Put(shop.OpenStorage.Show());
        }
    }
}