using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    [Header("Object this ray shares data with.")]
    public GameObject rayHost;
    public string rayName;
    public float startXOffset;
    public float endXOffset;
    public float startYOffset;
    public float endYOffset;
    [HideInInspector]
    public Vector2 startingPosition;
    [HideInInspector]
    public RaycastHit2D hit;
    [HideInInspector]
    public bool collision;
    [HideInInspector]
    public Vector2 collisionNormal;
    [HideInInspector]
    public bool rayEnabled;

    void Start()
    {
        rayEnabled = true;
    }

    #region RayCast

    public void Collision()
    {
        if (hit)
        {
            collisionNormal = hit.normal;
            collision = true;
        }
    }

    public void CheckRays()
    {
        Vector2 startingPosition = rayHost.transform.position + Vector3.right * startXOffset * Direction();
        startingPosition += Vector2.up * startYOffset;
        Vector2 endPos = rayHost.transform.position + Vector3.right * endXOffset * Direction();
        endPos += Vector2.up * endYOffset;
        hit = Physics2D.Linecast(startingPosition, endPos, 1 << LayerMask.NameToLayer("Action"));
        if (hit.collider != null)
        {
            Debug.DrawLine(startingPosition, endPos, Color.red);
        }
        else Debug.DrawLine(startingPosition, endPos, Color.green);
        Collision();
    }

    public void ResetRays()
    {
        collision = false;
        collisionNormal = Vector2.zero;
    }

    #endregion

    public float Direction()
    {
        return rayHost.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        ResetRays();
        if (rayEnabled == true)
        {
            CheckRays();
        }
    }
}

