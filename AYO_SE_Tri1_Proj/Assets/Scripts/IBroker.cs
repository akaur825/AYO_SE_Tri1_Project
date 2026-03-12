using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public interface IBroker
{
    void NotifyObservers(string message);
    void Subscribe(Action<string> handler);
    void Unsubscribe(Action<string> handler);
}
