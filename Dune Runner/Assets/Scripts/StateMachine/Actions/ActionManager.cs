using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionManager : MonoBehaviour
{
    public List<Action> actions;
    public StandAction stand;
    public WalkAction walk;
    public RunAction run;
    public JumpAction jump;
    public ClimbAction climb;
}
