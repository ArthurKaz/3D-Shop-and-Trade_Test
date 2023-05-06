using UnityEngine;

public class ItemsRow : MonoBehaviour
{
    [SerializeField] private IconButtonView[] _iconButtonViews;

    private int _currentShowedIndex;

    private void Awake()
    {
        Clear();
    }

    public IconButtonView ShowItem(Item item)
    {
        var icon = _iconButtonViews[_currentShowedIndex];
        icon.Init(item);
        _currentShowedIndex++;
        return icon;
    }

    public bool HasFreeIconView()
    {
        return _currentShowedIndex < _iconButtonViews.Length;
    }

    public void Clear()
    {
        _currentShowedIndex = 0;
        foreach (var iconButtonView in _iconButtonViews)
        {
            iconButtonView.Hide();
        }
    }
}