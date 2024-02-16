using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class waypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int waypIndex = 0;
    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if (Vector2.Distance(waypoints[waypIndex].transform.position, transform.position) < .1f)
        {
            waypIndex = (waypIndex + 1) % waypoints.Length;
            // waypIndex++;
            // if (waypIndex>=waypoints.Length)
            // {
            //     waypIndex=0;
            // }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypIndex].transform.position, Time.deltaTime * speed);
    }
}
