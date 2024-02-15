using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTarget : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform mirror;
    [SerializeField] private float splitAmount = 7f;
    private void Update()
    {
    // A) when bottom charachter get out of split range, camera keeps top charahter at the top of the camera
        if (player.position.y > mirror.position.y && player.position.y - mirror.position.y > splitAmount)
        {
            transform.position = new Vector3(transform.position.x, player.position.y - splitAmount, transform.position.z);

        }
        else if (player.position.y < mirror.position.y && mirror.position.y - player.position.y > splitAmount)
        {
            transform.position = new Vector3(transform.position.x, mirror.position.y - splitAmount, transform.position.z);

        }
    // B) when bottom charachter get out of split range, camera snaps to top charahter
        // if (player.position.y > mirror.position.y && player.position.y - mirror.position.y > splitAmount)
        // {
        //     transform.position = new Vector3(transform.position.x, player.position.y - splitAmount, transform.position.z);

        // }
        // else if (player.position.y < mirror.position.y && mirror.position.y - player.position.y > splitAmount)
        // {
        //     transform.position = new Vector3(transform.position.x, mirror.position.y - splitAmount, transform.position.z);

        // }

        //camera splits the difference between charachters y axis until splitAmount is reached 
        else if (mirror.position.y < player.position.y && player.position.y - mirror.position.y <= splitAmount)
        {
            transform.position = new Vector3(transform.position.x, player.position.y - ((player.position.y - mirror.position.y) * .5f), transform.position.z);

        }
        else if (player.position.y < mirror.position.y && mirror.position.y - player.position.y <= splitAmount)
        {
            transform.position = new Vector3(transform.position.x, mirror.position.y - ((mirror.position.y - player.position.y) * .5f), transform.position.z);

        }

        //I added this because if i made the last 'else if' my 'else' statement, camera would spring back to player on mirrors death but not the other way around
        else
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }
}