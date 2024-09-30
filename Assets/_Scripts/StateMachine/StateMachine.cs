using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    #region Callbacks
    public delegate void OnChangeState(ECustomerState state);
    public OnChangeState onChangeState;
    #endregion

    State _currentState;

    Dictionary<ECustomerState, State> _states;

    public Transform Transform { get; private set; }

    public StateMachine(Transform transform, List<State> states) {
        this.Transform = transform;
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

    public void ChangeState(ECustomerState newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit(this);
        }

        _currentState = _states[newState];
        _currentState.Enter(this);
        
        onChangeState?.Invoke(newState);
    }
}
