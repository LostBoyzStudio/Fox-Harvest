using UnityEngine;

public class CustomerWalking: State {

    public override ECustomerState Type => ECustomerState.Walking;

    public CustomerWalking()
    {

    }

    public override void Enter(StateMachine stateMachine)
    {
        // Debug.Log("Entrando no estado CustomerWalking.");
    }

    public override void Update(StateMachine stateMachine)
    {
        // Debug.Log("Atualizando o estado CustomerWalking.");
    }

    public override void Exit(StateMachine stateMachine)
    {
        // Debug.Log("Saindo do estado CustomerWalking.");
    }
}
