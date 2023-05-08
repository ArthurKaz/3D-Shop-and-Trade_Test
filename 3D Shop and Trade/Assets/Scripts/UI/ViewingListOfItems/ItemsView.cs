using TMPro;
using UnityEngine;

public class ItemsView : ScaleBaseUI
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private ItemsRowContainer _itemsRowContainer;
    
    private Container<Item> _itemContainer;
    
    private ExchangeView _buttonView;

    public void Construct(ExchangeView buttonView)
    {
        _buttonView = buttonView;
    }
    
    public void Init(Container<Item> itemsContainer)
    {
        _itemContainer = itemsContainer;
    }

    public void Show()
    {
        ShowUI();
        UpdateItems();
    }

    public void UpdateItems()
    {
        _textMeshProUGUI.gameObject.SetActive(false);
        _itemsRowContainer.Clear();
        foreach (var item in _itemContainer.AllObjects())
        {
            var itemsRow = _itemsRowContainer.GetRow();
            var icon = itemsRow.ShowItem(item);
            icon.OnClicked(_buttonView.Show);
        }
    }
    public void Hide()
    {
        HideUI();
        _buttonView.Hide();
    }
    public void ShowMessage(string message)
    {
       _textMeshProUGUI.gameObject.SetActive(true);
       _textMeshProUGUI.text = message;
    }
}