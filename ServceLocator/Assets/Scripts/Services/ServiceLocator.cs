using System;
using System.Collections.Generic;
public class ServiceLocator : IServiceLocator
{
    readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();
    public void RegisterService<T>(T service)
    {
        var type = typeof(T);
        if (!_services.ContainsKey(type)) _services.Add(type, service);
    }
    public T GetService<T>()
    {
        var type = typeof(T);
        if (_services.TryGetValue(type, out var service)) return (T)service;
        throw new Exception($"Service {type} не зареган");
    }
}