using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilStateSystem : MonoBehaviour
{
    public List<PlantCaretakerMachineInteractable> CaretakerMachines;
    public Transform SeedModelGfx;

    [SerializeField]
    private SeedSO _seed;
    [SerializeField]
    private int _growthingLevel;
    [SerializeField]
    private bool _hasVegetable = false;

    public bool HasSeed { get => _seed != null; }
    public bool HasVegetable { get => _hasVegetable; }

    internal Item GetVegetable()
    {
        return _seed.vegetable;
    }

    internal void PutSeed(SeedSO seedSO)
    {
        _seed = seedSO;
        _growthingLevel = -1;

        StartCoroutine(CheckGrowthCoroutine());

        foreach (var machine in CaretakerMachines)
        {
            machine.StartWorking();
        }
    }

    internal void DiscardSeed()
    {
        _hasVegetable = false;
        _seed = null;
        SeedModelGfx.GetComponent<MeshFilter>().mesh.Clear();
        SeedModelGfx.GetComponent<MeshRenderer>().material = null;
    }

    internal void TryGrowthSeed()
    {

        if (_growthingLevel < _seed.growthLevel)
        {
            bool canGrowth = true;

            foreach (var machine in CaretakerMachines)
            {
                if (machine.NeedRapair)
                {
                    canGrowth = false;
                }
            }

            if (canGrowth)
            {
                _growthingLevel++;
                Debug.Log($"Growth {_growthingLevel}");

                SeedModelGfx.GetComponent<MeshFilter>().sharedMesh = _seed.growthModels[_growthingLevel].GetComponent<MeshFilter>().sharedMesh;
                SeedModelGfx.GetComponent<MeshRenderer>().sharedMaterial = _seed.growthModels[_growthingLevel].GetComponent<MeshRenderer>().sharedMaterial;
            }
            else
            {
                Debug.Log("NeedRepair");
            }
        }

        if (_growthingLevel == _seed.growthLevel)
        {
            _hasVegetable = true;
        }
    }

    IEnumerator CheckGrowthCoroutine()
    {
        yield return new WaitForSeconds(_seed.growthSeconds);
        TryGrowthSeed();

        if (HasVegetable)
        {
            Debug.Log("Has Vegetable");
        }
        else
        {
            StartCoroutine(CheckGrowthCoroutine());
        }
    }
}
