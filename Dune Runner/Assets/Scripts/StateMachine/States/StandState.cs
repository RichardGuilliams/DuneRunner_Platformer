using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandState : StateHandler
{
    #region StateAction
    public StandAction stand;

    public override void DoState(PlayerController player)
    {
        if (player.input.IsAttemptingWalk())
        {
            player.stateManager.playerState.currentState = player.stateManager.playerState.walking;
        }
        else if (player.input.IsAttemptingRun())
        {
            player.stateManager.playerState.currentState = player.stateManager.playerState.running;
        }
        else if (player.input.IsAttemptingJump())
        {
            player.stateManager.playerState.currentState = player.stateManager.playerState.jumping;
        }
        else if (player.input.IsAttemptingClimb())
        {
            player.stateManager.playerState.currentState = player.stateManager.playerState.climbing;
        }
        else
        {
            player.stateManager.playerState.currentState = player.stateManager.playerState.standing;
        }
    }
    #endregion
}
