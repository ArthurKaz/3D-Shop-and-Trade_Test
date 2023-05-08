using System.Collections.Generic;
using UnityEngine;

public class ItemsRowContainer : MonoBehaviour
{
    [SerializeField] private ItemsRow _itemRowsPrefab;
    [SerializeField] private Transform _container;
    private readonly List<ItemsRow> _rows = new();
    private int _currentRow = 0;

    public ItemsRow GetRow()
    {
        if (_currentRow >= _rows.Count)
        {
            var row = Instantiate(_itemRowsPrefab, _container);
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

    public void Clear()
    {
        foreach (var row in _rows)
        {
            row.Clear();
        }

        _currentRow = 0;
    }
}
