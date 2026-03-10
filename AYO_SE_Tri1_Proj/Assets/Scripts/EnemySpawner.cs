using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public BasicEnemyFactory basicFactory;  
    public FastEnemyFactory fastFactory;

    public float safeDistanceFromPlayer = 3f;
    public float range = 7.5f;

    public float minSpawnTime = 2f;
    public float maxSpawnTime = 5f;

    [SerializeField]
    private Transform player;

    private ISpecialEffects specialEffects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        specialEffects = GameObject.FindAnyObjectByType<SpecialEffectProxy>();

        StartCoroutine(SpawnLoop());
    }
    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            // Spawn 2 Basic + 1 Fast
            SpawnEnemy(basicFactory);
            SpawnEnemy(basicFactory);
            SpawnEnemy(fastFactory);
        }
    }

    void SpawnEnemy(EnemyFactory factory)
    {
        Vector3 spawnPos = GetSpawnPosition();

        IEnemy enemy = factory.CreateEnemy(spawnPos);

        if (specialEffects != null)
        {
            specialEffects.PlayEnemySpawnEffect(spawnPos);
        }

    }

    Vector3 GetSpawnPosition()
    {
        Vector3 position = Vector3.zero;
        int attempts = 0;

        while (true)
        {
            float x = Random.Range(-range, range);
            float y = Random.Range(-range, range);
            position = new Vector3(x, y, 0);
            attempts++;

            if (player == null || Vector3.Distance(position, player.position) >= safeDistanceFromPlayer)
            {
                break;
            }

            // Stop trying after 50 attempts to prevent infinite loops
            if (attempts > 50)
            {
                break;
            }
        }

        return position;
    }
}
