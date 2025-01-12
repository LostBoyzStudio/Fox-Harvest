using UnityEngine;

public class CustomerWaiting: State {

    public override ECustomerState Type => ECustomerState.Waiting;

    CustomerManager _customerManager;

    Vector3 _stopPos;

    float _waitTime;
    float _currentWaiting;
    int _customerPosition;

    public CustomerWaiting(float waitTime)
    {
        this._waitTime = waitTime;
        _customerManager = CustomerManager.Instance;
    }

    public override void Enter(StateMachine stateMachine)
    {
        _currentWaiting = 0;
        // Debug.Log("Entrando no estado CustomerWaiting.");
        _customerManager.onCustomerAttended += OnCustomerAttended;
        // check if has space
        if (_customerManager.CustomersCount < _customerManager.CustomersMax)
        {
            // reference to the customer
            CustomerController cc = stateMachine.Transform.GetComponent<CustomerController>();
            // add this customer in the queue
            _customerManager.AddCustomerInQueue(cc);
            // set refence to the queue position
            _customerPosition = cc.QueuePosition;
            // move to that position
            _stopPos = _customerManager.GetQueuePosition(_customerPosition);
            stateMachine.Transform.GetComponent<CustomerMovement>().MoveTo(_stopPos);
        } else
        {
            // Exit with rage?
            stateMachine.ChangeState(ECustomerState.Exiting);
        }
    }

    public override void Update(StateMachine stateMachine)
    {
        // Debug.Log("Atualizando o estado CustomerWaiting.");
        // TODO: start count when stop moving
        _currentWaiting += Time.deltaTime;
        if (_currentWaiting >= _waitTime)
        {
            // Exit with rage?
            stateMachine.ChangeState(ECustomerState.Exiting);
            _customerManager.RemoveCustomerFromQueue(_customerPosition);
        }
        // reached stop position in queue
        if (Vector3.Distance(stateMachine.Transform.position, _stopPos) < 0.1f)
        {
            if (_customerManager.AttendingSpotIsFree()) _customerManager.AttendCustomer();
        }
    }

    public override void Exit(StateMachine stateMachine)
    {
        // Debug.Log("Saindo do estado CustomerWaiting.");
        _customerManager.onCustomerAttended -= OnCustomerAttended;
    }

    void OnCustomerAttended(CustomerController customer)
    {
        // every customer movement, gain 1 second
        _currentWaiting -= 1f;
        // on customer attended current state should move to the next position in the queue
        
        // MoveTo();
    }
}
