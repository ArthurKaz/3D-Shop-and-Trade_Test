using System;
using UnityEngine;

public abstract class ExchangeHandler : MonoBehaviour
{
    public event Action<Item> ExchangeSuccess;

    public IPriceMaker PriceMaker { get; protected set; } = new NullPriceMaker();
    public abstract void Exchange(Item item);

    protected void OnExchangeSuccess(Item obj)
    {
        ExchangeSuccess?.Invoke(obj);
    }
}