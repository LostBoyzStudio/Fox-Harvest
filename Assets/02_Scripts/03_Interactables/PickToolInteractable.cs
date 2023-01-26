using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickToolInteractable : Interactable
{
    [SerializeField]
    private ToolSO _tool;

    public override void Interact(Transform interactor)
    {
        var carrier = interactor.GetComponent<PlayerCarrySystem>();

        if (!carrier.HasItem)
        {
            carrier.SetCarryItem(_tool);
        }
    }
}
