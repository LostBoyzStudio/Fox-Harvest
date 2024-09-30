using UnityEngine;

public class CustomerWaiting: State {

    public override ECustomerState Type => ECustomerState.Waiting;

    CustomerManager _customerManager;

    public CustomerWaiting()
    {
        _customerManager = CustomerManager.Instance;
    }

    public override void Enter(StateMachine stateMachine)
    {
        // Debug.Log("Entrando no estado CustomerWaiting.");
        _customerManager.onCustomerAttended += CustomerAttended;
        // check if has space
        if (_customerManager.CustomersCount < _customerManager.CustomersMax)
        {
            // if true then go to last position in the queue
            Vector3 position = _customerManager.GetCurrentLastPosition();
            stateMachine.Transform.GetComponent<CustomerMovement>().MoveTo(position);
            _customerManager.AddCustomerInQueue();
        } else
        {
            // Exit with rage?
            stateMachine.ChangeState(ECustomerState.Exiting);
        }
    }

    public override void Update(StateMachine stateMachine)
    {
        // Debug.Log("Atualizando o estado CustomerWaiting.");
    }

    public override void Exit(StateMachine stateMachine)
    {
        // Debug.Log("Saindo do estado CustomerWaiting.");
        _customerManager.onCustomerAttended -= CustomerAttended;
    }

    void CustomerAttended(CustomerController customer)
    {
        // on customer attended current state should move to the next position in the queue
        // if I'm third to be attended, on customer attended I go to second
        // MoveTo();
    }
}
