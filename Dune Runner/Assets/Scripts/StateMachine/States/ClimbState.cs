using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : StateHandler
{
    public ClimbAction climb;

    #region Handle State
    public override void DoState(PlayerController player)
    {
        if (action.currentState == "") action.currentState = "ProcessAction";
        climb.GetType().GetMethod(currentState).Invoke(climb.GetType().GetMethod(currentState), new object[] { player });
        //foreach (string item in action.subStates) {
        //    if (item == currentState)
        //    {
        //        action.GetType().GetMethod(currentState);
        //    }
        //}
    }
    #endregion
}
