using Model.Inventory;
using Model.PetModule;
using Model.Player;
using Model.Purchase.Money;
using Ninject.Modules;

namespace Model.ConstructionModules
{
    class Ninjector : NinjectModule
    {
        private static bool Exist = false;
        private static Ninjector _ninjector;

        private Ninjector()
        {
        }

        public static Ninjector GetNinjector()
        {
            if (!Exist)
            {
                Exist = true;
                _ninjector=new Ninjector();
            }
            return _ninjector;
        }
        public override void Load()
        {
            Bind<IPet>().To<Pet>();
            Bind<IInventory>().To<SimpleInventory>();
            Bind<IWallet>().To<Wallet>();
            Bind<IInventory>().To<InfiniteInventory>().WhenInjectedInto<GodPlayer>();
        }
    }
}
