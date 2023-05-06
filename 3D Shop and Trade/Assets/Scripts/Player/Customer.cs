
using System;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour, Container<Item>, ICounter<int>
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
    public event Action<int> CounterUpdated;

    public void Init(int money) => Money = money;

    public void Add(Item obj) => _items.Add(obj);

    public void Remove(Item item) => _items.Remove(item);

    public bool HasMoney(int price) => price <= Money;

    public void SpendMoney(int price)
    {
        if (HasMoney(price) == false)
        {
            Debug.LogError("You don't have enough money");
        }
        Money -= price;
    }

    public void EarnMoney(int price) => Money += price;

    public List<Item> AllObjects() => _items;

    private void OnCounterUpdated() => CounterUpdated?.Invoke(Money);
}