
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Container<Item>, ICounter<int>
{
    private readonly List<Item> _items = new();

    private int _money;
    private int Money
    {
        get => _money;
        set
        {
            _money = value;
            OnCounterUpdated();
        }
    }
    //public Item[] Items => _items.ToArray();
    private void Start()
    {
        Money = 1000;
    }
    
    public event Action<int> CounterUpdated;
    public void AddItem(Item obj)
    {
        Debug.Log(obj.Name);
        _items.Add(obj);
    }
    public void Remove(Item item)
    {
        Debug.Log(item.Name);
        _items.Remove(item);
        Debug.Log(_items.Count);
    }
    public bool HasMoney(int price)
    {
        return price <= Money;
    }
    public void SpendMoney(int price)
    {
        Money -= price;
    }

    public void EarnMoney(int price)
    {
        Money += price;
    }

    public List<Item> AllObjects()
    {
        return _items;
    }


    private void OnCounterUpdated()
    {
        CounterUpdated?.Invoke(Money);
    }
}