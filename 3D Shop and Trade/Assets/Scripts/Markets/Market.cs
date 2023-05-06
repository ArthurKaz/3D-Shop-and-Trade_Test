using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Market : MonoBehaviour
{
    [SerializeField] private ExchangeHandler _exchangeHandler;
    [SerializeField] private MarketTriggerObserver _observer;
    [SerializeField] private ItemsView _itemsView;
    [SerializeField] private ItemButtonView _itemButtonView;
    private Container<Item> _items;
    public void Construct(Container<Item> items)
    {
        _items = items;
        _itemButtonView.ClickedItem += _exchangeHandler.Exchange;
        _itemButtonView.ClickedItem += UpdateMarket;
        _itemsView.Construct(_itemButtonView);
        _itemsView.Init(_items);
        _observer.OnTriggerEnterEvent += ShowSelling;
        _observer.OnTriggerExitEvent += HideSelling;
      
    }
    private void ShowSelling()
    {
        _itemsView.Show();
    }

    private void HideSelling()
    {
        _itemsView.Hide();
    }
    private void UpdateMarket(Item item)
    {
        _items.Remove(item);
        _itemsView.UpdateItems();
        _itemButtonView.HideUI();
    }
}