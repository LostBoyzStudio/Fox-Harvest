using UnityEngine;

[CreateAssetMenu(fileName = "New Seed", menuName = "Item/Seed")]
public class SeedSO : Item
{
    public EVegetable type;
    public GameObject[] growthModels;
    public VegetableSO vegetable;
    internal float growthSeconds = 2.0f;

    public int growthLevel { get => growthModels.Length - 1; }
}

public enum EVegetable { Roots, Greenery, Vegetables }