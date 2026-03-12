using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using NUnit.Framework;

public class NormalSpeedPlayerState : SpeedPlayerState
{
    public NormalSpeedPlayerState(PlayerController p)
    {
        player = p;
        speed = 5.0f;
    }

    public override SpeedPlayerState advanceState(Collider2D other)
    {
        if (other.gameObject.CompareTag("AppleDebuff"))
        {
            PerformDestroy(other.gameObject);
            return new SlowEffectTimedSpeedPlayerState(player);
        }

        else if (other.gameObject.CompareTag("LemonBuff"))
        {
            PerformDestroy(other.gameObject);
            return new SpeedyEffectTimedSpeedPlayerState(player);
        }
        else return this;
    }

    public override State CheckTransition()
    {
        return this;
    }
}
