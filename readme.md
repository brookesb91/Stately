# Stately

## Using the default reducer

Example using the default reducer implementation.

```cs
using Stately;

/// Actions that can be dispatched to the store.
public class CounterActions
{
  public class Increment { }

  public class Decrement { }
}

/// Basic reducer implementation.
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

## Using a custom reducer

Example using a custom reducer implementation.

```cs
public class CounterActions
{
  public class Increment { }
  public class Decrement { }
}

public class CounterReducer : IReducer<int>
{
  public int Apply(int state, object action)
  {
    switch (action)
    {
      case CounterActions.Increment inc:
        return state++;

      case CounterActions.Decrement dec:
        return state--;

      default:
        return state;
    }
  }
}

public static class Program
{
  public static void Main()
  {
    CounterReducer reducer = new CounterReducer();
    Store<int> store = new Store<int>(reducer, 0);

    store.Dispatch(new CounterActions.Increment());
    store.Dispatch(new CounterActions.Decrement());
  }
}
```
