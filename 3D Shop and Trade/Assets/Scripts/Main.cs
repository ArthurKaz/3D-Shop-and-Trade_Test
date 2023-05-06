using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private ItemsView _buyingView;
    [SerializeField] private MoneyPanel _moneyPanel;
    [SerializeField] private Player _player;
    
    [SerializeField] private MarketModel _marketModel;

    [SerializeField] private ItemButtonView _buyingButton;

    [SerializeField] private Market _sellingMarket;

    [SerializeField] private Market _buyingMarket;


    private void Start()
    {
        _sellingMarket.Construct(_marketModel);
        _buyingMarket.Construct(_player);

        _player.CounterUpdated += _moneyPanel.UpdateMoney;
        _buyingView.Construct(_buyingButton);
        _buyingView.Init(_player);
    }
}
