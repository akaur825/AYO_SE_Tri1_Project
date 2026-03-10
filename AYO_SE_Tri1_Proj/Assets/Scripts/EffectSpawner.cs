using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EffectSpawner : MonoBehaviour
{
    public GameObject[] effectPrefabs; 
    private float spawnDelay = 0;
    private readonly float spawnInterval = 3.75f;
    private int size;
    private PlayerController playerControllerScript;
    private float range = 7.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEffects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        size = effectPrefabs.Length;
    }

    void SpawnEffects()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(-range, range), Random.Range(-range, range), 0);
        int index = Random.Range(0, size);

        if (!playerControllerScript.gameOver)
        {
             Instantiate(effectPrefabs[index], spawnLocation, Quaternion.Euler(0, 0, 0));
        }

    }
}
