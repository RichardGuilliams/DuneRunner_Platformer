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
        Debug.Log("We are in run state");
        switch (currentState)
        {
            case "ActionRun":
                action.StartAction(player);
                player.stateManager.playerState.currentState = player.stateManager.playerState.running;
                break;

            case "ActionJump":
                player.stateManager.playerState.currentState = player.stateManager.playerState.jumping;
                break;

            case "ActionClimb":
                player.stateManager.playerState.currentState = player.stateManager.playerState.climbing;
                break;

            case "ActionWalk":
                player.stateManager.playerState.currentState = player.stateManager.playerState.walking;
                break;
        }
    }
}
