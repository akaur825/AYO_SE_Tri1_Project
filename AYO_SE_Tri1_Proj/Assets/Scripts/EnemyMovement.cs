using UnityEngine;
abstract class EnemyMovement : ScriptableObject
{

    public abstract Vector2 GetNextPosition(Vector2 enemyPos, Vector2 playerPos, float speed);
    
}
