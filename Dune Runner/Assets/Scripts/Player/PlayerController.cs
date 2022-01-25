using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerController>();
                if (instance == null) instance = new GameObject().AddComponent<PlayerController>();
            }
            return instance;
        }
    }

    [Header("Stat Manager")]
    public StatManager stats;

    [Header("Movement Manager")]
    public Movement movement;

    [Header("Input")]
    public PlayerInput input;

    [Header("Physics")]
    public Physics physics;

    [Header("State Manager")]
    public StateManager stateManager;

    [Header("Raycast Manager")]
    public RaycastManager_6 rays;

    [Header("Rigidbody")]
    public Rigidbody2D rb;

    [HideInInspector]
    public Vector3 lockedPosition;

    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    public void OnEnable()
    {
    }
    public void Start()
    {
        physics.gravityScale = rb.gravityScale;
        rays = rays.GetComponent<RaycastManager_6>();
        stats = stats.GetComponent<StatManager>();
        stateManager = stateManager.GetComponent<StateManager>();
    }

    public void CheckSpeed()
    {
        if (input.RunKeyHeld()) movement.speed = stateManager.GetAction("Run").speed;
        else movement.speed = stateManager.GetAction("Walk").speed;
    }

    public void FixedUpdate()
    {
        input.checkInput();
        stateManager.RunCurrentState(this);
        if (stateManager.CanMove())
        {
            CheckSpeed();
            movement.Move(rb);
            movement.FlipSprite(transform, input.LeftInput(), input.RightInput());
        }
        movement.velocity = rb.velocity;
        stats.stm.StatRegen();
    }
}
