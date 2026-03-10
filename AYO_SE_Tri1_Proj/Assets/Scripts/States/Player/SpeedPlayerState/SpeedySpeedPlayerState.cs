using Codice.CM.Common;
using UnityEngine;

public class SpeedySpeedPlayerState : SpeedPlayerState
{
    public SpeedySpeedPlayerState(PlayerController p)
    {
        player = p;
        speed = 7.0f;
    }

    public override SpeedPlayerState advanceState(Collider2D other)
    {
        throw new System.NotImplementedException();
    }
}
