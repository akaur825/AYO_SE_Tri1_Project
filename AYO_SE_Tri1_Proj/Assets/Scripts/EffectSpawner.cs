using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EffectSpawner : MonoBehaviour
{
    public GameObject[] effectPrefabs; 
    private float spawnDelay = 1; //change both to 10 later, 1 for testing purposes
    private readonly float spawnInterval = 1.0f;
    private int size;
    private PlayerController playerControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEffects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        size = effectPrefabs.Length;
    }

    void SpawnEffects()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(-4.0f, 4.0f), 0);
        int index = Random.Range(0, size);

        if (!playerControllerScript.gameOver)
        {
             Instantiate(effectPrefabs[index], spawnLocation, Quaternion.Euler(0, 0, 0));
        }

    }
}
