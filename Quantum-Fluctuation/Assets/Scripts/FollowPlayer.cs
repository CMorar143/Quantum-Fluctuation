using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform cameraTarget;
    public float speed = 8.0f;
    private float interpolation;

    // Update is called once per frame
    void Update()
    {
        interpolation = speed * Time.deltaTime;

        this.transform.position = Vector3.Lerp(this.transform.position, cameraTarget.position, interpolation);
        transform.LookAt(cameraTarget.parent);
    }
}
