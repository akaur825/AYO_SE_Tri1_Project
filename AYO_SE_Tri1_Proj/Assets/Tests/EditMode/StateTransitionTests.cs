//OLIVIA SMITH
/*
 Tests for transitions: 
 (Delta(normal, lemon, speedy), 
 delta(normal, apple, slow), 
 delta(speedy, !stillwaiting, normal), 
 delta(slow, !stillwaiting, normal))
 Correct states should be returned, called by state methods
 */
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;
using TMPro;
using NSubstitute;
using System;
using NUnit.Framework.Constraints;

public class StateTransitionTests
{
    PlayerController player;
    GameObject playerObj;

    [SetUp]
    public void SetUp()
    {
        playerObj = new GameObject("Player");
        player = playerObj.AddComponent<PlayerController>();
    }

    [Test]
    public void NormalSpeedPlayerState_AdvanceState_WhenPlayerCollidesWithLemon_ReturnsSpeedyEffectTimedSpeedPlayerState()
    {
        // Arrange
        GameObject lemonObj = new GameObject("Lemon");
        lemonObj.tag = "LemonBuff";
        Collider2D lemonCollider = lemonObj.AddComponent<CircleCollider2D>();
        var state = new NormalSpeedPlayerState(player);

        // Act
        SpeedPlayerState newState = state.advanceState(lemonCollider);

        // Assert
        Assert.IsInstanceOf<SpeedyEffectTimedSpeedPlayerState>(newState);
    }

    [Test]
    public void NormalSpeedPlayerState_AdvanceState_WhenPlayerCollidesWithApple_ReturnsSlowEffectTimedSpeedPlayerState()
    {
        /// Arrange
        GameObject appleObj = new GameObject("Apple");
        appleObj.tag = "AppleDebuff";
        Collider2D appleCollider = appleObj.AddComponent<CircleCollider2D>();
        NormalSpeedPlayerState state = new NormalSpeedPlayerState(player);

        // Act
        var newState = state.advanceState(appleCollider);

        // Assert
        Assert.IsInstanceOf<SlowEffectTimedSpeedPlayerState>(newState);
    }

    [Test]
    public void SpeedyEffectTimedSpeedPlayerState_CheckTransition_WhenEffectTimeEnds_ReturnNormalSpeedPlayerState()
    {
        // Arrange
        var state = new SpeedyEffectTimedSpeedPlayerState(player);

        // Act
        var result = state.CheckTransition();

        // Assert
        Assert.AreSame(state, result);
    }

    [Test]
    public void SlowEffectTimedSpeedPlayerState_CheckTransition_WhenEffectTimeEnds_ReturnNormalSpeedPlayerState()
    {
        // Arrange
        var state = new SlowEffectTimedSpeedPlayerState(player);

        // Act
        var result = state.CheckTransition();

        // Assert
        Assert.AreSame(state, result);

    }
}
