using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandState : StateHandler
{
    #region StateAction
    public StandAction stand;
    public override void DoState(PlayerController player)
    {
        Debug.Log("We are in stand state");
        if (player.input.IsAttemptingWalk())
        {
            player.stateManager.ChangeState("Walk");
        }
        else if (player.input.IsAttemptingRun())
        {
            player.stateManager.ChangeState("Run");
        }
        else if (player.input.IsAttemptingJump())
        {
            player.stateManager.ChangeState("Jump");
        }
        else if (player.input.IsAttemptingClimb())
        {
            player.stateManager.ChangeState("Climb");
        }
    }
    #endregion
}
