using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateHandler : MonoBehaviour
{
    public Action action;
    public string stateName;
    public List<string> states;
    public string currentState;
    public bool stateActive = false;
    public abstract void DoState(PlayerController player);
}
