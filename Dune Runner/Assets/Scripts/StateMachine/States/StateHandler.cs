using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    public Action action;
    [HideInInspector]
    public string stateName;
    public bool stateActive = false;

    public void Start()
    {
        stateName = action.actionName;
    }
    public void DoState(PlayerController player) {
        action.ProcessAction(player);
    }
}
