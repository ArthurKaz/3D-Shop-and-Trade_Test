using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Config/items", order = 0)]
public class Item : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;
    [SerializeField] private int _price;
    [SerializeField] private string _description;
    public string Name => _name;
    public string Description => _description;
    public int Price => _price;
    public Sprite Icon => _image;
}