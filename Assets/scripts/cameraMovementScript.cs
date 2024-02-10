using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovementScript : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Update is called once per frame
   private void Update()
    {
        transform.position=new Vector3(transform.position.x, player.position.y, transform.position.z);
    }
}
