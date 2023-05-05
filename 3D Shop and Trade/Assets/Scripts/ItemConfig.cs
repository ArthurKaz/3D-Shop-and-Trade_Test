using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Config", menuName = "Config/items", order = 0)]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private Food _apple;

        public Food Apple => _apple;
    }
}