namespace Stately
{
  public interface IReducer<T>
  {
    T Apply(T state, object action);
  }
}

public class CounterReducer : Stately.Reducer<int>
{
  public CounterReducer()
  {
    On<CounterActions.Increment>((state, action) => state++);
    On<CounterActions.Decrement>((state, action) => state--);
  }

  public class CounterActions
  {
    public class Increment { }
    public class Decrement { }
  }
}