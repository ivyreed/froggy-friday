using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class parallax : MonoBehaviour
{

[SerializeField] public Transform oneLayer;
[SerializeField] public Transform twoLayer;
[SerializeField] public Transform threeLayer;
[SerializeField] public Transform fourLayer;
[SerializeField] public Transform fiveLayer;

[SerializeField] public float firstMultiplier;
[SerializeField] public float secondMultiplier;
[SerializeField] public float thirdMultiplier;
[SerializeField] public float fourthMultiplier;
[SerializeField] public float fifthMultiplier;




    //all objects start centered to camera
    //as camera moves up, objects travel at different rates up with it
    // can multiply their y movement by different .1 .2 .3 of camera
    // they would be based off camera. not nested inncamera
    //maaybe this is on camera and targeting backgrounds


    // Update is called once per frame
    void Update()
    {
        oneLayer.transform.position=new Vector2(transform.position.x,transform.position.y*firstMultiplier);
        twoLayer.transform.position = new Vector2(transform.position.x, transform.position.y * secondMultiplier);
        threeLayer.transform.position = new Vector2(transform.position.x, transform.position.y * thirdMultiplier);
        fourLayer.transform.position = new Vector2(transform.position.x, transform.position.y * fourthMultiplier);
        fiveLayer.transform.position = new Vector2(transform.position.x, transform.position.y * fifthMultiplier);

    }
}
