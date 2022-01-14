using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Vector2 parallaxMultiplier;
    private Vector3 parallaxPosition;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        parallaxPosition.x = deltaMovement.x * parallaxMultiplier.x;
        parallaxPosition.y = deltaMovement.y * parallaxMultiplier.y;
        transform.position += parallaxPosition;
        lastCameraPosition = cameraTransform.position;
    }
}
