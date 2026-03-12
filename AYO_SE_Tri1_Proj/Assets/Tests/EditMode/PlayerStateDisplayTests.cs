// YASHVI TRIVEDI

// I only tested for one specific event, which was the "SlowSpeedPlayerState" event, since the other events are pretty much the same,
// just with different text and colors, so if one of them work, all of them shoud.
// I also tested that the display subscribes and unsubscribes to the broker correctly. I used NSubstitute to create a mock broker,
// which allows verification that the Subscribe and Unsubscribe methods were called with the correct parameters.
// I tested the broker triggering the UI change besides the direct call to the OnStateChanged method,
// to ensure that the subscription mechanism itself is working as intended.
// Overall the tests are there to ensure that PlayerStateDisplay works both as a subscriber to the broker
// and that it updates the UI correctly based on the state changes it receives.


using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;
using TMPro;
using NSubstitute;
using System;

public class PlayerStateDisplayTests
{
    private GameObject obj;
    private PlayerStateDisplay display;
    private TMP_Text displayText;
    private Image displayPannel;
    private IBroker mockBroker;

    [SetUp]
    public void Setup()
    {
        display = new GameObject().AddComponent<PlayerStateDisplay>();
        displayText = new GameObject().AddComponent<TextMeshProUGUI>();
        displayPannel = new GameObject().AddComponent<Image>();

        mockBroker = Substitute.For<IBroker>();
        // injects the dependency
        display.SetDependency(mockBroker);

        // these lines are supposed to set the UI elements since they are serialized fields, this way, they don't throw a null reference exception
        display.GetType()
            .GetField("stateText", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(display, displayText);

        display.GetType()
            .GetField("stateBackground", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(display, displayPannel);
    }

    [Test]
    public void PlayerStateDisplay_SubscribesToBrokerOnStart()
    {
        // Arrange;

        // Act
        display.Start();
        // Assert
        mockBroker.Received(1).Subscribe(Arg.Any<Action<string>>());
    }

    [Test]
    public void PlayerStateDisplay_UnsubscribesFromBrokerOnDisable()
    {
        // Arrange;
        // Act
        display.OnDisable();
        // Assert
        mockBroker.Received(1).Unsubscribe(Arg.Any<Action<string>>());
    }

    [Test]
    public void OnStateChanged_SlowState_UpdatesUI()
    {
        // Arrange
        var state = "SlowEffectTimedSpeedPlayerState";
        // Act
        display.OnStateChanged(state);
        // Assert
        Assert.AreEqual("Apple! Slow...", displayText.text);
        Assert.AreEqual(Color.red, displayPannel.color);
    }

    [Test]
    public void BrokerMessage_TriggersUIChange()
    {
        // Arrange
        Action<string> handler = null;

        mockBroker
            .When(b => b.Subscribe(Arg.Any<Action<string>>()))
            .Do(call => handler = call.Arg<Action<string>>());
        display.Start();

        // Act
        handler?.Invoke("SpeedyEffectTimedSpeedPlayerState");
        // Assert
        Assert.AreEqual("Lemon! Fast!!!", displayText.text);
        Assert.AreEqual(Color.yellow, displayPannel.color);
    }

    [Test]
    public void Unsubscribe_CalledAfterDisable_NoUIChange()
    {
        // Arrange
        Action<string> handler = null;

        mockBroker
            .When(b => b.Subscribe(Arg.Any<Action<string>>()))
            .Do(call => handler = call.Arg<Action<string>>());
        mockBroker
            .When(b => b.Unsubscribe(Arg.Any<Action<string>>()))
            .Do(call => handler = null);
        display.Start();

        // Act
        display.OnDisable();
        handler?.Invoke("SlowEffectTimedSpeedPlayerState");
        // Assert
        Assert.AreNotEqual("Apple! Slow...", displayText.text);
        Assert.AreNotEqual(Color.red, displayPannel.color);
    }
}
