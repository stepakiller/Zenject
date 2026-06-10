using System;
using System.Collections.Generic;
public class UISwitcher
{
    Dictionary<Type, IUIState> _states = new Dictionary<Type, IUIState>();
    IUIState _currentState;
    public void AddState<T>(T state) where T : IUIState =>_states.Add(typeof(T), state);
    public void SwitchState<T>() where T : IUIState
    {
        _currentState?.Exit();
        if (_states.TryGetValue(typeof(T), out var newState))
        {
            _currentState = newState;
            _currentState.Enter();
        }
    }
}