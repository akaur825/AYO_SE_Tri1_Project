using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour, IEnemy
{
    [SerializeField]
    private float minSpeed;

    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private EnemyMovement enemyMovement;

    [SerializeField]
    private float timer;

    [SerializeField]
    private GameObject smokeEffect;

    private float speed;
    private GameObject player;
    private ISpecialEffects specialEffects;


    public void Initialize()
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
        if ( player != null && enemyMovement != null)
        {
            transform.position = enemyMovement.MoveTowards(transform, player.transform, speed);
        }
    }
}


