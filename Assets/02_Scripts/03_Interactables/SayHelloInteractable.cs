using UnityEngine;

public class SayHelloInteractable : Interactable 
{
    public override void Interact(Transform interactor)
    {
        Debug.Log($"Hello, {interactor.name}!");
    }
}
