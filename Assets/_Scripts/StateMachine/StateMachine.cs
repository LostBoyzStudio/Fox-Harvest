using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    State _currentState;

    Dictionary<ECustomerState, State> _states;

    public StateMachine(List<State> states) {
        this._states = new Dictionary<ECustomerState, State>();
        foreach (State state in states)
        {
            // Debug.Log($"Adding { state }");
            this._states.Add(state.Type, state);
        }
    }

    public void Execute() {
        _currentState?.Update(this);
    }

    public void ChangeState(State newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit(this);
        }

        _currentState = newState;
        _currentState.Enter(this);
    }
}
