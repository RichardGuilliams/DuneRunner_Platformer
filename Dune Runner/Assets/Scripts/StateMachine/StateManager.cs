using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    #region States
    [HideInInspector]
    public string stateHandlerName;
    public int currentStateID;
    [SerializeField]
    public List<StateHandler> states;

    #endregion

    public void Start()
    {
        stateHandlerName = "Stand";
        ChangeState("Stand");
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
        if (stateHandlerName != "Climb") return true;
        return false;
    }

    public bool TryingToClimb(PlayerController player)
    {
        if (player.rays.OnWall() && player.input.ClimbKeyHeld()) return true;
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
    /// Checks if we are not the Jumping, Climbing, Exhausted and Hurt state. If true the player is able to enter the Running state.
    /// </summary>
    /// <returns>boolean</returns>
    public bool CanRun()
    {
        if (!InJumpState()) return true;
        return false;
    }
    #endregion
}
