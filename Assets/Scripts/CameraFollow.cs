using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float smoothSpeed = 0.125f;

    private float smoothFactor = 0.5f;
    public bool lookAtTarget = false;

    void Start()
    {
        cameraOffset = transform.position - target.transform.position;    
    }
    private void LateUpdate()
    {
        Vector3 newPos = target.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if(lookAtTarget)
            transform.LookAt(target);
    }
}
