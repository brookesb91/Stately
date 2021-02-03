namespace Stately
{
  public interface IReducer<T>
  {
    T Apply<TAction>(T state, TAction action) where TAction : Action;
  }
}