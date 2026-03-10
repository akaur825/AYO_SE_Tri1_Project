using NSubstitute;
using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.TestTools;
public class BrokerTests
{
    private Broker messenger;

    [SetUp]
    public void SetUp()
    {
        messenger = new Broker();
    }

    //[Test]
    //public void SubscriberReceivesSpeedyStateMessage()
    //{
    //    bool received = false;

    //    messenger.Subscribe<PlayerStateChanged>(msg =>
    //    {
    //        if (msg.State is SpeedySpeedPlayerState)
    //            received = true;
    //    });

    //    //var speedyState = new SpeedySpeedPlayerState();
    //    // SHOULD BE messenger.NotifyObservers(new PlayerStateChanged(speedyState)) BUT THIS IS FINE FOR NOW BECAUSE WE ONLY HAVE ONE STATE CHANGE TO ACCOUNT FOR, BUT THIS NEEDS TO BE FIXED TO ACCOUNT FOR ALL STATES CHANGING, NOT JUST SPEEDY PLAYER SPEED STATE
    //    messenger.NotifyObservers(speedyState);

    //    Assert.IsTrue(received);
    //}

    //[Test]
    //public void UnsubscribedHandlerDoesNotReceive()
    //{
    //    bool received = false;
    //    Action<PlayerStateChanged> handler = msg => received = true;

    //    messenger.Subscribe(handler);
    //    messenger.Unsubscribe(handler);

    //    messenger.NotifyObservers(new PlayerStateChanged(PlayerState.SpeedyPlayerSpeedState));

    //    Assert.IsFalse(received);
    //}
}