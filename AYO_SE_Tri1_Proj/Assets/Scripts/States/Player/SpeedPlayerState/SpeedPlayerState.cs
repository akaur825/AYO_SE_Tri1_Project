using UnityEngine;

public abstract class SpeedPlayerState : PlayerState
{
    [SerializeField]
    protected float speed;
    protected bool isEffectExpired = false;
   
    public override State Act()
    {
        return CheckTransition();
    }
    public abstract State CheckTransition();
    public abstract SpeedPlayerState advanceState(Collider2D other); //in set state, call PlayerController.setState based on fruit effect

    public float getSpeed()
    {
        return speed;
    }

    public override string PlayerStateToString()
    {
        return "" + this.GetType();
    }
}