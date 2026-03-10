using UnityEngine;

public abstract class SpeedPlayerState : PlayerState
{
    [SerializeField]
    protected float speed;
    public abstract SpeedPlayerState advanceState(Collider2D other); //in set state, call PlayerController.setState based on fruit effect

    public override string PlayerStateToString()
    {
        return "The current Player Speed State is " + this.GetType();
    }
}