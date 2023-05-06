using DG.Tweening;
using UnityEngine;

public class PositionBaseUI : BaseUI
{
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private Vector2 _viewPosition;
    [SerializeField] private float _viewDuration;
    [SerializeField] private RectTransform _rectTransform;
    private Tween _tween;
    public override void ShowUI()
    {
        _rectTransform.anchoredPosition = _startPosition;
        Enable();
        _tween =  _rectTransform.DOAnchorPos(_viewPosition, _viewDuration);
    }

    public override void HideUI()
    {
        _tween.Kill();
        _rectTransform.anchoredPosition = _viewPosition;
        _tween =  _rectTransform.DOAnchorPos(_startPosition, _viewDuration).OnComplete(Disable);
    }
}