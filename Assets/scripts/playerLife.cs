using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerLife : MonoBehaviour
{
    [SerializeField] public Transform cam;
    [SerializeField] public float deathDistance;
   private float deathTimeCounter;

    [SerializeField] public float deathTime;



    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
    }
    //50 40
    private void Update()
    {
        if (cam.position.y - rb.position.y> deathDistance)
        {
            deathTimeCounter -= Time.deltaTime;
        }
        else
        {
            deathTimeCounter = 0;
        }

        if (deathTimeCounter<-deathTime)
        {
            RestartLevel();
        }

    }


    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag=="trap")
        {
            die();
        }

        // if (collision.gameObject.tag == "win")
        // {
            
            
        //     die();
        // }

    }
    void die()
    {
        rb.bodyType=RigidbodyType2D.Static;
    anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
