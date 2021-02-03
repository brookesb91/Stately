# Stately

## A tiny C# state management library.

### Using the default reducer

Example using the default reducer implementation.

```cs
using Stately;

/// Actions that can be dispatched to the store.
public class CounterActions
{
  public class Increment : Action
  {
    public static new string Type => "[counter] INCREMENT";
  }

  public class Decrement : Action
  {
    public static new string Type => "[counter] DECREMENT";
  }
}

/// Basic reducer implementation.
public class CounterReducer : Reducer<int>
{
  public CounterReducer()
  {
    On<CounterActions.Increment>((state, action) => state + 1);
    On<CounterActions.Decrement>((state, action) => state - 1);
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

### Using a custom reducer

Example using a custom reducer implementation.

```cs
public class CustomCounterReducer : IReducer<int>
{
  public int Apply<TAction>(TState state, TAction action) where TAction : Action
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
    CustomCounterReducer reducer = new CustomCounterReducer();
    Store<int> store = new Store<int>(reducer, 0);

    store.Dispatch(new CounterActions.Increment());
    store.Dispatch(new CounterActions.Decrement());
  }
}
```
