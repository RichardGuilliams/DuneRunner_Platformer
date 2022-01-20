using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAction : Action
{
    public override void ProcessAction(PlayerController player)
    {
        player.movement.SetSpeed(player.stateManager.walking.walk.speed);
        if (player.stateManager.CanMove())
        {
            player.movement.Move(player.rb);
        }
        return;
    }
}
