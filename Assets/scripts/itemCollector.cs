using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    private int toben=0;
    [SerializeField] private Text tokensText;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) 
    {
    if (collision.gameObject.CompareTag("token"))
    {
        Destroy(collision.gameObject);
        toben++;
        tokensText.text= "Tokens = (token)";
    }
    }
     private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.name == "mirror")
        {
            tokensText.text= "Tokens =" + toben;
        }
    }
}
