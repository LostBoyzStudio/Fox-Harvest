using UnityEngine;

public class _02_TestPlayerSystemClass : MonoBehaviour
{
    [SerializeField]
    private PlayerSystem _playerSystem; 
    [SerializeField]
    private bool _enabled = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (_enabled)
            {
                _playerSystem.DisableAllSystems();
            }
            else
            {
                _playerSystem.EnableAllSystems();
            }

            _enabled = !_enabled;
        }
    }
}
