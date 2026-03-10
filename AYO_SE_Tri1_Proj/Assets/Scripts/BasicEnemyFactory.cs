using UnityEngine;

public class BasicEnemyFactory : EnemyFactory
{
    [SerializeField] private GameObject basicEnemy;

    public override IEnemy CreateEnemy(Vector3 position)
    {
        GameObject obj = Instantiate(basicEnemy, position, Quaternion.identity);
        IEnemy enemy = obj.GetComponent<IEnemy>();

        if (enemy != null)
        {
            enemy.Initialize();
        }

        return enemy;
    }
}