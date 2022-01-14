using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    #region States
    [HideInInspector]
    public string stateHandlerName;
    public ArrayList states;
    public StandState standing;
    public WalkState walking;
    public RunState running;
    public JumpState jumping;
    public ClimbState climbing;
    public HurtState hurt;
    public ExhaustedState exhausted;
    public PlayerStates playerState;

    #endregion

    public void Start()
    {
        standing = standing.GetComponent<StandState>();
        walking = walking.GetComponent<WalkState>();
        running = running.GetComponent<RunState>();
        jumping = jumping.GetComponent<JumpState>();
        climbing = climbing.GetComponent<ClimbState>();
        hurt = hurt.GetComponent<HurtState>();
        exhausted = exhausted.GetComponent<ExhaustedState>();
        playerState = playerState.GetComponent<PlayerStates>();
        CreateStateList();
    }

    public void CreateStateList()
    {
        states.Add(standing);
        states.Add(walking);
        states.Add(running);
        states.Add(jumping);
        states.Add(climbing);
        states.Add(hurt);
        states.Add(exhausted);
    }
    public void RunCurrentState(PlayerController player)
    {
        switch (playerState.currentState)
        {

            case PlayerStates.State.Standing:
                standing.DoState(player);
                break;

            case PlayerStates.State.Walking:
                player.movement.canChangeDirection = true;
                walking.DoState(player);
                break;

            case PlayerStates.State.Running:
                player.movement.canChangeDirection = true;
                running.DoState(player);
                break;

            case PlayerStates.State.Jumping:
                player.movement.canChangeDirection = true;
                jumping.DoState(player);
                break;

            case PlayerStates.State.Climbing:
                player.movement.canChangeDirection = false;
                climbing.DoState(player);
                break;

            case PlayerStates.State.Hurt:
                hurt.DoState(player);
                break;

            case PlayerStates.State.Exhausted:
                exhausted.DoState(player);
                break;

            default:
                playerState.currentState = PlayerStates.State.Waiting;
                standing.DoState(player);
                break;
        }
    }
    #region State Booleans
    /// <summary>
    /// Checks if we are not in the climbing state. If false we lock movement in the Move() function.
    /// </summary>
    /// <returns>boolean</returns>
    public bool CanMove()
    {
        if (playerState.currentState != PlayerStates.State.Climbing) return true;
        return false;
    }

    /// <summary>
    /// Checks if Player is currently in the Jumping state of the StateHandler.
    /// </summary>
    /// <returns>boolean</returns>
    public bool JumpState()
    {
        if (stateHandlerName == "jumping")
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if Player is currently in the Running state of the StateHandler.
    /// </summary>
    /// <returns>boolean</returns>
    public bool RunState()
    {
        if (playerState.currentState == playerState.running)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if Player is currently in the Standing state of the StateHandler.
    /// </summary>
    /// <returns>boolean</returns>
    public bool StandState()
    {
        if (playerState.currentState == playerState.standing)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if Player is currently in the Walking state of the StateHandler.
    /// </summary>
    /// <returns>boolean</returns>
    public bool WalkState()
    {
        if (playerState.currentState == playerState.walking)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if Player is currently in the Climbing state of the StateHandler.
    /// </summary>
    /// <returns>boolean</returns>
    public bool ClimbState()
    {
        if (playerState.currentState == playerState.climbing)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if Player is currently in the Can Climb state of the StateHandler.
    /// </summary>
    /// <returns>boolean</returns>
    public bool CanClimb(PlayerController player)
    {
        if (player.rays.OnWall() && player.input.ClimbKeyHeld())
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if Player is currently in the Hurt state of the StateHandler.
    /// </summary>
    /// <returns>boolean</returns>
    public bool HurtState()
    {
        if (playerState.currentState == playerState.hurt)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if Player is currently in the Exhausted state of the StateHandler.
    /// </summary>
    /// <returns>boolean</returns>
    public bool ExhaustedState()
    {
        if (playerState.currentState == playerState.exhausted)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if we are not the Jumping, Climbing, Exhausted and Hurt state. If true the player is able to enter the Running state.
    /// </summary>
    /// <returns>boolean</returns>
    public bool CanRun()
    {
        if (!JumpState() && !ClimbState() && !ExhaustedState() && !HurtState()) return true;
        return false;
    }
    #endregion
}
