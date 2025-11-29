using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Movement / Chase")]
    public class EnemyChase : EnemyMovement
    {
        public override Vector2 MoveTowards(Transform enemy, Transform player, float speed)
        {
            return Vector2.MoveTowards(enemy.position, player.position, speed * Time.deltaTime);
        }
    }