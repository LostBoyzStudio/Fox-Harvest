public abstract class State {
    public abstract ECustomerState Type { get; }
    public abstract void Enter(StateMachine stateMachine);
    public abstract void Update(StateMachine stateMachine);
    public abstract void Exit(StateMachine stateMachine);
}
