using System.Collections.Generic;
using UnityEngine;

public class ItemsView : ScaleBaseUI
{
    [SerializeField] private ItemsRow _itemRowsPrefab;
    [SerializeField] private Transform _container;

    private List<ItemsRow> _rows = new List<ItemsRow>();
    private int _currentRow = 0;
    private Container<Item> _itemContainer;
    
    
    private ItemButtonView _buttonView;

    public void Construct(ItemButtonView buttonView)
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
        Clear();
        foreach (var item in _itemContainer.AllObjects())
        {
            var itemsRow = GetRow();
            var icon = itemsRow.ShowItem(item);
            icon.OnClicked(_buttonView.Show);
        }
    }

    private void Clear()
    {
        foreach (var row in _rows)
        {
            row.Clear();
        }

        _currentRow = 0;
    }

    private ItemsRow GetRow()
    {
        if (_currentRow >= _rows.Count)
        {
            var row = Instantiate(_itemRowsPrefab,_container);
            _rows.Add(row);
            return row;
        }

        if (_rows[_currentRow].HasFreeIconView())
        {
            return _rows[_currentRow];
        }

        _currentRow++;
        return GetRow();
    }

    public void Hide()
    {
        HideUI();
        _buttonView.Hide();
    }

    
}