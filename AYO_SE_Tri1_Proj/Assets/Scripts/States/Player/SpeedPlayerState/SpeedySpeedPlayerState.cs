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

    /*
         IEnumerator EffectCooldown()
    {
        yield return new WaitForSeconds(7);
        hasEffect = false;
        speed = speedNormal;
        SetState(new NormalSpeedPlayerState(this));
    }
     */
}
