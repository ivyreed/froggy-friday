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

    [SerializeField] private float meetSplit = 7f;

    private void Update()
    {
        var fix = splitAmount / 2;

        float distance =Math.Abs(player.position.y - mirror.position.y);
        if (distance>splitAmount)
        {
            // finds the distance between players 
            var max= Math.Max(player.position.y, mirror.position.y);
            //  - splitAmount/2
            transform.position = new Vector3(transform.position.x, max - fix, transform.position.z);


        }
        else
        {
            var min= Math.Min(player.position.y, mirror.position.y);
            var middle = (player.position.y + mirror.position.y)/2;
            transform.position = new Vector3(transform.position.x, min +fix, transform.position.z);

        }


    }
}