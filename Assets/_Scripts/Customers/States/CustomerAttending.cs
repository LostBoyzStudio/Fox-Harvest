using UnityEngine;

public class CustomerAttending: State {
    public override ECustomerState Type => ECustomerState.Attending;
    
    public CustomerAttending()
    {
        // TODO
    }

    public override void Enter(StateMachine stateMachine)
    {
        // Debug.Log("Entrando no estado CustomerAttending.");
    }

    public override void Update(StateMachine stateMachine)
    {
        // Debug.Log("Atualizando o estado CustomerAttending.");
    }

    public override void Exit(StateMachine stateMachine)
    {
        // Debug.Log("Saindo do estado CustomerAttending.");
    }
}
