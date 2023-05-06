using DG.Tweening;
using UnityEngine;

public abstract class ScaleBaseUI : BaseUI
{
    [SerializeField] private float _viewDuration;
    [SerializeField] private Vector3 _defaultScale = Vector3.one;
    private Tween _tween;

    public override void ShowUI()
    {
        transform.localScale = Vector3.zero;
        Enable();
        _tween = transform.DOScale(_defaultScale, _viewDuration);
    }

    public override void HideUI()
    {
        _tween.Kill();
        _tween = transform.DOScale(Vector3.zero, _viewDuration);
        _tween.OnComplete(Disable);
    }
}