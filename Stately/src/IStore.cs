namespace Stately
{
  public interface IStore<TState>
  {
    TState State { get; }

    void Dispatch<TAction>(TAction action) where TAction : Action;

    TResult Select<TResult>(System.Func<TState, TResult> projector);
  }
}