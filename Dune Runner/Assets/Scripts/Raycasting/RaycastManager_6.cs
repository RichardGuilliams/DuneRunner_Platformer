using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager_6 : MonoBehaviour
{
    public Ray groundRayLeft;
    public Ray groundRayRight;
    public Ray wallRayLow;
    public Ray wallRayHigh;
    public Ray skyRayLeft;
    public Ray skyRayRight;

    void Start()
    {
        groundRayLeft = groundRayLeft.GetComponent<Ray>();
        groundRayRight = groundRayRight.GetComponent<Ray>();
        wallRayHigh = wallRayHigh.GetComponent<Ray>();
        wallRayLow = wallRayLow.GetComponent<Ray>();
        skyRayLeft = skyRayLeft.GetComponent<Ray>();
        skyRayRight = skyRayLeft.GetComponent<Ray>();
    }

    /// <summary>
    /// Checks if the raycast on players chest is colliding. If so we are touching a wall.
    /// </summary>
    /// <returns>boolean</returns>
    public bool OnGround()
    {
        if (groundRayLeft.collision || groundRayRight.collision) return true;
        return false;
    }

    /// <summary>
    /// Checks if the head raycast is not colliding and if the chest raycast is colling. if true the player is at a ledge.
    /// </summary>
    /// <returns>boolean</returns>
    public bool OnLedge()
    {
        if (!wallRayHigh.collision) return true;      
        return false;
    }

    /// <summary>
    /// Checks if the head raycast is not colliding and if the chest raycast is colling. if true the player is at a ledge.
    /// </summary>
    /// <returns>boolean</returns>
    public bool OnWall()
    {
        if (wallRayLow.collision || wallRayHigh.collision) return true;
        return false;
    }

    public bool ChestCollision()
    {
        if (wallRayLow.collision) return true;
        return false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
