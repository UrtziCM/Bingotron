
using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    private static List<Service> services;

    public static bool HasService<T>() where T : Service
    {
        return GetService<T>() != null;
    }

    public static Service GetService<T>() where T : Service
    {
        foreach (Service service in services)
            if (service is T) return service;
        return null;
    }

    public static void AddService<T>(T service) where T : Service
    {
        if (HasService<T>())
        {
            RemoveService<T>();
        }
        services.Add(service);
    }

    public static Service GetOrAddService<T>() where T : Service
    {
        
        if (!HasService<T>())
        {
            var instance = Activator.CreateInstance(typeof(T)) as T;
            AddService<T>(instance);
            return instance;
        }
        return GetService<T>();
    }

    public static void RemoveService<T>() where T : Service
    {
        services.Remove(GetService<T>());
    }

    public static void ClearServices()
    {
        services.Clear();
    }
}
