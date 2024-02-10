using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollector : MonoBehaviour
{
    private int token=0;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) 
    {
    if (collision.gameObject.CompareTag("token"))
    {
        Destroy(collision.gameObject);
        token++;
        Debug.Log("token:"+token);
    }
    }
}
