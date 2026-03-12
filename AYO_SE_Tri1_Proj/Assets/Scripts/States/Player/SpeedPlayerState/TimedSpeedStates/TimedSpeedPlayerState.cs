using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimedSpeedPlayerState : SpeedPlayerState
{
    //private bool stillWaiting = true;
    private float effecCooldown;
    private float endTime;
    public TimedSpeedPlayerState(PlayerController p)
    {
        player = p;
        effecCooldown = Random.Range(5f, 8f);
        endTime = Time.time + effecCooldown; 
        //player.StartCoroutine(EffectCooldown(effecCooldown));
    }

    public override SpeedPlayerState advanceState(Collider2D other)
    {
        return this;
    }

    public override State CheckTransition()
    {
        //if (stillWaiting)
        if(Time.time < endTime)
        {
            return this;
        }
        else
        {
            return new NormalSpeedPlayerState(player);
        }
    }

    //private IEnumerator EffectCooldown(float effectCooldown)
    //{
    //    yield return new WaitForSeconds(effectCooldown);
    //    stillWaiting = false;
    //}
}
