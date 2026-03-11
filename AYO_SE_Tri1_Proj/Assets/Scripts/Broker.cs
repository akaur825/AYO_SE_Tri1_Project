using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Broker : IBroker
{
    private event Action<string> observerCollection;

    // any subscribed observer will be notified when this method is called
    public void NotifyObservers(string message)
    {
        observerCollection?.Invoke(message);
        Debug.Log("Notifying observers with message: " + message);
    }

    public void Subscribe(Action<string> handler)
    {
        observerCollection += handler;
    }

    public void Unsubscribe(Action<string> handler)
    {
       observerCollection -= handler; 
    }
}