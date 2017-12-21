using Model.Inventory;
using Model.Purchase.Money;

namespace Model.Purchase
{
    public interface ICustomer: ICollect, IPay
    {
        
    }
}