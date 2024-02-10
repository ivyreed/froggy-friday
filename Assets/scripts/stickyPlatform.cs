using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class stickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.name=="Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
        if (collision.gameObject.name == "mirror")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
        if (collision.gameObject.name == "mirror")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
