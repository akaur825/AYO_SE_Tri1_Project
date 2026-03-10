using UnityEngine;

public class SlowSpeedPlayerState : SpeedPlayerState
{
    public SlowSpeedPlayerState(PlayerController p)
    {
        player = p;
        speed = 3.0f;
    }

    public override SpeedPlayerState advanceState(Collider2D other)
    {
        throw new System.NotImplementedException();
    }
}
