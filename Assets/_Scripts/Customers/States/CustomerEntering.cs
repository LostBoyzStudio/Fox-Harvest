using UnityEngine;

public class CustomerEntering: State {

    public override ECustomerState Type => ECustomerState.Entering;

    Vector3 _stopPos;

    public CustomerEntering()
    {
        this._stopPos = CustomerManager.Instance.GetEnteringSpot();
    }
    
    public override void Enter(StateMachine stateMachine)
    {
        stateMachine.Transform.GetComponent<CustomerMovement>().MoveTo(_stopPos);
        // Debug.Log("Entrando no estado CustomerEntering.");
    }

    public override void Update(StateMachine stateMachine)
    {
        // Debug.Log("Atualizando o estado CustomerEntering.");
        if (Vector3.Distance(stateMachine.Transform.position, _stopPos) < 0.1f)
        {
            stateMachine.ChangeState(ECustomerState.Waiting);
        }
    }

    public override void Exit(StateMachine stateMachine)
    {
        // Debug.Log("Saindo do estado CustomerEntering.");
    }
}
