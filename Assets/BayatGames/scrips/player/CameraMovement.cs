using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private void FixedUpdate()
    {
        target.position = target.position + offset;
    }
}
