using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Item/Tool")]
public class ToolSO : Item 
{
    public ERepairs canRepair;    
}

public enum ERepairs { Pipe, Temperature, Luminosity }