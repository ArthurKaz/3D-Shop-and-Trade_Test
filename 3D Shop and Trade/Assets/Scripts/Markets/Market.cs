using UnityEngine;
using UnityEngine.Serialization;

public class Market : MonoBehaviour
{
    [SerializeField] private ExchangeHandler _exchangeHandler;
    [SerializeField] private MarketTriggerObserver _observer;
    [SerializeField] private ItemsView _itemsView;
    [SerializeField] private ExchangeView exchangeView;
    [SerializeField] private string _emptyMessage;
    private Container<Item> _items;
    public void Construct(Container<Item> items)
    {
        _items = items;
        exchangeView.ClickedItem += _exchangeHandler.Exchange;
        _exchangeHandler.ExchangeSuccess += UpdateMarket;
        _itemsView.Construct(exchangeView);
        exchangeView.Init(_exchangeHandler.PriceMaker);
        _itemsView.Init(_items);
        _observer.OnTriggerEnterEvent += ShowSelling;
        _observer.OnTriggerExitEvent += HideSelling;
      
    }
    private void ShowSelling()
    {
        _itemsView.Show();
        if (_items.AllObjects().Count == 0)
        {
            _itemsView.ShowMessage(_emptyMessage);
        }
    }

    private void HideSelling()
    {
        _itemsView.Hide();
    }

    private void UpdateMarket(Item item)
    {
        _items.Remove(item);
        exchangeView.HideUI();
        _itemsView.UpdateItems();
        if (_items.AllObjects().Count == 0)
        {
            _itemsView.ShowMessage(_emptyMessage);
        }
    }
}