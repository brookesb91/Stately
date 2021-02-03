using System;
using System.Collections.Generic;

namespace Stately
{
  public class Reducer<TState> : IReducer<TState>
  {
    protected Dictionary<string, List<Func<TState, Action, TState>>> _reducers = new Dictionary<string, List<Func<TState, Action, TState>>>();
    public TState Apply<TAction>(TState state, TAction action) where TAction : Action
    {
      var type = GetActionType(typeof(TAction));

      if (_reducers.ContainsKey(type))
      {
        var reducers = _reducers[type];
        var newState = state;

        foreach (var reducer in reducers)
        {
          newState = reducer(newState, action);
        }

        return newState;
      }

      return state;
    }

    public void On<TAction>(System.Func<TState, Action, TState> reducerFn) where TAction : Action
    {

      var type = GetActionType(typeof(TAction));

      if (_reducers.ContainsKey(type))
      {
        _reducers[type].Add(reducerFn);
      }
      else
      {
        var reducers = new List<Func<TState, Action, TState>>() {
          reducerFn
        };

        _reducers.Add(type, reducers);
      }
    }

    private string GetActionType(Type type)
    {
      return (string)type
        .GetProperty("Type", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
        .GetValue(null);
    }
  }
}