# Stately

```cs
using Stately;

public class CounterActions
{
  public class Increment { }
  public class Decrement { }
}

public class CounterReducer : Reducer<int>
{
  public CounterReducer()
  {
    On<CounterActions.Increment>((state, action) => state++);
    On<CounterActions.Decrement>((state, action) => state--);
  }
}

public static class Program
{
  public static void Main()
  {
    CounterReducer reducer = new CounterReducer();
    Store<int> store = new Store<int>(reducer, 0);

    store.Dispatch(new CounterActions.Increment());

    Console.WriteLine(store.State); /// -> 1

    store.Dispatch(new CounterActions.Decrement());

    Console.WriteLine(store.State) /// -> 0
  }
}
```
