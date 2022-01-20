using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : StateHandler
{
    #region StateAction
    public RunAction run;
    #endregion

    public override void DoState(PlayerController player)
    {
        switch (subState)
        {
            case SubState.Run:
                Run(player);
                player.stateManager.playerState.currentState = player.stateManager.playerState.running;
                break;

            case SubState.Jump:
                player.stateManager.playerState.currentState = player.stateManager.playerState.jumping;
                break;

            case SubState.Climb:
                player.stateManager.playerState.currentState = player.stateManager.playerState.climbing;
                break;

            case SubState.Walk:
                player.stateManager.playerState.currentState = player.stateManager.playerState.walking;
                break;
        }
    }
}
