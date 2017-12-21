using System.Runtime.Serialization;

namespace Model.PetModule.Attribute
{
   [DataContract]
    internal class Need
    {
        //[DataMember] protected int MinValue = 0;
        [DataMember] protected int MaxValue = 100;
        [DataMember] private int _currentValue=60;
        [DataMember] private NeedType _name;
        public NeedType Name => _name;
        public Need(NeedType name)
        {
            _name = name;
        }
        public int CurrentValue => _currentValue * 100 / MaxValue;
        public bool Fill(int itemValue)
        {
            if (_currentValue == MaxValue) return false;
            else
            {
                _currentValue=_currentValue + itemValue > MaxValue ? MaxValue : _currentValue + itemValue;
                return true;
            }
        }
        public void TimePass()
        {
           _currentValue -= 1;
        }
    }


   
}