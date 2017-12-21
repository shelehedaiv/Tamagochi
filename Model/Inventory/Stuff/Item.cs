using System.Runtime.Serialization;
using Model.PetModule.Attribute;
using Model.Stuff;

namespace Model.Inventory.Stuff
{
    [DataContract]
    [KnownType(typeof(Food))]
    [KnownType(typeof(Soap))]
    [KnownType(typeof(Toy))]
    public class Item
    {
        #region Constructor !!! default parametr
        public Item(string name, int price, int value, NeedType usage=NeedType.Bellyful)
        {
            _name = name;
            _price = price;
            _value = value;
            _usage = usage;
        }
        #endregion
        [DataMember] private readonly int _value;
        public int Value { get=>_value; }
        
        [DataMember] private readonly int _price;
        public int Price { get=>_price; }
       
        [DataMember] private readonly string _name;
        public string Name { get=>_name;}

        [DataMember] private readonly NeedType _usage;
        public NeedType Usage;

        public Item Clone()
        {
            return new Item(Name, Price,Value,_usage);
        }
    }
}