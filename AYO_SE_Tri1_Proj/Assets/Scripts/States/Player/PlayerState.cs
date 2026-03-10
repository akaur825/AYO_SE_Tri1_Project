using UnityEngine;

public abstract class PlayerState : State
{
    protected PlayerController player;
    public abstract string PlayerStateToString();
}
