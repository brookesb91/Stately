using Xunit;

namespace Stately.Tests
{
  public class UnitTests
  {

    [Fact]
    public void Expect_Value_To_Be_Initial_Value()
    {
      var store = CreateTestStore(0);

      Assert.Equal(0, store.State);
    }

    [Fact]
    public void Expect_Value_To_Be_Incremented()
    {
      var store = CreateTestStore(0);

      store.Dispatch(new CounterActions.Increment());

      Assert.Equal(1, store.State);
    }

    [Fact]
    public void Expect_Value_To_Be_Decremented()
    {
      var store = CreateTestStore(0);

      store.Dispatch(new CounterActions.Decrement());

      Assert.Equal(-1, store.State);
    }

    private Store<int> CreateTestStore(int value)
    {
      CounterReducer reducer = new CounterReducer();
      return new Store<int>(reducer, value);
    }

    protected class CounterActions
    {
      public class Initialise : Action
      {
        public static new string Type => "[counter] INITIALISE";
      }
      public class Increment : Action
      {
        public static new string Type => "[counter] INCREMENT";
      }
      public class Decrement : Action
      {
        public static new string Type => "[counter] DECREMENT";
      }
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
