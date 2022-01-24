using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : StateHandler
{
    #region StateAction
    public WalkAction walk;
    public override void DoState(PlayerController player)
    {
        if (player.input.IsAttemptingJump()) 
        {
            player.stateManager.ChangeState("Jump");
            return;
        } 
        if (!player.rays.OnGround())
        {
            player.stateManager.GetState("Jump").currentState = action.descendAction;
            player.stateManager.ChangeState("Jump");
            return;
        }
        if (player.input.IsAttemptingClimb()) 
        {
            player.stateManager.ChangeState("Climb");
            return;
        }
        if (player.input.IsAttemptingRun()) 
        {
            player.stateManager.ChangeState("Run");
            return;
        }            
        if (player.input.IsAttemptingWalk()) 
        {
            player.stateManager.ChangeState("Walk");
            walk.ProcessAction(player);
            return;
        }
        player.stateManager.ChangeState("Stand");
    }
    #endregion
}
