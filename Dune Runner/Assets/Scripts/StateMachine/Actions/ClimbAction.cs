using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbAction : Action
{
    public float hangingCost;
    public float wallJumpCost;
    [HideInInspector]
    public bool canClimb;
    [HideInInspector]
    public float climbDir;
    [HideInInspector]
    public Vector2 climbCollision;

    public override bool IsPerformingAction(PlayerController player)
    {
        if (player.input.ClimbKeyHeld())
        {
            return true;
        }
        return false;
    }

    public override void ProcessAction(PlayerController player)
    {
        if (!player.rays.OnWall())
        {
            player.stateManager.GetAction("Jump").ChangeActionState("Falling");
            player.stateManager.ChangeState("Jump");
            return;
        }
        if (player.input.JumpKeyHeld())
        {
            player.rb.gravityScale = player.physics.gravityScale;
            player.stateManager.GetState("Jump").action.currentState = processAction;
            player.stateManager.ChangeState("Jump");
            return;
        }
        if (player.rays.OnLedge() || !IsPerformingAction(player))
        {
            Hang(player);
            return;
        }
        if (IsPerformingAction(player) && player.rays.ChestCollision())
        {
            Climb(player);
            return;
        }
    }

    public override void StartAction(PlayerController player)
    {
        player.movement.velocity.y = speed;
        player.rb.velocity = player.movement.velocity;
        currentState = maintainAction;
    }

    public void Climb(PlayerController player)
    {
        player.movement.velocity.y = speed;
        player.rb.velocity = player.movement.velocity;
    }

    public void Hang(PlayerController player)
    {
        player.movement.velocity.y = 0;
        player.movement.velocity.x = 0;
        player.rb.velocity = player.movement.velocity;
        player.rb.gravityScale = 0;
        return;
    }

}
