using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpeedPlayerState : SpeedPlayerState
{
    private bool stillWaiting = true;
    private float effecCooldown;
    public TimedSpeedPlayerState(PlayerController p)
    {
        player = p;
        effecCooldown = Random.Range(5f, 8f);
        player.StartCoroutine(EffectCooldown(effecCooldown));
    }

    public override SpeedPlayerState advanceState(Collider2D other)
    {
        return this;
    }

    protected override State CheckTransition()
    {
        if (stillWaiting)
        {
            return this;
        }
        else
        {
            NormalSpeedPlayerState normalState= new NormalSpeedPlayerState(player);
            player.advanceSpeedStateDirectly(normalState);
            return normalState;
        }
    }

    private IEnumerator EffectCooldown(float effectCooldown)
    {
        yield return new WaitForSeconds(effectCooldown);
        stillWaiting = false;
    }
}
