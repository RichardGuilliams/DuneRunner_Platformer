using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustedState : StateHandler
{
    public override void DoState(PlayerController player)
    {
        Debug.Log("Exhausted");
        player.stateManager.playerState.currentState = player.stateManager.playerState.exhausted;
    }
}
