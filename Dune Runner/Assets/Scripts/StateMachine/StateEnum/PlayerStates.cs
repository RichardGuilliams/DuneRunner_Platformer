using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStates : StateEnum
{
    [HideInInspector]
    public enum State
    {
        Waiting,
        Standing,
        Walking,
        Running,
        Jumping,
        Climbing,
        Hurt,
        Exhausted
    }

    [HideInInspector]
    public State waiting = State.Waiting;
    [HideInInspector]
    public State standing = State.Standing;
    [HideInInspector]
    public State walking = State.Walking;
    [HideInInspector]
    public State running = State.Running;
    [HideInInspector]
    public State jumping = State.Jumping;
    [HideInInspector]
    public State climbing = State.Climbing;
    [HideInInspector]
    public State hurt = State.Hurt;
    [HideInInspector]
    public State exhausted = State.Exhausted;

    public State currentState;
}

