using UnityEngine;

public class FastEnemyFactory : EnemyFactory
{
    [SerializeField] private GameObject fastEnemy;

    public override IEnemy CreateEnemy(Vector3 position)
    {
        GameObject obj = Instantiate(fastEnemy, position, Quaternion.identity);
        IEnemy enemy = obj.GetComponent<IEnemy>();

        if (enemy != null)  // simple check
        {
            enemy.Initialize();
        }

        return enemy;
    }
}