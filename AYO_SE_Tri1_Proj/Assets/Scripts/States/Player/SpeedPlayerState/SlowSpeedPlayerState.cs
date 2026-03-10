using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpeedPlayerState : SpeedPlayerState
{
    private bool stillWaiting;
    private float effecCooldown;
    public SlowSpeedPlayerState(PlayerController p)
    {
        player = p;
        speed = 3.0f;
        stillWaiting = true;
        effecCooldown = Random.Range(5f, 8f); 
        player.StartCoroutine(EffectCooldown(effecCooldown));

    }
    public override State Act()
    {
        if (stillWaiting)
        {
            return this;
        }
        else
        {
            player.advanceSpeedState(new NormalSpeedPlayerState(player), null);
            return new NormalSpeedPlayerState(player);
        }
    }

    public override SpeedPlayerState advanceState(Collider2D other)
    {
        return this;
    }

    private IEnumerator EffectCooldown(float effectCooldown)
    {
        yield return new WaitForSeconds(effectCooldown);
        stillWaiting = false;
    }
}
