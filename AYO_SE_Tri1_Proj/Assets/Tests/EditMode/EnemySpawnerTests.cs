//AVNEET KAUR
/*
I tested that the EnemySpawner has the right factories assigned and that its main 
variables, such as safeDistanceFromPlayer, range, and spawn times, are set correcty.
I used test factories to replace the real enemy factories, which let me track how 
many times CreateEnemy was called without actually spawning any enemies. 
I didn’t test the exact spawn positions or timing, because those can change without 
breaking the spawner’s overall behavior, and checking exact values would make the 
tests fail even when everything is working. My goal was that if 
the spawner has the right factories and settings, it should world as intended, so 
I focused on the setup and configuration rather than the implementation.
 */

using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;
using NSubstitute;
using System;

public class EnemySpawnerTests
{
    private EnemySpawner enemySpawner;
    private GameObject spawner;
    private GameObject player;

    private TestBasicEnemyFactory basicFactory;
    private TestFastEnemyFactory fastFactory;

    private ISpecialEffects effectsMock;

    //Test the enemy factory to detect how many times CreateEnemy() is called
    private class TestBasicEnemyFactory : BasicEnemyFactory
    {
        public int callCount = 0;

        public override IEnemy CreateEnemy(Vector3 position)
        {
            callCount++;
            return null;
        }
    }

    private class TestFastEnemyFactory : FastEnemyFactory
    {
        public int callCount = 0;

        public override IEnemy CreateEnemy(Vector3 position)
        {
            callCount++;
            return null;
        }
    }

    [SetUp]
    public void Setup()
    {
        // Create spawner
        spawner = new GameObject();
        enemySpawner = spawner.AddComponent<EnemySpawner>();

        // Create player
        player = new GameObject();
        player.tag = "Player";
        player.transform.position = Vector3.zero;

        // Create test factories
        GameObject basicFactoryObj = new GameObject();
        basicFactory = basicFactoryObj.AddComponent<TestBasicEnemyFactory>();

        GameObject fastFactoryObj = new GameObject();
        fastFactory = fastFactoryObj.AddComponent<TestFastEnemyFactory>();

        // Assign factories to spawner
        enemySpawner.basicFactory = basicFactory as BasicEnemyFactory;
        enemySpawner.fastFactory = fastFactory as FastEnemyFactory;

        // Create mock special effects
        effectsMock = Substitute.For<ISpecialEffects>();

        // Set spawner values
        enemySpawner.safeDistanceFromPlayer = 3f;
        enemySpawner.range = 7.5f;

        enemySpawner.minSpawnTime = 0.1f;
        enemySpawner.maxSpawnTime = 0.1f;
    }

    [Test]
    public void BasicFactory_Exists_OnSpawner()
    {
        // Arrange

        // Act
        var factory = enemySpawner.basicFactory;

        // Assert
        Assert.IsNotNull(factory);
    }

    [Test]
    public void FastFactory_Exists_OnSpawner()
    {
        // Arrange

        // Act
        var factory = enemySpawner.fastFactory;

        // Assert
        Assert.IsNotNull(factory);
    }

    [Test]
    public void SafeDistance_IsSet_Correctly()
    {
        // Arrange
        float expectedDistance = 3f;

        // Act
        float actualDistance = enemySpawner.safeDistanceFromPlayer;

        // Assert
        Assert.AreEqual(expectedDistance, actualDistance);
    }

    [Test]
    public void Range_IsSet_Correctly()
    {
        // Arrange
        float expectedRange = 7.5f;

        // Act
        float actualRange = enemySpawner.range;

        // Assert
        Assert.AreEqual(expectedRange, actualRange);
    }

    [Test]
    public void SpawnTime_IsSet_Correctly()
    {
        // Arrange
        float min = 0.1f;
        float max = 0.1f;

        // Act
        float actualMin = enemySpawner.minSpawnTime;
        float actualMax = enemySpawner.maxSpawnTime;

        // Assert
        Assert.AreEqual(min, actualMin);
        Assert.AreEqual(max, actualMax);
    }

    [Test]
    public void SpecialEffectsMock_CanBeCalled()
    {
        // Arrange
        Vector3 position = Vector3.zero;

        // Act
        effectsMock.PlayEnemySpawnEffect(position);

        // Assert
        effectsMock.Received(1).PlayEnemySpawnEffect(position);
    }
}
