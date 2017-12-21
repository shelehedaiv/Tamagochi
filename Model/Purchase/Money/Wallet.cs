using System.Runtime.Serialization;

namespace Model.Purchase.Money
{
    [DataContract]
    public class Wallet:IWallet
    {
        [DataMember]
        private int _money=10000;

        public int Money => _money;
        
        public virtual bool Pay(int worth)
        {
            if (_money > worth)
            {
                _money -= worth;
                return true;
            }
            else return false;
        }

        public void Earn(int money)
        {
            _money += money;
        }
    }
}