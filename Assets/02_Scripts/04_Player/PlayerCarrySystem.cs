using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarrySystem : PlayerSystem
{
    [SerializeField]
    private Item _carryItem;
    [SerializeField]
    private Transform _carryItemGfx;

    public bool HasItem
    {
        get => _carryItem != null;
    }

    public void SetCarryItem(Item item)
    {
        DiscardCarryItem();
        _carryItem = item;
        GameObject carryItemObj = Instantiate(item.gfxCarryModel, _carryItemGfx);
    }

    public Item GetCarryItem()
    {
        return _carryItem;
    }

    public void DiscardCarryItem()
    {
        if (_carryItemGfx.childCount > 0) {
            foreach (Transform carryItem in _carryItemGfx)
            {
                Destroy(carryItem.gameObject);
            }
        }
        _carryItem = null;
    }
}
