using System.Collections.Generic;
using UnityEngine;

namespace Markets
{
    public class SellingItems : MonoBehaviour
    {
        [SerializeField] private ItemIconView _itemIconView;
        [SerializeField] private Transform _container;

        [SerializeField] private ItemBuyingView _itemBuyingView;
        [SerializeField] private SalesHandler _salesHandler;

        private Container<Item> _itemContainer;
         private List<ItemIconView> _iconViews = new();

         private Queue<ItemIconView> _free;
         private void Awake()
         {
            
             _itemBuyingView.BoughtItem += _salesHandler.Sell;
             _itemBuyingView.BoughtItem += UpdateView;

         }

         private void UpdateView(Item obj)
         {
             _itemBuyingView.Hide();
             Clear();
             DisplayItems();
         }

         public void Init(Container<Item> container)
         {
             _itemContainer = container;
         }
         public void Show()
        {
            Clear();
            gameObject.SetActive(true);
            DisplayItems();
           
        }
         private void DisplayItems(){ foreach (var item in _itemContainer.AllObjects())
         {
             Debug.Log(item.Name);
             var obj = GetItemIconView();
             obj.Init(item);
             _iconViews.Add(obj);
         }}

        private void Clear()
        {
            if (_iconViews.Count > 0)
            {
                _free = new Queue<ItemIconView>(_iconViews);
            }
            else
            {
                _free = new Queue<ItemIconView>();
            }

            foreach (var iconView in _iconViews)
            {
                iconView.Hide();
            }
            _iconViews = new List<ItemIconView>();
        }

        private ItemIconView GetItemIconView()
        {
            if (_free == null || _free.Count == 0)
            {
                var obj = Instantiate(_itemIconView, _container);
                obj.OnClicked(_itemBuyingView.Show);
                return obj;
            }
            return _free.Dequeue();
        }

        public void Hide()
        {
           gameObject.SetActive(false);
           _itemBuyingView.Hide();
        }
    }
}