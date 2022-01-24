using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    #region States
    [HideInInspector]
    public string stateHandlerName;
    [SerializeField]
    public List<StateHandler> states;
    public PlayerStates playerState;

    #endregion

    public void Start()
    {
        stateHandlerName = "Stand";
        ChangeState("Stand");
        playerState = playerState.GetComponent<PlayerStates>();
    }

    public StateHandler CurrentState()
    {
        return states.Find(x => x.stateName == stateHandlerName);
    }

    public StateHandler GetState(string name)
    {
        return states.Find(x => x.stateName == name);
    }

    public Action GetAction(string name)
    {
        return states.Find(x => x.stateName == name).action;
    }

    public void ChangeState(string name)
    {
        states.Find(x => x.stateName == stateHandlerName).stateActive = false;
        states.Find(x => x.stateName == name).stateActive = true;
        stateHandlerName = name;
    }

    public void RunCurrentState(PlayerController player)
    {
        states.Find(x => x.stateActive == true).DoState(player);
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
    public bool InJumpState()
    {
        if (stateHandlerName == "Jump")
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if Player is currently in the Running state of the StateHandler.
    /// </summary>
    /// <returns>boolean</returns>
    public bool InRunState()
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
        if (!InJumpState() && !ClimbState() && !ExhaustedState() && !HurtState()) return true;
        return false;
    }
    #endregion
}
