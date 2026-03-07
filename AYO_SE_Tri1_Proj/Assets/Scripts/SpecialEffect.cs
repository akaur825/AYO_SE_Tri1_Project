using UnityEngine;

public class SpecialEffect : MonoBehaviour, ISpecialEffects
{
    [SerializeField]
    private GameObject spawnEffect;
    [SerializeField]
    private GameObject deathEffect;
    [SerializeField]
    private GameObject playerDeathEffect;

    public void PlayEnemySpawnEffect(Vector3 pos)
    {
        PlayEffect(spawnEffect, pos);
    }
    public void PlayEnemyDeathEffect(Vector3 pos)
    {
        PlayEffect(deathEffect, pos);
    }
    public void PlayPlayerDeathEffect(Vector3 pos)
    {
        PlayEffect(playerDeathEffect, pos);
    }

    private void PlayEffect(GameObject effect, Vector3 pos)
    {
        if (effect == null) return;

        Vector3 spawnPos = new Vector3(pos.x, pos.y, -1f);
        GameObject effectInstance = Instantiate(effect, spawnPos, Quaternion.identity);

        var renderer = effectInstance.GetComponent<ParticleSystemRenderer>();
        if (renderer != null) { renderer.sortingOrder = 10; }

        ParticleSystem particleSystem = effectInstance.GetComponent<ParticleSystem>();
        if (particleSystem != null) { particleSystem.Play(); }

        Destroy(effectInstance, 3.0f);
    }
}


