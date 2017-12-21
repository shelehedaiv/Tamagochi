using System.Collections.Generic;
using Model.ConstructionModules.Observer;
using Model.ConstructionModules.Saving;
using Model.Inventory;
using Model.Inventory.Stuff;
using Model.PetModule;
using Model.PetModule.Attribute;
using Model.Purchase;
using Model.Purchase.Money;

namespace Model.Player
{
    public class Player:ISubject, ICustomer, IListener
    {
        private  IInventory _playerInventory;
        private  IWallet _playerWallet;
        private  IPet _tamagochi;

        public Player(IInventory playerInventory, IPet pet, IWallet wallet)
        {
            _playerInventory = playerInventory;
            _playerWallet = wallet;
            _tamagochi = pet;
            _tamagochi.AttachListener(this);

        }

        public List<Item> Show(string name)=>_playerInventory.Show(name);
        public List<Item> Show() => _playerInventory.Show();

        public bool FeedPet(string foodName)
        {
            var proposedFood= _playerInventory.Take(foodName);
            if (_tamagochi.Eat(proposedFood.Value))
            {
                Notify();
                return true;
            }
            else
            {
                _playerInventory.Put(proposedFood);
                return false;
            }
        }
        public Dictionary<string, int> CheckPet()
        {
            return _tamagochi.GetState();
        }

        public bool ProposeItem(string itemName)
        {
            var item = _playerInventory.Take(itemName);
            if (item is null) return false;
            else if (_tamagochi.Use(item))
            {
                Notify();
                return true;
            }
            else
            {
                _playerInventory.Put(item);
                return false;
            }
        }
        
        #region Observer pattern ISubject realization
        private List<IListener> _listeners = new List<IListener>();//must be vm for pet and inventory
        public void AttachListener(IListener listener)
        {
            _listeners.Add(listener);
        }
        public void Notify()
        {
            foreach (var listener in _listeners)
            {
                listener.Update();
            }
        }

        public void Update()
        {
            Notify();
        }
        #endregion

        #region ICustomer

        public void Put(Item item) => _playerInventory.Put(item);

        public void Put(List<Item> box)=>_playerInventory.Put(box);

        public bool Pay(int worth) => _playerWallet.Pay(worth);

        #endregion

        public void SaveGame(int slotNumber)
        {
            if (slotNumber > 0 && slotNumber < 2)
            {
                var save = new Memento(_playerInventory, _playerWallet, _tamagochi);
                save.SaveState($"..\\..\\..\\Model\\ConstructionModules\\Saving\\SaveSlots\\{slotNumber}.txt");
            }
        }

        public void LoadGame(int slotNumber)
        {
            if (slotNumber > 0 && slotNumber < 2)
            {
                var save=new Memento($"..\\..\\..\\Model\\ConstructionModules\\Saving\\SaveSlots\\{slotNumber}.txt");
                _playerInventory = save.InventoryState;
                _playerWallet = save.WalletState;
                _tamagochi = save.PetState;
                _tamagochi.AttachListener(this);
                _tamagochi.RestartTimer();
            }
            
        }
    }
}
