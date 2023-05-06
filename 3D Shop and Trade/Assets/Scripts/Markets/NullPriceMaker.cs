public class NullPriceMaker : IPriceMaker
{
    public int FormPrice(int price)
    {
        return price;
    }
}