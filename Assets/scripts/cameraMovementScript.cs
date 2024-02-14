using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovementScript : MonoBehaviour
{
 

//This code is so the camera will trail behind the camera target giving the camera a bouncy feel
private Vector3 offset = new Vector3(0f,0f,-10f);
[SerializeField] private float smoothTime = .15f;
private Vector3 velocity=Vector3.zero;

[SerializeField] private Transform target;
    private void Update()
        {
            Vector3 targetPosition = target.transform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
}

