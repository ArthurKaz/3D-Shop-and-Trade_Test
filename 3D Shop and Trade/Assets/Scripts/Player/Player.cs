
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Container<Item>
{
    private readonly List<Item> _items = new();
    private int _money = 1000;
    //public Item[] Items => _items.ToArray();
    

    public void AddItem(Item obj)
    {
        Debug.Log(obj.Name);
        _items.Add(obj);
    }
    public void RemoveItem(Item item)
    {
        Debug.Log(item.Name);
        _items.Remove(item);
        Debug.Log(_items.Count);
    }
    public bool HasMoney(int price)
    {
        return price <= _money;
    }
    public void SpendMoney(int price)
    {
        _money -= price;
    }

    public void EarnMoney(int price)
    {
        _money += price;
    }

    public List<Item> AllObjects()
    {
        return _items;
    }
    
}