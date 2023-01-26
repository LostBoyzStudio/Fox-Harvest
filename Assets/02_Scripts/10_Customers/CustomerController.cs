using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECustomerState { Entering, Waiting, Attending, Exiting };

public class CustomerController : MonoBehaviour
{
    public ECustomerState state;
    
    public delegate void OnChangeState(ECustomerState state);
    public OnChangeState onChangeState;

    StateMachine<ECustomerState> stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        state = ECustomerState.Entering;
        List<State<ECustomerState>> states = new List<State<ECustomerState>>();
        states.Add(new CustomerWaiting());
        states.Add(new CustomerExiting());
        states.Add(new CustomerEntering());
        states.Add(new CustomerAttending());
            
        stateMachine = new StateMachine<ECustomerState>(states);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeState(ECustomerState state) {
        this.state = state;
        // stateMachine.
        onChangeState?.Invoke(this.state);
    }
}
