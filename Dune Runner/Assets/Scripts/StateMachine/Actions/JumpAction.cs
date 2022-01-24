using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAction : Action
{
    public float fallSpeed;
    public override void ProcessAction(PlayerController player)
    {
        StartAction(player);
        player.rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        currentState = ascendAction;
    }

    public override void StartAction(PlayerController player)
    {
        player.movement.lastYPostion = player.transform.position.y;
        player.movement.currentYPosition = player.transform.position.y;
        player.movement.velocity.y = 0;
        player.rb.velocity = player.movement.velocity;
    }

    public override void AscendAction(PlayerController player)
    {
        MaintainAction(player);

    }

    public override void CheckAction(PlayerController player)
    {
        if (player.stateManager.CanClimb(player))
        {
            player.stateManager.ChangeState("Climb");
            currentState = ascendAction;
        }
        if (!player.input.JumpKeyHeld() || player.movement.lastYPostion > player.movement.currentYPosition)
        {
            Debug.Log("Fall");
            currentState = descendAction;
        }
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
        Debug.Log("trying to fall");
        player.movement.velocity.x = player.rb.velocity.x;
        if (player.stateManager.CanClimb(player))
        {
            currentState = processAction;
            player.stateManager.ChangeState("Climb");
        }
        if (player.rays.OnGround())
        {
            Debug.Log("Trying To Stand");
            currentState = processAction;
            player.rb.AddForce(Vector2.right * player.movement.velocity.x);
            player.stateManager.ChangeState("Stand");
        }
        player.movement.gravityScale = fallSpeed;
        player.rb.AddForce(Vector2.up * speed * -player.movement.gravityScale, ForceMode2D.Impulse);
    }
}
