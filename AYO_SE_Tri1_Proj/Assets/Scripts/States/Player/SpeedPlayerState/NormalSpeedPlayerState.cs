using UnityEngine;

public class NormalSpeedPlayerState : MonoBehaviour, SpeedPlayerState
{
    private PlayerController player;
    public NormalSpeedPlayerState(PlayerController p)
    {
        player = p;
    }
    public void advanceState()
    {
        throw new System.NotImplementedException();
    }

    public void returnState()
    {
        throw new System.NotImplementedException();
    }

    public void setState()
    {
        throw new System.NotImplementedException();
    }
}
