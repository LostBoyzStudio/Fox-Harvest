using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECustomerState { Entering, Waiting, Attending, Exiting };

public class CustomerController : MonoBehaviour
{
    public ECustomerState currentState;
    
    public delegate void OnChangeState(ECustomerState state);
    public OnChangeState onChangeState;

    StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        currentState = ECustomerState.Entering;
        List<State> states = new List<State>();
        // TODO: refazer as funções construtoras de cada elemento
        states.Add(new CustomerWaiting());
        states.Add(new CustomerExiting());
        states.Add(new CustomerEntering());
        states.Add(new CustomerAttending());
            
        stateMachine = new StateMachine(states);
        ChangeState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Execute();
    }

    void ChangeState(ECustomerState state) {
        this.currentState = state;
        // stateMachine.
        onChangeState?.Invoke(this.currentState);
    }
}
