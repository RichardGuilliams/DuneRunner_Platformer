using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector]
    public float gravityScale;

    [HideInInspector]
    public Vector3 direction;
    [HideInInspector]
    public bool canChangeDirection;
    [HideInInspector]
    public float currentYPosition;
    [HideInInspector]
    public float lastYPostion;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public Vector2 velocity;

    public void Start()
    {
        direction = transform.localScale;
        canChangeDirection = true;
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public void Move(Rigidbody2D rb)
    {
        velocity.x = Input.GetAxisRaw("Horizontal") * speed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }

    public void UpdatePosition()
    {
        lastYPostion = currentYPosition;
    }

    public void ResetYPosition()
    {
        currentYPosition = transform.position.y;
    }
    public void FlipSprite(Transform transform, bool left, bool right)
    {
        transform.localScale = PlayerDirection(left, right);
    }
    public Vector3 PlayerDirection(bool left, bool right)
    {
        if (canChangeDirection)
        {
            if (left)
            {
                direction.x = -1;
            }
            else if (right)
            {
                direction.x = 1;
            }
        }
        return direction;
    }
}

