namespace ViewModel
{
    public class AttributeViewModel:BaseViewModel
    {
        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public AttributeViewModel(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}