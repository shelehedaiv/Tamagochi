using System;

namespace Model.Purchase.Money
{
    public class InfiniteWallet:Wallet
    {
        public override bool Pay(int money)
        {
            return true;
        }
    }
}