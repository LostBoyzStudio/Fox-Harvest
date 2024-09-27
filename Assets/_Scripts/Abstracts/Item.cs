using UnityEngine;

public abstract class Item : ScriptableObject
{
    public new string name;
    public GameObject gfxCarryModel;
    // public Sprite sprite;

    public int MaxQuantity;
    public int StackLimit;
}
