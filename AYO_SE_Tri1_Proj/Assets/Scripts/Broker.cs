using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Broker : IBroker
{
    private readonly Dictionary<Type, Delegate> _observerCollection = new();

    // any subscribed observer of type T will be notified when this method is called with a message of type T
    public void NotifyObservers<T>(T m)
    {
        if (_observerCollection.TryGetValue(typeof(T), out var d))
        {
            var callback = d as Action<T>;
            callback?.Invoke(m);
        }
    }

    // observers can subscribe to receive messages of type T by providing a handler method that matches the Action<T> delegate signature
    // when a message of type T is published, all subscribed handlers will be invoked with the message as an argument
    public void Subscribe<T>(Action<T> handler)
    {
        if (_observerCollection.TryGetValue(typeof(T), out var d))
        {
            _observerCollection[typeof(T)] = Delegate.Combine(d, handler);
        }
        else
        {
            _observerCollection[typeof(T)] = handler;
        }
    }

    // observers can unsubscribe from receiving messages of type T by providing the same handler method that was used to subscribe
    // this will remove the handler from the list of subscribers for that message type, and it will no longer receive notifications when messages of that type are published
    public void Unsubscribe<T>(Action<T> handler)
    {
        if (_observerCollection.TryGetValue(typeof(T), out var d))
        {
            var currentDel = Delegate.Remove(d, handler);
            if (currentDel == null)
            {
                _observerCollection.Remove(typeof(T));
            }
            else
            {
                _observerCollection[typeof(T)] = currentDel;
            }
        }
    }
}