using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 3.0f;

    private float maxPosZ = 1.0f;
    private float minPosZ = -468.5f;
    
    private void LateUpdate()
    {        
        Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(target.position.z, minPosZ, maxPosZ));
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
