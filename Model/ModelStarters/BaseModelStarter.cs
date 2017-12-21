using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Model.ConstructionModules;
using Model.Inventory;
using Model.Inventory.Stuff;
using Model.PetModule;
using Model.Purchase.Money;
using Model.Stuff;
using Ninject;

[assembly: InternalsVisibleTo("Model.Test")]
namespace Model.ModelStarters
{
    public abstract class BaseModelStarter //abstract factory
    {
        public Player.Player MyPlayer;
        protected static BaseModelStarter Model;
        
        protected virtual void CreateNewPlayer()
        {
            var kernel = new StandardKernel();
            var dependencyInjection = Ninjector.GetNinjector();
            kernel.Load(dependencyInjection);
            MyPlayer = kernel.Get<Player.Player>();
            MyPlayer.Put(new List<Item>()
            {
                new Food("Banana", 12, 22),
                new Food("Apple", 10, 13),
                new Food("Bread", 5, 7),
                new Soap("Dove", 4,4),

                new Food("Banana", 12, 22),
                new Food("Apple", 10, 13),
                new Food("Bread", 5, 7),
                new Soap("Dove", 4,4),

                new Food("Banana", 12, 22),
                new Food("Apple", 10, 13),
                new Food("Bread", 5, 7),
                new Soap("Dove", 4,4),
            });
            MyPlayer.FeedPet("Apple");
            MyPlayer.FeedPet("Banana");
        }
        public static void Main(string[] args)
        {
            Player.Player player=new Player.Player(new SimpleInventory(), new Pet(), new Wallet());
            List<Item> supply = new List<Item>()
            {
                new Food("Banana", 12, 22),
                new Food("Apple", 10, 13),
                new Food("Bread", 5, 7),
                new Soap("Dove", 4,4),

                new Food("Banana", 12, 22),
                new Food("Apple", 10, 13),
                new Food("Bread", 5, 7),
                new Soap("Dove", 4,4),

                new Food("Banana", 12, 22),
                new Food("Apple", 10, 13),
                new Food("Bread", 5, 7),
                new Soap("Dove", 4,4),
            };
            player.Put(supply);
        }
    }
}
