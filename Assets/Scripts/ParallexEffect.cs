using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexEffect : MonoBehaviour
{
    public Camera Cam;
    public Transform FollowTarget;

    Vector2 StartPosition;
    Vector2 camMoveSinceStart => (Vector2)Cam.transform.position - StartPosition;

    float zDistanceFromTarget => transform.position.z - FollowTarget.position.z;
    float clippingPlane => Cam.transform.position.z + (zDistanceFromTarget > 0 ? Cam.farClipPlane : Cam.nearClipPlane);
    float ParallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
    float startZ;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 NewPosition = StartPosition + camMoveSinceStart * ParallaxFactor;
        transform.position = new Vector3(NewPosition.x, NewPosition.y, startZ);
    }
}
