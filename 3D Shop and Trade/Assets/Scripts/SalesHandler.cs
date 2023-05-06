using UnityEngine;

public class SalesHandler : ExchangeHandler
{
    [SerializeField] private Player _player;

    public override void Exchange(Item item) => Sell(item);
    private void Sell(Item item)
    {
        _player.Remove(item);
        _player.EarnMoney(item.Price);
    }
}