using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public interface IBroker
{
    void NotifyObservers<T>(T m);
    void Subscribe<T>(Action<T> handler);
    void Unsubscribe<T>(Action<T> handler);
}
