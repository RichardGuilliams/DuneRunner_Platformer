using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : StateHandler
{
    #region StateAction
    public ClimbAction climb;
    #endregion

    #region States
    public enum SubState
    {
        Climbing,
        Hanging,
        OnLedge,
        OnCeiling,
        Jumping,
        WallJump
          
    }

    public SubState climbing = SubState.Climbing;
    public SubState hanging = SubState.Hanging;
    public SubState OnLedge = SubState.OnCeiling;
    public SubState jumping = SubState.Jumping;
    public SubState wallJump = SubState.WallJump;

    public SubState subState;
    #endregion

    #region Handle State
    public void DoState(PlayerController player)
    {
        switch (subState)
        {
            case SubState.Climbing:
                climb.ProcessClimb(player);
                player.stateManager.playerState.currentState = player.stateManager.playerState.climbing;
                break;
            case SubState.Hanging:
                climb.Hang(player);
                player.stateManager.playerState.currentState = player.stateManager.playerState.climbing;
                break;

            case SubState.OnLedge:
                climb.Ledge(player);
                player.stateManager.playerState.currentState = player.stateManager.playerState.climbing;
                break;

            case SubState.OnCeiling:
                climb.Ceiling(player);
                player.stateManager.playerState.currentState = player.stateManager.playerState.climbing;
                break;

            case SubState.Jumping:
                subState = SubState.Climbing;
                player.stateManager.playerState.currentState = player.stateManager.playerState.jumping;
                break;

            default:
                subState = SubState.Climbing;
                player.stateManager.playerState.currentState = player.stateManager.playerState.climbing;
                break;
        }
    }
    #endregion
}
