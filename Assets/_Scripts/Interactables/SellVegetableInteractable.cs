using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellVegetableInteractable : Interactable
{
    public override void Interact(Transform interactor)
    {
        var carrier = interactor.GetComponent<PlayerCarrySystem>();
        var wallet = interactor.GetComponent<PlayerWalletSystem>();

        if (carrier.HasItem)
        {
            if (carrier.GetCarryItem() is VegetableSO)
            {
                VegetableSO vegetable = carrier.GetCarryItem() as VegetableSO;
                wallet.CashIn(vegetable.cashValue);

                carrier.DiscardCarryItem();
            }
        }
    }
}
