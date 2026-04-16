
using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour 
{
    private static List<CustomService> services = new();

    public static bool HasService<T>() where T : CustomService
    {
        return GetService<T>() != null;
    }

    public static T GetService<T>() where T : CustomService
    {

        foreach (CustomService service in services)
            if (service is T foundService) return foundService;
        return null;
    }

    public static void AddService<T>(T service) where T : CustomService
    {
        if (HasService<T>())
        {
            RemoveService<T>();
        }
        services.Add(service);
    }

    public static void RemoveService<T>() where T : CustomService
    {
        services.Remove(GetService<T>());
    }

    public static void ClearServices()
    {
        services.Clear();
    }
}
