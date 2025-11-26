using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private EnemyMovement enemyMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = enemyMovement.MoveTowards(transform, player.transform, speed);
    }
}
