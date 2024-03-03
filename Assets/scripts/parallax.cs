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

[SerializeField] public Transform sixLayer;

[SerializeField] public Transform sevenLayer;



[SerializeField] public float firstMultiplier;
[SerializeField] public float secondMultiplier;
[SerializeField] public float thirdMultiplier;
[SerializeField] public float fourthMultiplier;
[SerializeField] public float fifthMultiplier;
[SerializeField] public float sixthMultiplier;
[SerializeField] public float seventhMultiplier;





    //all objects start centered to camera
    //as camera moves up, objects travel at different rates up with it
    // can multiply their y movement by different .1 .2 .3 of camera
    // they would be based off camera. not nested inncamera
    //maaybe this is on camera and targeting backgrounds


    // Update is called once per frame
    private Vector2 parallaxMultiplier(float multiplier)
    {
        return new Vector2(transform.position.x, (transform.position.y*multiplier)+20);
    }
    void Update()
    {
        oneLayer.transform.position= parallaxMultiplier(firstMultiplier);
        twoLayer.transform.position = parallaxMultiplier(secondMultiplier);
        threeLayer.transform.position = parallaxMultiplier(thirdMultiplier);
        fourLayer.transform.position = parallaxMultiplier(fourthMultiplier);
        fiveLayer.transform.position = parallaxMultiplier(fifthMultiplier);
        sixLayer.transform.position = parallaxMultiplier(sixthMultiplier);
        sevenLayer.transform.position = parallaxMultiplier(seventhMultiplier);


    }
}
