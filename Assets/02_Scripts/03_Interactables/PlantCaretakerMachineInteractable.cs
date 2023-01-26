using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCaretakerMachineInteractable : Interactable
{
    public Material NormalMaterial;
    public Material BreakMaterial;

    public bool NeedRapair = false;
    public bool IsWorking = false;

    [SerializeField]
    private ERepairs RepairType;
    [SerializeField]
    private float BreakTimeSeconds;
    [SerializeField]
    private MeshRenderer _machineRenderer;

    private void Awake()
    {
        _machineRenderer = this.GetComponent<MeshRenderer>();
    }

    public override void Interact(Transform interactor)
    {
        var carrier = interactor.GetComponent<PlayerCarrySystem>();

        if (carrier.HasItem)
        {
            if (carrier.GetCarryItem() is ToolSO)
            {
                var tool = carrier.GetCarryItem() as ToolSO;

                if (tool.canRepair == RepairType)
                {
                    NeedRapair = false;
                    StartCoroutine(BreakCoroutine());
                    carrier.DiscardCarryItem();
                }
            }
        }
    }

    public void StartWorking()
    {
        if (!IsWorking)
        {
            IsWorking = true;
            StartCoroutine(BreakCoroutine());
        }
    }

    IEnumerator BreakCoroutine()
    {
        yield return new WaitForSeconds(BreakTimeSeconds);
        NeedRapair = true;
        _machineRenderer.material = BreakMaterial; 
    }
}
