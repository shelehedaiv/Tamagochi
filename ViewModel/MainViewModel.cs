using System;
using System.Linq;
using System.Windows.Input;
using Model.Player;
using ViewModel.Command;

namespace ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        private Player _player;
        public MainViewModel(Player player)
        {
            _player = player;
            Inventory=new InventoryViewModel(player);
            Pet=new PetViewModel(player);
            UseItemCommand=new BaseCommand(Use);
            Save=new BaseCommand(SaveGame);
            Load=new BaseCommand(LoadGame);
        }
        
        private InventoryViewModel _inventory;
        private PetViewModel _pet;

        public InventoryViewModel Inventory
        {
            get => _inventory;
            set
            {
                _inventory = value;
                OnPropertyChanged("Inventory");
            }
        }
        public PetViewModel Pet
        {
            get => _pet;
            set
            {
                _pet = value;
                OnPropertyChanged("Pet");
            }
        }
        #region Command
        public ICommand UseItemCommand { get; set; }

        public void Use(object itemName)
        {
            if (Inventory.Content.Count > 0)
            {
                _player.ProposeItem(Inventory.Content.Select(i => i.Name).First());
            }
        }
        public ICommand Save { get; set; }
        public ICommand Load { get; set; }

        public void SaveGame(object slotNumber)
        {
            _player.SaveGame(Convert.ToInt32(slotNumber));
        }

        public void LoadGame(object slotNumber)
        {
            _player.LoadGame(Convert.ToInt32(slotNumber));
            Inventory.Update();
            Pet.Update();
        }
        #endregion


    }
}
