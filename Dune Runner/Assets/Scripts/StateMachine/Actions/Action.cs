using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public string currentState;
    public List<string> subStates;
    public string actionName;
    [HideInInspector]
    public string ascendAction = "AscendAction";
    [HideInInspector]
    public string descendAction = "DescendAction";
    [HideInInspector]
    public string startAction = "StartAction";
    [HideInInspector]
    public string maintainAction = "MaintainAction";
    [HideInInspector]
    public string endAction = "EndAction";
    [HideInInspector]
    public string processAction = "ProcessAction";
    public float speed;
    public float startcost;
    public float endCost;
    public bool canDoAction = true;

    public virtual bool IsPerformingAction(PlayerController player) { return false; }
    public virtual bool TryingPerformAction(PlayerController player) { return false; }


    public virtual void ProcessAction(PlayerController player) { }
    public virtual void CheckAction(PlayerController player) { }
    public virtual void StartAction(PlayerController player) { }
    public virtual void AscendAction(PlayerController player) { }
    public virtual void MaintainAction(PlayerController player) { }
    public virtual void DescendAction(PlayerController player) { }
    public virtual void EndAction(PlayerController player) { }
}

