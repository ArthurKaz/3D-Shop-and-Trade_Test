using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonView : ScaleBaseUI
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _buyButton;
    public event Action<Item> ClickedItem;
    private Item _item;

    protected override void Init()
    {
        _buyButton.onClick.AddListener(OnBuyButtonPressed);
    }

    public void Show(Item item)
    {
        ShowUI();
        Debug.Log("show");
        _image.sprite = item.Icon;
        _item = item;
    }

    private void OnBuyButtonPressed()
    {
        ClickedItem?.Invoke(_item);
    }

    public void Hide()
    {
        HideUI();
        //gameObject.SetActive(false);
    }
}