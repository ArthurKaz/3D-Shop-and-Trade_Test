using UnityEngine;

public class SalesHandler : ExchangeHandler
{
    [SerializeField] private Customer _customer;
    [SerializeField] private PricePercents _pricePercents;
    private void Awake()
    {
        PriceMaker = new SalesPriceMaker(_pricePercents);
    }
    public override void Exchange(Item item) => Sell(item);
    private void Sell(Item item)
    {
        _customer.Remove(item);
        var price = PriceMaker.FormPrice(item.Price);
        _customer.EarnMoney(price);
        OnExchangeSuccess(item);
    }
}