using UnityEngine;

public class CustomerPaying: State {

    public override ECustomerState Type => ECustomerState.Paying;

    public CustomerPaying()
    {

    }

    public override void Enter(StateMachine stateMachine)
    {
        // Debug.Log("Entrando no estado CustomerPaying.");
    }

    public override void Update(StateMachine stateMachine)
    {
        // Debug.Log("Atualizando o estado CustomerPaying.");
    }

    public override void Exit(StateMachine stateMachine)
    {
        // Debug.Log("Saindo do estado CustomerPaying.");
    }
}
