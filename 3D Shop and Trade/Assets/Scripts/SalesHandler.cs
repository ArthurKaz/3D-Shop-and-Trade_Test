using System;
using UnityEngine;

public class SalesHandler : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void Sell(Item item)
    {
        _player.RemoveItem(item);
        _player.EarnMoney(item.Price);
    }
}