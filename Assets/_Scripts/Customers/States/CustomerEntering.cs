using UnityEngine;

public class CustomerEntering: State {

    public override ECustomerState Type => ECustomerState.Entering;
    
    public override void Enter(StateMachine stateMachine)
    {
        Debug.Log("Entrando no estado CustomerEntering.");
    }

    public override void Update(StateMachine stateMachine)
    {
        Debug.Log("Atualizando o estado CustomerEntering.");
    }

    public override void Exit(StateMachine stateMachine)
    {
        Debug.Log("Saindo do estado CustomerEntering.");
    }
}
