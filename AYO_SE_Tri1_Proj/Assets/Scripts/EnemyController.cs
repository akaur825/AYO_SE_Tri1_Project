using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private EnemyMovement enemyMovement;

    [SerializeField]
    private float timer;

    [SerializeField]
    private float minSpawnTime;

    [SerializeField]
    private float maxSpawnTime;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private GameObject smokeEffect;

    public bool gameEnded = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestroyAfterTimer());
        StartCoroutine(RandomlySpawnEnemies());
    }

    IEnumerator DestroyAfterTimer()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    IEnumerator RandomlySpawnEnemies()
    {
        while (gameEnded != true)
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

    private void OnDisable()
    {
        if (gameObject.scene.isLoaded)
        {
            GameObject smoke = Instantiate(smokeEffect, transform.position, transform.rotation);
            ParticleSystem smokeParticleSystem = smoke.GetComponent<ParticleSystem>();
            smokeParticleSystem.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = enemyMovement.MoveTowards(transform, player.transform, speed);
    }
}


