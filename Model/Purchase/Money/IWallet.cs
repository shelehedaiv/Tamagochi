namespace Model.Purchase.Money
{
    public interface IWallet:IPay
    {
        void Earn(int money);
    }
}