using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAction : Action
{
    public override void ProcessAction(PlayerController player)
    {
        if (player.input.IsAttemptingJump())
        {
            player.stateManager.ChangeState("Jump");
            return;
        }
        if (!player.rays.OnGround())
        {
            player.stateManager.GetAction("Jump").ChangeActionState("Falling");
            player.stateManager.ChangeState("Jump");
            return;
        }
        if (player.stateManager.TryingToClimb(player))
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
            return;
        }
        player.stateManager.ChangeState("Stand");
    }

    public override void StartAction(PlayerController player)
    {
        player.movement.SetSpeed(speed);
        if (player.stateManager.CanMove())
        {
            player.movement.Move(player.rb);
        }
        return;
    }
}
