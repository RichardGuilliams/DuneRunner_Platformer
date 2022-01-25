using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAction : Action
{
    public override void ProcessAction(PlayerController player)
    {
        if (player.input.IsAttemptingJump() && player.rays.OnGround())
        {
            player.stateManager.ChangeState("Jump");
            return;
        }
        if (player.stateManager.TryingToClimb(player))
        {
            player.stateManager.ChangeState("Climb");
            return;
        }
        // Checks if player is moving but not holding the runKey, if true we change to Walking State
        else if (player.input.IsAttemptingWalk())
        {
            player.movement.SetSpeed(player.stateManager.GetAction("Walk").speed);
            player.stateManager.ChangeState("Walk");
            return;
        }
        player.movement.SetSpeed(speed);
        player.movement.Move(player.rb);
        return;
    }

}
