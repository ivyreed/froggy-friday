using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class cameraTarget : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform mirror;
    [SerializeField] private float splitAmount = 7f;
    private void Update()
    {
        float distance=Math.Abs(player.position.y - mirror.position.y);
        if (distance>splitAmount)
        {
            var max= Math.Max(player.position.y, mirror.position.y);
            transform.position = new Vector3(transform.position.x, max - splitAmount/2, transform.position.z);

        }
        else
        {
            var middle = (player.position.y + mirror.position.y)/2;
            transform.position = new Vector3(transform.position.x, middle, transform.position.z);

        }

    }
}