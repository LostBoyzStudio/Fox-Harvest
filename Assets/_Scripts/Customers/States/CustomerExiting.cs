using UnityEngine;

public class CustomerExiting: State {

    public override ECustomerState Type => ECustomerState.Exiting;

    public override void Enter(StateMachine stateMachine)
    {
        Debug.Log("Entrando no estado CustomerExiting.");
    }

    public override void Update(StateMachine stateMachine)
    {
        Debug.Log("Atualizando o estado CustomerExiting.");
    }

    public override void Exit(StateMachine stateMachine)
    {
        Debug.Log("Saindo do estado CustomerExiting.");
    }
}
