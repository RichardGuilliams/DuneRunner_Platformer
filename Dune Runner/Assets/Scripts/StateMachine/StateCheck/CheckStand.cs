using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckStand : StateCheck
{
    public HashSet<int> ints;
    public Movement movement;
    public PlayerController player;
    public enum States
    {
        Paused,
        Unpaused
    }

    public States states;

    public override void Check(PlayerController player) {
        if (player.input.MoveKeyHeld()) return;

    }
}

