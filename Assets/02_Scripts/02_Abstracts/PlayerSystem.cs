using UnityEngine;

public abstract class PlayerSystem : MonoBehaviour
{
    [SerializeField]
    protected bool Enabled = true;

    public void EnableSystem()
    {
        Enabled = true;
    }

    public void EnableAllSystems()
    {
        foreach (PlayerSystem system in this.GetComponents<PlayerSystem>())
        {
            system.Enabled = true;
        }
    }

    public void DisableSystem()
    {
        Enabled = false;
    }

    public void DisableAllSystems()
    {
        foreach (PlayerSystem system in this.GetComponents<PlayerSystem>())
        {
            system.Enabled = false;
        }
    }
}
