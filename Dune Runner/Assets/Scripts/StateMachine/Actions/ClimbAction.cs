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
        Debug.Log("ProcessAction");
        if (!player.rays.OnWall())
        {
            // Changing subState of the jump state to falling so player falls rather than jumps upon entering the state
            player.stateManager.GetState("Jump").currentState = endAction;
            player.stateManager.ChangeState("Jump");
        }
        if (player.rays.OnLedge())
        {
            player.stateManager.GetState("Climb").currentState = maintainAction;
            player.stateManager.ChangeState("Hang");
            return;
        }
        if (player.input.JumpKeyHeld())
        {
            player.rb.gravityScale = player.physics.gravityScale;
            player.stateManager.GetState("Climb").currentState = endAction;
            return;
        }
        if (!IsPerformingAction(player))
        {
            player.stateManager.GetState("Climb").currentState = maintainAction;
            return;
        }
        if (IsPerformingAction(player) && player.rays.ChestCollision())
        {
            StartAction(player);
            return;
        }
    }

    public override void StartAction(PlayerController player)
    {
        Debug.Log("StartAction");
        player.movement.velocity.y = speed;
        player.rb.velocity = player.movement.velocity;
        currentState = maintainAction;
    }

    public override void MaintainAction(PlayerController player)
    {
        player.rb.gravityScale = player.physics.gravityScale;
        if (!player.rays.OnWall())
        {
            player.stateManager.GetState("Jump").currentState = player.stateManager.GetAction("Jump").descendAction;
            player.stateManager.GetState("Climb").currentState = player.stateManager.GetAction("Climb").ascendAction;
            return;
        }
        if (player.input.IsAttemptingClimb() && !player.rays.OnLedge() && player.rays.OnWall())
        {
            currentState = startAction;
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
