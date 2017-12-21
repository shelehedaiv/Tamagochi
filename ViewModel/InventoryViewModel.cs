using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;
using Model.ConstructionModules.Observer;
using Model.Inventory;
using Model.Player;
using ViewModel.Command;


namespace ViewModel
{
    public class InventoryViewModel: BaseViewModel, IListener
    {
        private readonly Player _player;
        private ObservableCollection<GroupViewModel> _content= new ObservableCollection<GroupViewModel>();

        public ObservableCollection<GroupViewModel> Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }

        public InventoryViewModel(Player playerInventory)
        {
            _player = playerInventory;
            ChangeVisibility = new BaseCommand(Toggling);
            Update();
        }

        #region IListener methods
        public void Update()
        {
            Dispatcher.CurrentDispatcher.InvokeAsync(ChangeContent);
        }
        #endregion

        public void ChangeContent()
        {
            Content.Clear();
            foreach (var group in _player.Show().GroupBy(i => new { i.Name, i.Value }))
            {
                Content.Add(new GroupViewModel(group.Key.Name, group.Key.Value, group.Count()));
            }
        }
        #region Command
        private bool _visibility = false;
        public bool Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged("Visibility");
            }
        }
        public ICommand ChangeVisibility { get; set; }

        public void Toggling(object args)
        {
            Visibility = !Visibility;
            if (Visibility) Update();
        }

        #endregion

       
    }
}