namespace Stately.Examples
{
  public class CounterExample

  {
    public void Main()
    {
      CounterReducer reducer = new CounterReducer();
      Store<int> store = new Store<int>(reducer, 0);

      store.Dispatch(new CounterActions.Increment());
      store.Dispatch(new CounterActions.Decrement());
    }

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
  }

  public class UserExample
  {
    public void Main()
    {
      User user = new User()
      {
        Name = "John Doe",
        Authorised = false
      };

      UserReducer reducer = new UserReducer();
      Store<User> store = new Store<User>(reducer, user);

      store.Dispatch(new UserActions.Login());
      store.Dispatch(new UserActions.Update("John Smith"));
      store.Dispatch(new UserActions.Logout());
    }

    public class User
    {
      public string Name { get; set; }
      public bool Authorised { get; set; }
    }

    public class UserActions
    {
      public class Login { }
      public class Logout { }
      public class Update
      {
        public string Name { get; set; }

        public Update(string name)
        {
          Name = name;
        }
      }
    }

    public class UserReducer : IReducer<User>
    {
      public User Apply(User state, object action)
      {

        switch (action)
        {
          case UserActions.Login login:
            return Login(state, action as UserActions.Login);

          case UserActions.Logout logout:
            return Logout(state, action as UserActions.Logout);

          case UserActions.Update update:
            return Update(state, action as UserActions.Update);

          default:
            return state;
        }
      }

      private User Login(User state, UserActions.Login action)
      {
        state.Authorised = true;
        return state;
      }

      private User Logout(User state, UserActions.Logout action)
      {
        state.Authorised = false;
        return state;
      }

      private User Update(User state, UserActions.Update action)
      {
        state.Name = action.Name;
        return state;
      }
    }
  }
}