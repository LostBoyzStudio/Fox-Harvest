using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T: System.Enum
{
    State<T> currentState;

    Dictionary<T, State<T>> states;
    public StateMachine(List<State<T>> states) {
        this.states = new Dictionary<T, State<T>>();
        foreach (State<T> state in states)
        {
            this.states.Add(state.EState, state);
        }
    }

    public void Execute() {
        currentState.Execute();
    }
}
