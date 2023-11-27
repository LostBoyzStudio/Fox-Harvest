public abstract class State<T> where T: System.Enum {
    public T EState { get; private set; }
    public abstract void Execute();
}