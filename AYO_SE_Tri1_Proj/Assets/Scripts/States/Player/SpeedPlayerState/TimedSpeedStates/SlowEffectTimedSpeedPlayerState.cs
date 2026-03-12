using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffectTimedSpeedPlayerState : TimedSpeedPlayerState
{
    public SlowEffectTimedSpeedPlayerState(PlayerController p) : base(p)
    {
        speed = 3.0f;
    }
}