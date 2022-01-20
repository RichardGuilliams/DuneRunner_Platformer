using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : StateHandler
{
    public ClimbAction climb;

    #region Handle State
    public override void DoState(PlayerController player)
    {
        action.GetType().GetMethod(currentState);
        foreach (string item in action.subStates) {
            if (item == currentState)
            {
                action.GetType().GetMethod(currentState);
            }
        }
    }
    #endregion
}
