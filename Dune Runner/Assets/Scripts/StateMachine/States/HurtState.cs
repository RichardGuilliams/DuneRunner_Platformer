using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : StateHandler
{
    public override void DoState(PlayerController player)
    {
        Debug.Log("Hurt");
        player.stateManager.playerState.currentState = player.stateManager.playerState.hurt;
    }
}

