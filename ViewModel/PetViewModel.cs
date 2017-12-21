using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model.ConstructionModules.Observer;
using Model.Player;
using ViewModel.Tech;

namespace ViewModel
{
    public class PetViewModel:BaseViewModel, IListener
    {
        private ObservableCollection<AttributeViewModel> _stats = new AsyncObservableCollection<AttributeViewModel>();
        public ObservableCollection<AttributeViewModel> Stats
        {
            get => _stats;
            set
            {
                _stats = value;
                OnPropertyChanged("Stats");
            }
        }

        public PetViewModel(Player player)
        {
            this._player=player;
            var attributes = _player.CheckPet();
            foreach (var pair in attributes)
            {
                Stats.Add(new AttributeViewModel(pair.Key, pair.Value));
            }
        }
        private readonly Player _player;

        public void Update()
        {
            var attributes = _player.CheckPet();
            foreach (var pair in attributes)
            {
                var modifiedStat= Stats.First(s => s.Name == pair.Key);
                modifiedStat.Value = pair.Value;
            }
        }

        public PetViewModel()
        {
           
        }
    }
}
