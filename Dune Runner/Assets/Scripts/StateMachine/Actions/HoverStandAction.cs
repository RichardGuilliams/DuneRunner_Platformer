using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverStandAction : Action
{
    public bool rising = true;
    public float maxHoverHeight;
    public float hoverSpeed;
    public float hoverPosition;
    public float hoverStartingPosition;
    public float minHoverHeight;
    public GameObject bones;

    public void Start()
    {
        bones = GameObject.FindGameObjectWithTag("Bones");
    }
    public override void ProcessAction(PlayerController player)
    {
        hoverStartingPosition = player.transform.position.y;
        if (player.input.IsAttemptingWalk())
        {
            EndHover(player, "Walk");
            return;
        }
        else if (player.input.IsAttemptingRun())
        {
            EndHover(player, "Run");
            return;
        }
        else if (player.input.IsAttemptingJump())
        {
            EndHover(player, "Jump");
            return;
        }
        else if (player.stateManager.TryingToClimb(player))
        {
            EndHover(player, "Climb");
            return;
        }
        Hover(player);
    }

    public void EndHover(PlayerController player, string stateName)
    {
        if (bones.transform.position.y >= player.transform.position.y) bones.transform.Translate(Vector3.up * -hoverSpeed * 14, Space.Self);
        else player.stateManager.ChangeState(stateName);
    }

    public bool maxHeightReached(PlayerController player)
    {
        if (bones.transform.position.y >= maxHoverHeight + player.transform.position.y + minHoverHeight) return true;
        return false;
    }

    public bool minHeightReached(PlayerController player)
    {
        if (bones.transform.position.y <= player.transform.position.y + minHoverHeight) return true;
        return false;
    }

    public void Hover(PlayerController player)
    {
        Debug.Log("Trying to hover");
        if(rising && !maxHeightReached(player)) bones.transform.Translate(Vector3.up * hoverSpeed, Space.Self);
        if (rising && maxHeightReached(player)) rising = false;
        if (!rising && !minHeightReached(player)) bones.transform.Translate(Vector3.up * -hoverSpeed, Space.Self);
        if (!rising && minHeightReached(player)) rising = true;
    }
}
