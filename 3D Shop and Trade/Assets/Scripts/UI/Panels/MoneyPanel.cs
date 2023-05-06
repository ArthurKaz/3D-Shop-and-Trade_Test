using DG.Tweening;
using TMPro;
using UnityEngine;

public class MoneyPanel : PositionBaseUI
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _textChangeSpeed = 0.1f;
    private int _currentMoney;

    protected override void Init()
    {
        _currentMoney = 0;
        _text.text =_currentMoney.ToString();
    }

    public void UpdateMoney(int money)
    {
        float textDuration = CalculateDuration(_currentMoney, money);
        
        DOTween.To(() => _currentMoney, x => _text.text = Mathf.RoundToInt(x).ToString(), money, textDuration).OnComplete(
            delegate { _currentMoney = money; });
    }

    private float CalculateDuration(float startValue, float endValue)
    {
        float diff = Mathf.Abs(endValue - startValue);
        float duration = diff / _textChangeSpeed;
        return duration;
    }
}