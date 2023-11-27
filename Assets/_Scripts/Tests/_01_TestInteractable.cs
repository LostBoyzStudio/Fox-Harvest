using UnityEngine;

public class _01_TestInteractable : MonoBehaviour
{
    [SerializeField]
    private Interactable _interactable;
    [SerializeField]
    private Transform _interactor;

    private void Update()
    {
        if (_interactable != null && Input.GetKeyDown(KeyCode.Space))
        {
            _interactable.Interact(_interactor);
        }
    }
}
