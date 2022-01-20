using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : StateHandler
{
    public override void DoState(PlayerController player)
    {
        Debug.Log("Waiting");
        player.stateManager.playerState.currentState = player.stateManager.playerState.standing;
        return;
    }
}
