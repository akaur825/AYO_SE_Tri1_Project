using UnityEngine;
public abstract class EnemyMovement : ScriptableObject
{
    public abstract Vector2 MoveTowards(Transform enemy, Transform player, float speed);
}
