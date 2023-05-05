using System;
using UnityEngine;

[Serializable]
public class Food : Item
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;
    [SerializeField] private int _price;
    
    public string Name => _name;
    public string Description { get; }
    public int Price => _price;
    public Sprite Icon => _image;
    public int Quantity { get; }
}