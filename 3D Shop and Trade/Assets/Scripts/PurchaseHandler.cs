using UnityEngine;

public class PurchaseHandler : ExchangeHandler
{
    [SerializeField] private Player _player;
    
    public override void Exchange(Item item) => Purchase(item);

    private void Purchase(Item item)
    {
        var price = item.Price;
        if (_player.HasMoney(price))
        {
            _player.SpendMoney(price);
            _player.AddItem(item);
        }
    }

    
}