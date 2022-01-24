using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : StateHandler
{
    #region StateAction
    public JumpAction jump;
    #endregion

    #region Handle State
    public override void DoState(PlayerController player)
    {
        switch (action.currentState)
        {
            case "AscendAction":
                action.AscendAction(player);
                break;

            case "DescendAction":
                action.DescendAction(player);
                break;

            case "EndAction":
                action.currentState = action.ascendAction;
                break;
            default:
                action.ProcessAction(player);
                action.currentState = action.ascendAction;
                break;
        }
    }
    #endregion
}
