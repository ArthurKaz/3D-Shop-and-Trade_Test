using UnityEngine;

namespace Markets
{
    public class ItemSeller : MonoBehaviour
    {
        [SerializeField] private MarketTriggerObsever _observer;
        [SerializeField] private SellingItems _sellingItems;
        private void Awake()
        {
            _observer.OnTriggerEnterEvent += HandlePlayer;
            _observer.OnTriggerExitEvent += Hide;
        }

       

        private void HandlePlayer(Player obj)
        {
           _sellingItems.Init(obj);
           _sellingItems.Show();
           Cursor.lockState = CursorLockMode.None;
        }
        
        private void Hide(Player obj)
        {
            _sellingItems.Hide();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}