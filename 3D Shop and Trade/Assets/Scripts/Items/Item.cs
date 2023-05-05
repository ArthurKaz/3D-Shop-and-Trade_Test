using UnityEngine;

public interface Item
{
    public string Name { get; }
    public string Description { get; }
    public int Price { get; }
    public Sprite Icon { get; }
    public int Quantity { get; }
}