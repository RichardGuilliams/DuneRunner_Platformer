using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAction : Action
{
    public float gravityScale;
    [HideInInspector]
    public float currentYPosition;
    [HideInInspector]
    public float lastYPostion;

    public void UpdatePosition()
    {
        lastYPostion = currentYPosition;
    }

    public void ResetYPosition()
    {
        currentYPosition = transform.position.y;
    }


    public void JumpStart(PlayerController player)
    {
        player.stateManager.jumping.jump.lastYPostion = player.transform.position.y;
        player.stateManager.jumping.jump.currentYPosition = player.transform.position.y;
        player.movement.velocity.y = 0;
        player.rb.velocity = player.movement.velocity;
    }

    public void ProcessJump(PlayerController player)
    {
        JumpStart(player);
        player.rb.AddForce(Vector2.up * player.stateManager.jumping.jump.speed, ForceMode2D.Impulse);
        player.stateManager.jumping.subState = player.stateManager.jumping.jumped;
    }

    public void CheckActions(PlayerController player)
    {
        if (player.stateManager.CanClimb(player))
        {
            player.stateManager.jumping.subState = player.stateManager.jumping.jumpComplete;
        }
        if (!player.input.JumpKeyHeld() || player.stateManager.jumping.jump.lastYPostion > player.stateManager.jumping.jump.currentYPosition)
        {
            player.stateManager.jumping.subState = player.stateManager.jumping.falling;
        }
    }

    public void AirTime(PlayerController player)
    {
        player.stateManager.jumping.jump.ResetYPosition();
        player.movement.Move(player.rb);
        CheckActions(player);
        player.stateManager.jumping.jump.UpdatePosition();

    }

    public void Fall(PlayerController player)
    {
        player.movement.velocity.x = player.rb.velocity.x;
        if (player.stateManager.CanClimb(player))
        {
            player.stateManager.jumping.subState = player.stateManager.jumping.jumpComplete;
        }
        if (player.rays.OnGround())
        {
            player.rb.AddForce(Vector2.right * player.movement.velocity.x);
            player.stateManager.jumping.subState = player.stateManager.jumping.jumpComplete;
        }
        player.rb.AddForce(Vector2.up * player.stateManager.jumping.jump.speed * -player.stateManager.jumping.jump.gravityScale, ForceMode2D.Impulse);
    }

}
