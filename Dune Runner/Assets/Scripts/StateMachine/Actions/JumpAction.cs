using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAction : Action
{
    public override void ProcessAction(PlayerController player)
    {
        StartAction(player);
        player.rb.AddForce(Vector2.up * player.stateManager.jumping.jump.speed, ForceMode2D.Impulse);
        currentState = ascendAction;
    }

    public override void StartAction(PlayerController player)
    {
        player.movement.lastYPostion = player.transform.position.y;
        player.movement.currentYPosition = player.transform.position.y;
        player.movement.velocity.y = 0;
        player.rb.velocity = player.movement.velocity;
    }

    public override void EndAction(PlayerController player)
    {
        player.movement.velocity.x = player.rb.velocity.x;
        if (player.stateManager.CanClimb(player))
        {
            currentState = endAction;
        }
        if (player.rays.OnGround())
        {
            player.rb.AddForce(Vector2.right * player.movement.velocity.x);
            currentState = endAction;
        }
        player.rb.AddForce(Vector2.up * player.stateManager.jumping.jump.speed * -player.movement.gravityScale, ForceMode2D.Impulse); throw new System.NotImplementedException();
    }

    public override void CheckAction(PlayerController player)
    {
        if (player.stateManager.CanClimb(player))
        {
            currentState = endAction;
        }
        if (!player.input.JumpKeyHeld() || player.movement.lastYPostion > player.movement.currentYPosition)
        {
            currentState = descendAction;
        }
    }

    public override bool CanPerformAction(PlayerController player)
    {
        throw new System.NotImplementedException();
    }

    public override bool IsPerformingAction(PlayerController player)
    {
        throw new System.NotImplementedException();
    }

    public override bool TryingPerformAction(PlayerController player)
    {
        throw new System.NotImplementedException();
    }

    public override void AscendAction(PlayerController player)
    {
        throw new System.NotImplementedException();
    }

    public override void MaintainAction(PlayerController player)
    {
        player.movement.ResetYPosition();
        player.movement.Move(player.rb);
        CheckAction(player);
        player.movement.UpdatePosition();
    }

    public override void DescendAction(PlayerController player)
    {
        throw new System.NotImplementedException();
    }
}
