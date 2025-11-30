using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float minSpawnTime;

    [SerializeField]
    private float maxSpawnTime;

    [SerializeField]
    private Transform spawnPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RandomlySpawnEnemies());
    }
    IEnumerator RandomlySpawnEnemies()
    {
        while (true)
        {
            float randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomSpawnTime);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
