using System;

public class PurchasePriceMaker : IPriceMaker
{
    private PricePercents _pricePercents;

    public PurchasePriceMaker(PricePercents pricePercents)
    {
        _pricePercents = pricePercents;
    }

    public int FormPrice(int price)
    {
        return Convert.ToInt32(price * (1 + _pricePercents.BuyCommissionCoefficient));
    }
}