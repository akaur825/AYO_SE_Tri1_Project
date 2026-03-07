using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float minSpeed;

    [SerializeField]
    private float maxSpeed;

    private GameObject player;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private EnemyMovement enemyMovement;

    [SerializeField]
    private float timer;

    [SerializeField]
    private GameObject smokeEffect;

    private float speed;

    private ISpecialEffects specialEffects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        speed = Random.Range(minSpeed, maxSpeed);
        specialEffects = GameObject.FindAnyObjectByType<SpecialEffectProxy>();
        StartCoroutine(DestroyAfterTimer());
    }

    IEnumerator DestroyAfterTimer()
    {
        yield return new WaitForSeconds(timer);
        if (specialEffects != null)
        {
            specialEffects.PlayEnemyDeathEffect(transform.position);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null && player != null)
        {
            enemy.transform.position = enemyMovement.MoveTowards(transform, player.transform, speed);
        }
    }
}


