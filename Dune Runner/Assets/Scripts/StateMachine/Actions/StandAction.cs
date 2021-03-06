using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandAction : Action
{
    public override void ProcessAction(PlayerController player)
    {
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
        else if (player.stateManager.TryingToClimb(player))
        {
            player.stateManager.ChangeState("Climb");
        }
    }
}
