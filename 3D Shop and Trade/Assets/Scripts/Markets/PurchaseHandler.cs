using System;
using UnityEngine;

public class PurchaseHandler : ExchangeHandler
{
    [SerializeField] private Customer _customer;
    [SerializeField] private PricePercents _pricePercents;
    public event Action Failed;

    private void Awake()
    {
        PriceMaker = new PurchasePriceMaker(_pricePercents);
    }
    public override void Exchange(Item item) => Purchase(item);

    private void Purchase(Item item)
    {
        var price = PriceMaker.FormPrice(item.Price);
        if (_customer.HasMoney(price))
        {
            _customer.SpendMoney(price);
            _customer.Add(item);
            OnExchangeSuccess(item);
        }
        else
        {
            OnFailed();
        }
    }
    
    private void OnFailed()
    {
        Failed?.Invoke();
    }
}