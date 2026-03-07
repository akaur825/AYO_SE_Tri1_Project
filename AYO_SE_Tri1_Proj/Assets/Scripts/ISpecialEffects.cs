using UnityEngine;

public interface ISpecialEffects
{
    void PlayEnemySpawnEffect(Vector3 pos);
    void PlayEnemyDeathEffect(Vector3 pos);
    void PlayPlayerDeathEffect(Vector3 pos);
}

