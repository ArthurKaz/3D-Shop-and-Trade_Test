using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    private Item _item;

    private Action<Item> Clicked;

    private void Awake()
    {
        _button.onClick.AddListener(OnClicked);
    }

    public void Init(Item item)
    {
        _item = item;
        _image.sprite = item.Icon;
        gameObject.SetActive(true);
    }

    public void OnClicked(Action<Item> clicked)
    {
        Clicked = clicked;
    }

    private void OnClicked()
    {
        Clicked?.Invoke(_item);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
