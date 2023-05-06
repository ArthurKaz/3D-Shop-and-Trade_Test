using System.Collections.Generic;
using UnityEngine;

public class MarketModel : MonoBehaviour, Container<Item>
{
    [SerializeField] private List<Item> _itemsForBuy;

    public List<Item> AllObjects()
    {
        return _itemsForBuy;
    }

    public void Remove(Item item)
    {
        _itemsForBuy.Remove(item);
    }
}