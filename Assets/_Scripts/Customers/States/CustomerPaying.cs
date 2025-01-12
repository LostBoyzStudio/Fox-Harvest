using UnityEngine;

public class CustomerPaying: State {

    public override ECustomerState Type => ECustomerState.Paying;

    CustomerManager _customerManager;

    Vector3 _stopPos;

    public CustomerPaying()
    {
        _customerManager = CustomerManager.Instance;
    }

    public override void Enter(StateMachine stateMachine)
    {
        // Debug.Log("Entrando no estado CustomerPaying.");
        _stopPos = _customerManager.GetPaymentSpot();
        stateMachine.Transform.GetComponent<CustomerMovement>().MoveTo(_stopPos);
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
