namespace Stately
{
  public interface IReducer<T>
  {
    T Apply(T state, object action);
  }
}