using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedyEffectTimedSpeedPlayerState : TimedSpeedPlayerState
{
    public SpeedyEffectTimedSpeedPlayerState(PlayerController p) : base(p)
    {
        speed = 7.0f;
    }
}
