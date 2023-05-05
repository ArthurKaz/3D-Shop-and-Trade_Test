using UnityEngine;

public class PurchaseHandler : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void Purchase(Item item)
    {
        var price = item.Price;
        if (_player.HasMoney(price))
        {
            _player.SpendMoney(price);
            _player.AddItem(item);
        }
    }
}