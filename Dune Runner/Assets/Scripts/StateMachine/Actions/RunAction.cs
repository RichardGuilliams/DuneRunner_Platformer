using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAction : Action
{
    public override void ProcessAction(PlayerController player)
    {
        if (player.input.IsAttemptingJump() && player.rays.OnGround())
        {
            player.stateManager.stateHandlerName = currentState = "Jump";
            return;
        }
        if (player.input.IsAttemptingClimb())
        {
            player.stateManager.stateHandlerName = currentState = "Climb";
            return;
        }
        // Checks if player is moving but not holding the runKey, if true we change to Walking State
        else if (player.input.IsAttemptingWalk())
        {
            player.movement.SetSpeed(player.stateManager.walking.walk.speed);
            player.stateManager.stateHandlerName = currentState = "Walk";
            return;
        }
        player.movement.SetSpeed(player.stateManager.running.run.speed);
        player.movement.Move(player.rb);
        return;
    }

}
