using Model.Stuff;

namespace ViewModel
{
    public class GroupViewModel:BaseViewModel
    {
        private string _name;
        private int _value;
        private int _quantity;
        
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public GroupViewModel(string name, int value, int quantity)
        {
            Name = name;
            Value = value;
            Quantity = quantity;
        }
    }
}