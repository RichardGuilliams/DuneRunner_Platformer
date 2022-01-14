using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPositionToPlayer : MonoBehaviour
{
    public GameObject player;
    public float xOffset;
    public float yOffset;
    private Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        offset.x = player.transform.position.x + xOffset;
        offset.y = player.transform.position.y + yOffset;
        gameObject.transform.position = offset;
    }
}
