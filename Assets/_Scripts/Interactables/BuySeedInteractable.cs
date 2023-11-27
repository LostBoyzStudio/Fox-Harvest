using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySeedInteractable : Interactable
{
    [SerializeField]
    private SeedSO _seed;
    [SerializeField]
    private int _seedValue = 1;

    public override void Interact(Transform interactor)
    {
        var carrier = interactor.GetComponent<PlayerCarrySystem>();
        var wallet = interactor.GetComponent<PlayerWalletSystem>();

        if (!carrier.HasItem)
        {
            if (wallet.Balance >= _seedValue)
            {
                wallet.CashOut(_seedValue);
                carrier.SetCarryItem(_seed);
            }
            else
            {
                Debug.Log("No Balance");
            }
        }
    }
}
