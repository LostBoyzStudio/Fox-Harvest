using UnityEngine;

public class CustomerWaiting: State {

    public override ECustomerState Type => ECustomerState.Waiting;

    public override void Enter(StateMachine stateMachine)
    {
        Debug.Log("Entrando no estado CustomerWaiting.");
    }

    public override void Update(StateMachine stateMachine)
    {
        Debug.Log("Atualizando o estado CustomerWaiting.");
    }

    public override void Exit(StateMachine stateMachine)
    {
        Debug.Log("Saindo do estado CustomerWaiting.");
    }
}
