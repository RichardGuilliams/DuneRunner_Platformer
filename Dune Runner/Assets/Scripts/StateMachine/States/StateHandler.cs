using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateHandler : MonoBehaviour
{
    public Action action;
    public List<string> states;
    public string currentState;
    public abstract void DoState(PlayerController player);

}
