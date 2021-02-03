namespace Stately
{
  public class Store<TState> : IStore<TState>
  {
    private IReducer<TState> _reducer;

    private TState _state;

    public TState State { get { return _state; } }

    public Store(IReducer<TState> reducer, TState initialState = default(TState))
    {
      _reducer = reducer;
      _state = initialState;
    }

    public void Dispatch<TAction>(TAction action) where TAction : Action
    {
      _state = _reducer.Apply(_state, action);
    }

    public TResult Select<TResult>(System.Func<TState, TResult> projector)
    {
      return projector(State);
    }
  }
}