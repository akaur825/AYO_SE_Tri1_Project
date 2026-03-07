using UnityEngine;

public class SpecialEffectProxy : MonoBehaviour, ISpecialEffects
{
    [SerializeField] private SpecialEffect effect;

    public void PlayEnemySpawnEffect(Vector3 pos)
    {
        effect.PlayEnemySpawnEffect(pos);
    }
    public void PlayEnemyDeathEffect(Vector3 pos)
    {
        effect.PlayEnemyDeathEffect(pos);
    }
    public void PlayPlayerDeathEffect(Vector3 pos)
    {
        effect.PlayPlayerDeathEffect(pos);
    }
}


