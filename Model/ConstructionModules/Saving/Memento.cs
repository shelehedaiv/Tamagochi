using System.Runtime.Serialization;
using Model.Inventory;
using Model.PetModule;
using Model.Purchase.Money;

namespace Model.ConstructionModules.Saving
{
    [DataContract]
    [KnownType(typeof(SimpleInventory))]
    [KnownType(typeof(InfiniteInventory))]
    [KnownType(typeof(Pet))]
   
    [KnownType(typeof(Wallet))]
    [KnownType(typeof(InfiniteWallet))]
    public class Memento
    {
        [DataMember]
        public IInventory InventoryState;
        [DataMember]
        public IWallet WalletState;
        [DataMember]
        public IPet PetState;
       
       public Memento(IInventory inventory, IWallet wallet, IPet pet)
        {
            InventoryState = inventory;
            WalletState = wallet;
            PetState = pet;
        }

        public Memento(string filepath)
        {
            var savedState = DataSerializer.DeserializeState(filepath);
            InventoryState = savedState.InventoryState;
            WalletState = savedState.WalletState;
            PetState = savedState.PetState;
        }
        //----------------------

        public void SaveState(string filepath)
        {
            DataSerializer.SerializeData(filepath,this);
        }

        public Player.Player LoadState()
        {
            return new Player.Player(InventoryState, PetState,WalletState);
        }
    }
}