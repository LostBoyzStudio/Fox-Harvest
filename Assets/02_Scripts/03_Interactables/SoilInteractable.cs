using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoilStateSystem))]
public class SoilInteractable : Interactable
{
    [SerializeField]
    private SoilStateSystem _soil;

    private void Awake()
    {
        _soil = this.GetComponent<SoilStateSystem>();
    }

    public override void Interact(Transform interactor)
    {
        var carrier = interactor.GetComponent<PlayerCarrySystem>();

        if (!_soil.HasSeed && !_soil.HasVegetable && carrier.HasItem)
        {
            if (carrier.GetCarryItem() is SeedSO)
            {
                _soil.PutSeed(carrier.GetCarryItem() as SeedSO);
                carrier.DiscardCarryItem();
            }
        }
        else if (_soil.HasVegetable)
        {
            carrier.SetCarryItem(_soil.GetVegetable());
            _soil.DiscardSeed();
        }
        else if (_soil.HasSeed)
        {

        }
    }
}
