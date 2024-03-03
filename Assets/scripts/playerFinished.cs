using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerFinished : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D playerRB;

    [SerializeField] private Transform mirror;
    [SerializeField] private Rigidbody2D mirrorRB;

    [SerializeField] private float winHeight = 50;
    private float winCounter;
    [SerializeField] private float waitTime;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > winHeight && mirror.position.y > winHeight)
        {
            playerRB.gravityScale = 0;
            mirrorRB.gravityScale = 0;
            winCounter -= Time.deltaTime;

        }
        if(winCounter<-waitTime)
        {
            RestartLevel();
        }

    }
    private void RestartLevel()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
