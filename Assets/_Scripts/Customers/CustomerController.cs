using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECustomerState { Entering, Waiting, Attending, Exiting, Paying, Walking };

public class CustomerController : MonoBehaviour
{
    public ECustomerState CurrentState { get; private set; }

    public int QueuePosition { get; private set; }

    StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        this.CurrentState = ECustomerState.Entering;
        List<State> states = new List<State>();

        // TODO: refazer as funções construtoras de cada elemento
        states.Add(new CustomerAttending());
        states.Add(new CustomerEntering());
        states.Add(new CustomerExiting());
        states.Add(new CustomerWaiting(6f));
        states.Add(new CustomerPaying());
        states.Add(new CustomerWalking());
            
        stateMachine = new StateMachine(this.transform, states);
        stateMachine.ChangeState(this.CurrentState);

        stateMachine.onChangeState += OnChangeState;
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Execute();
    }

    public void SetCurrentQueuePosition(int queuePos)
    {
        QueuePosition = queuePos;
    }

    public void RecieveOrder()
    {
        stateMachine.ChangeState(ECustomerState.Paying);
    }

    void OnChangeState(ECustomerState newState)
    {
        this.CurrentState = newState;
    }

    void OnDestroy()
    {
        stateMachine.onChangeState -= OnChangeState;
    }
}
