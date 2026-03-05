using UnityEngine;

public interface SpeedPlayerState : PlayerState
{
    public void advanceState();
    public void setState(); //in set state, call PlayerController.setState based on fruit effect
}