using System;
using System.Collections.Generic;
using System.Linq;

namespace Stately
{
  public class Reducer<TState> : IReducer<TState>
  {
    private readonly Dictionary<Type, List<Func<TState, object, TState>>> _reducers = new Dictionary<Type, List<Func<TState, object, TState>>>();
    public TState Apply(TState state, object action)
    {
      if (_reducers.ContainsKey(action.GetType()))
      {
        return _reducers[action.GetType()]
          .Aggregate(state, (newState, reducer) => reducer(newState, action));
      }

      return state;
    }

    public void On<TAction>(System.Func<TState, TAction, TState> reducerFn) where TAction : class
    {
      if (_reducers.ContainsKey(typeof(TAction)))
      {
        _reducers[typeof(TAction)].Add(reducerFn as Func<TState, object, TState>);
      }
      else
      {
        var reducers = new List<Func<TState, object, TState>>() {
          reducerFn as Func<TState, object, TState>
        };

        _reducers.Add(typeof(TAction), reducers);
      }
    }
  }
}