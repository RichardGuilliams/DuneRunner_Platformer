using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyJumpAction : Action
{

    private enum ActionStates
    {
        Jump,
        InAir,
        Falling
    }
    private ActionStates state = ActionStates.Jump;
    public float fallSpeed;


 
    public override void ProcessAction(PlayerController player)
    {
        Debug.Log(state);
        switch (state)
        {
            case ActionStates.Jump:
                StartAction(player);
                ChangeActionState("InAir"); return;

            case ActionStates.InAir:
                InAir(player);
                return;

            case ActionStates.Falling:
                Fall(player);
                return;
        }
    }

    public override void StartAction(PlayerController player)
    {
        player.movement.lastYPostion = player.transform.position.y;
        player.movement.currentYPosition = player.transform.position.y;
        player.movement.velocity.y = 0;
        player.rb.velocity = player.movement.velocity;
        player.rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }

    public void InAir(PlayerController player)
    {
        player.movement.Move(player.rb);
        player.movement.ResetYPosition();
        CheckAction(player);
        player.movement.UpdatePosition();
    }

    public void Fall(PlayerController player)
    {
        player.movement.velocity.x = player.rb.velocity.x;
        CheckAction(player);
        if (player.rays.OnGround())
        {
            player.rb.AddForce(Vector2.right * player.movement.velocity.x);
            ResetState();
            player.stateManager.ChangeState("Stand");
            return;
        }
        if (player.input.IsAttemptingJump())
        {
            ResetState();
        }
        player.movement.gravityScale = fallSpeed;
        player.rb.AddForce(Vector2.up * speed * -player.movement.gravityScale, ForceMode2D.Impulse);
    }

    public override void CheckAction(PlayerController player)
    {
        if (player.stateManager.TryingToClimb(player))
        {
            ResetState();
            player.stateManager.ChangeState("Climb");
            return;
        }
        if (!player.input.JumpKeyHeld() || player.movement.lastYPostion > player.movement.currentYPosition)
        {
            ChangeActionState("Falling");
            return;
        }
    }

    public override void ChangeActionState(string newState)
    {
        switch (newState)
        {
            case "Jump":
                state = ActionStates.Jump;
                return;

            case "InAir":
                state = ActionStates.InAir;
                return;

            case "Falling":
                state = ActionStates.Falling;
                return;
        }
    }

    public override void ResetState()
    {
        ChangeActionState("Jump");
    }
}
