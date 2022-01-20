using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : StateHandler
{
    #region StateAction
    public JumpAction jump;
    #endregion

    #region State Booleans
    public bool StateActive(PlayerController player)
    {
        if (player.stateManager.playerState.currentState == player.stateManager.playerState.jumping) return true;
        return false;
    }
    #endregion

    #region Handle State
    public override void DoState(PlayerController player)
    {
        switch (subState)
        {
            case SubState.Jumped:
                jump.AirTime(player);
                player.stateManager.playerState.currentState = player.stateManager.playerState.jumping;
                break;

            case SubState.Falling:
                jump.Fall(player);
                player.stateManager.playerState.currentState = player.stateManager.playerState.jumping;
                break;


            case SubState.JumpComplete:
                subState = SubState.None;
                player.stateManager.playerState.currentState = player.stateManager.playerState.standing;
                break;


            case SubState.Climbing:
                player.stateManager.playerState.currentState = player.stateManager.playerState.climbing;
                break;


            case SubState.Running:
                player.stateManager.playerState.currentState = player.stateManager.playerState.running;
                break;


            case SubState.Walking:
                player.stateManager.playerState.currentState = player.stateManager.playerState.walking;
                break;


            case SubState.Standing:
                player.stateManager.playerState.currentState = player.stateManager.playerState.standing;
                break;

            default:
                jump.ProcessJump(player);
                player.stateManager.playerState.currentState = player.stateManager.playerState.jumping;
                break;

        }
    }
    #endregion
}
