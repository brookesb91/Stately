using System;
using Xunit;

namespace Stately.Tests
{
  public class UnitTests
  {
    [Fact]
    public void Expect_Value_To_Be_Initial_Value()
    {
      var store = CreateTestStore();

      Assert.Equal(store.State, 0);
    }

    [Fact]
    public void Expect_Value_To_Be_Incremented()
    {
      var store = CreateTestStore();

      store.Dispatch(new CounterActions.Increment());

      Assert.Equal(store.State, 1);
    }

    [Fact]
    public void Expect_Value_To_Be_Decremented() { }

    private Store<int> CreateTestStore()
    {
      CounterReducer reducer = new CounterReducer();
      return new Store<int>(reducer, 0);
    }

    protected class CounterActions
    {
      public class Initialise { }
      public class Increment { }
      public class Decrement { }
    }

    protected class CounterReducer : Reducer<int>
    {
      public CounterReducer()
      {
        On<CounterActions.Initialise>((state, action) => 0);
        On<CounterActions.Increment>((state, action) => state + 1);
        On<CounterActions.Decrement>((state, action) => state - 1);
      }
    }
  }
}
