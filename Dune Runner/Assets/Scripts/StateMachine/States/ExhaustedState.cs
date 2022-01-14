using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustedState : StateHandler
{
    #region Handle State
    public void DoState(PlayerController player)
    {
        Debug.Log("Exhausted");
        player.stateManager.playerState.currentState = player.stateManager.playerState.exhausted;
    }

    public void ExhaustedSpeed(PlayerController player)
    {
        if (player.stateManager.ExhaustedState() || player.stateManager.HurtState())
        {
            player.movement.speed = player.stateManager.walking.walk.speed / 2;
        }
    }
    #endregion
}
