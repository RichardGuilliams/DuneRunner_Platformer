using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : StateHandler
{
    #region StateAction
    public WalkAction walk;
    #endregion

    #region Handle State
    public void DoState(PlayerController player)
    {
        if (player.input.IsAttemptingJump()) 
        {
            player.stateManager.jumping.subState = JumpState.SubState.Jumping;
            player.stateManager.playerState.currentState = player.stateManager.playerState.jumping;
            return;
        } 
        if (!player.rays.OnGround())
        {
            player.stateManager.jumping.subState = JumpState.SubState.Falling;
            player.stateManager.playerState.currentState = player.stateManager.playerState.jumping;
            return;
        }
        if (player.input.IsAttemptingClimb()) 
        {
            player.stateManager.playerState.currentState = player.stateManager.playerState.climbing;
            return;
        }
        if (player.input.IsAttemptingRun()) 
        {
            player.stateManager.playerState.currentState = player.stateManager.playerState.running;
            return;
        }            
        if (player.input.IsAttemptingWalk()) 
        {
            walk.ProcessWalk(player);
            player.stateManager.playerState.currentState = player.stateManager.playerState.walking;
            return;
        }
        player.stateManager.playerState.currentState = player.stateManager.playerState.standing;
    }
    #endregion
}
