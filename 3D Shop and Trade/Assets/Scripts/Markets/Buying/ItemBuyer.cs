using DefaultNamespace;
using UnityEngine;

namespace Markets
{
    public class ItemBuyer : MonoBehaviour
    {
        [SerializeField] private MarketTriggerObsever _observer;
        [SerializeField] private BuyingItems _buying;
        [SerializeField] private ItemConfig _config;
        
        private void Awake()
        {
            _observer.OnTriggerEnterEvent += HandlePlayer;
            _observer.OnTriggerExitEvent += Hide;
        }
        private void HandlePlayer(Player obj)
        {
            Debug.Log("Enter");
            _buying.Show(_config.Apple);
            Cursor.lockState = CursorLockMode.None;
        }
        private void Hide(Player obj)
        {
            _buying.Hide();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}