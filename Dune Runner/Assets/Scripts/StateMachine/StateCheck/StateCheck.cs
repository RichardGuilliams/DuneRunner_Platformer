using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateCheck : MonoBehaviour
{
    public string checkName;
    public Action currentAction;
    public Action nextAction;
    public enum Comparisons
    {
        EqualTo,
        GreaterThan,
        GreaterThanEqualTo,
        LessThan,
        LessThanEqualTo
    }

    public virtual void Check(PlayerController player) { }
}

