using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.AssetImporters;
using UnityEngine;

public class stickyPlatform : MonoBehaviour
{
    private readonly string[] charachter={"Player","mirror"};
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (charachter.Contains(collision.gameObject.name))
        {
            collision.gameObject.transform.SetParent(transform);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (charachter.Contains(collision.gameObject.name))
        {
            collision.gameObject.transform.SetParent(null);
        }

    }
}
