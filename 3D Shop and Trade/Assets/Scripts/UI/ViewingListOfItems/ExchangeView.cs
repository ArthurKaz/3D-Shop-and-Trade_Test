using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeView : ScaleBaseUI
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI _textPrice;
    [SerializeField] private TextMeshProUGUI _textDescription;
    [SerializeField] private TextMeshProUGUI _textName;
    public event Action<Item> ClickedItem;
    private IPriceMaker _priceMaker = new NullPriceMaker(); 
    private Item _item;

    protected override void Init()
    {
        _buyButton.onClick.AddListener(OnBuyButtonPressed);
    }

    public void Init(IPriceMaker priceMaker)
    {
        _priceMaker = priceMaker;
    }
    public void Show(Item item)
    {
        ShowUI();
        _item = item;
        LoadItem();
    }
    public void Hide() => HideUI();

    private void LoadItem()
    {
        _image.sprite = _item.Icon;

        _textName.text = _item.Name;
        _textDescription.text = _item.Description;
        _textPrice.text = _priceMaker.FormPrice(_item.Price).ToString();
    }

    private void OnBuyButtonPressed()
    {
        ClickedItem?.Invoke(_item);
    }
}