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
        if (player.input.ClimbKeyHeld() && !player.stateManager.ExhaustedState())
        {
            return true;
        }
        return false;
    }

    public override void ProcessAction(PlayerController player)
    {
        if (!player.rays.OnWall())
        {
            // Changing subState of the jump state to falling so player falls rather than jumps upon entering the state
            player.stateManager.jumping.subState = player.stateManager.jumping.falling;
            player.stateManager.playerState.currentState = player.stateManager.playerState.jumping;
        }
        if (player.rays.OnLedge())
        {
            player.stateManager.climbing.subState = player.stateManager.climbing.hanging;
            currentState = player.stateManager.stateHandlerName;
            return;
        }
        if (player.input.JumpKeyHeld())
        {
            player.rb.gravityScale = player.physics.gravityScale;
            player.stateManager.climbing.subState = player.stateManager.climbing.jumping;
            return;
        }
        if (!IsPerformingAction(player))
        {
            player.stateManager.climbing.subState = player.stateManager.climbing.hanging;
            return;
        }
        if (IsPerformingAction(player) && player.rays.ChestCollision())
        {    
            player.movement.velocity.y = player.stateManager.climbing.climb.speed;
            player.rb.velocity = player.movement.velocity;
            player.stateManager.climbing.subState = player.stateManager.climbing.climbing;
            return;
        }
    }

    public override void MaintainAction(PlayerController player)
    {
        player.rb.gravityScale = player.physics.gravityScale;
        if (!player.rays.OnWall())
        {
            player.stateManager.jumping.subState = JumpState.SubState.Falling;
            player.stateManager.climbing.subState = player.stateManager.climbing.jumping;
            return;
        }
        if (player.input.IsAttemptingClimb() && !player.rays.OnLedge() && player.rays.OnWall())
        {
            // perfect example of why we need to seperate states, substates, and actions with better naming. To Avoid duplicate names.
            currentState = "climbing";
            return;
        }
        if (player.input.JumpKeyHeld())
        {
            player.rb.gravityScale = player.physics.gravityScale;
            currentState = "jumping";
            return;
        }
        player.movement.velocity.y = 0;
        player.movement.velocity.x = 0;
        player.rb.velocity = player.movement.velocity;
        player.rb.gravityScale = 0;
        return;
    }

    public override void DescendAction(PlayerController player)
    {
        currentState = "hanging";
        return;
    }

}
