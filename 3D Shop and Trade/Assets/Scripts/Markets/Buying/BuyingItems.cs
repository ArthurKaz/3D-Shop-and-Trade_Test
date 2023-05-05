using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BuyingItems : MonoBehaviour
{
    [SerializeField] private ItemIconView _itemView;
    [SerializeField] private ItemBuyingView _buyingView;
    [SerializeField] private PurchaseHandler _purchaseHandler;

    private void Awake()
    {
        _buyingView.BoughtItem += _purchaseHandler.Purchase;
    }

    public void Show(Item item)
    {
        gameObject.SetActive(true);
        _itemView.Init(item);
        _itemView.OnClicked(_buyingView.Show);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        _buyingView.Hide();
    }
}