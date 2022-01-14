using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : StateHandler
{
    #region StateAction
    public RunAction run;
    #endregion

    #region States
    public enum SubState
    {
        None,
        Run,
        Jump,
        Climb,
        Walk,
        Exhausted,
        Hurt
    }

    public SubState subState;
    #endregion

    #region Handle State
    public void DoState(PlayerController player)
    {
        switch (subState)
        {
            case SubState.Run:
                Run(player);
                player.stateManager.playerState.currentState = player.stateManager.playerState.running;
                break;

            case SubState.Jump:
                player.stateManager.playerState.currentState = player.stateManager.playerState.jumping;
                break;

            case SubState.Climb:
                player.stateManager.playerState.currentState = player.stateManager.playerState.climbing;
                break;

            case SubState.Walk:
                player.stateManager.playerState.currentState = player.stateManager.playerState.walking;
                break;

            case SubState.Exhausted:
                player.stateManager.playerState.currentState = player.stateManager.playerState.exhausted;
                break;

            case SubState.Hurt:
                subState = SubState.Run;
                player.stateManager.playerState.currentState = player.stateManager.playerState.hurt;
                break;

            default:
                subState = SubState.Run;
                player.stateManager.playerState.currentState = player.stateManager.playerState.running;
                break;
        }
    }
    public void Run(PlayerController player)
    {
        
        if (player.stateManager.ExhaustedState())
        {
            subState = SubState.Exhausted;
            player.stateManager.playerState.currentState = player.stateManager.playerState.running;
            return;
        }
        if (player.stateManager.HurtState())
        {
            subState = SubState.Hurt;
            return;
        }
        if (player.input.IsAttemptingJump() &&  player.rays.OnGround())
        {
            subState = SubState.Jump;
            return;
        }
        if (player.input.IsAttemptingClimb())
        {
            subState = SubState.Climb;
            return;
        }
        // Checks if player is moving but not holding the runKey, if true we change to Walking State
        else if (player.input.IsAttemptingWalk())
        {
            player.movement.SetSpeed(player.stateManager.walking.walk.speed);
            subState = SubState.Walk;
            return;
        }
        player.movement.SetSpeed(player.stateManager.running.run.speed);
        player.movement.Move(player.rb);
        return;

    }
    #endregion
}
