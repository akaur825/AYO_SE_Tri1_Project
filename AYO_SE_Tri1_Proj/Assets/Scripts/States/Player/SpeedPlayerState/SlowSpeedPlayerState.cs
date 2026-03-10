using UnityEngine;

public class SlowSpeedPlayerState : SpeedPlayerState
{
    public SlowSpeedPlayerState(PlayerController p)
    {
        player = p;
        speed = 3.0f;
    }
    public override State Act()
    {
        throw new System.NotImplementedException();
    }

    public override SpeedPlayerState advanceState(Collider2D other)
    {
        throw new System.NotImplementedException();
    }
}
