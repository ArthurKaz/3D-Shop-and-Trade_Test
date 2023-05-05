using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemBuyingView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _buyButton;
    public event Action<Item> BoughtItem;
    private Item _item;

    private void Awake()
    {
        _buyButton.onClick.AddListener(OnBuyButtonPressed);
    }

    public void Show(Item item)
    {
        gameObject.SetActive(true);
        Debug.Log("show");
        _image.sprite = item.Icon;
        _item = item;
    }

    private void OnBuyButtonPressed()
    {
        BoughtItem?.Invoke(_item);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}