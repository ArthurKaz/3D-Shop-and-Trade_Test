using System;

public class SalesPriceMaker : IPriceMaker
{
    private PricePercents _pricePercents;

    public SalesPriceMaker(PricePercents pricePercents)
    {
        _pricePercents = pricePercents;
    }

    public int FormPrice(int price)
    {
        return Convert.ToInt32(price * (1 + _pricePercents.SellBenefitsCommission));
    }
}
