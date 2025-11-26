using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private EnemyMovement enemyMovement;

    [SerializeField]
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       StartCoroutine(DestroyAfterTimer());
    }

    IEnumerator DestroyAfterTimer()
    { 
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = enemyMovement.MoveTowards(transform, player.transform, speed);
    }
}
