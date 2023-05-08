using UnityEngine;
using UnityEngine.Serialization;

public class Main : MonoBehaviour
{
    private const int StartMoney = 1000;
    [SerializeField] private MoneyPanel _moneyPanel;
    
    [SerializeField] private Customer _customer;
    [SerializeField] private MarketModel _marketModel;


    [SerializeField] private Market _sellingMarket;
    [SerializeField] private Market _buyingMarket;

    [SerializeField] private PurchaseHandler _purchaseHandler;
    [SerializeField] private DisappearingMessage _message;

    [SerializeField] private MarketTriggerObserver _observer1, _observer2;

    private void Start()
    {
        
        _sellingMarket.Construct(_marketModel);
        _buyingMarket.Construct(_customer);

        _customer.CounterUpdated += _moneyPanel.UpdateMoney;

        _purchaseHandler.Failed += ShowFailedPurchaseMessage;
        
        _customer.Init(StartMoney);

        
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            _observer1.OnTriggerEnterEvent += UnlockCursor;
            _observer2.OnTriggerEnterEvent += UnlockCursor;
            _observer1.OnTriggerExitEvent += LockCursor;
            _observer2.OnTriggerExitEvent += LockCursor;
            LockCursor();
        }

        
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void ShowFailedPurchaseMessage()
    {
        _message.ShowMessage("You don't have enough money");
    }
}
