using UnityEngine;

public class PlayerInteractSystem : PlayerSystem 
{
    [SerializeField]
    private Transform _interactableChecker;
    [SerializeField]
    private float _checkerRadius;
    [SerializeField]
    private LayerMask _checkerLayer;

    private void Update()
    {
        if (Enabled && Input.GetKeyDown(KeyCode.Space))
        {
            if (_interactableChecker != null)
            {
                RaycastHit hit;

                if (Physics.SphereCast(this.transform.position, _checkerRadius, _interactableChecker.position, out hit, _checkerLayer))
                {
                    hit.transform.GetComponent<Interactable>().Interact(this.transform);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (_interactableChecker != null)
        {
            Gizmos.DrawWireSphere(_interactableChecker.position, _checkerRadius);
        }
    }
}
