using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{ 
    static public GameObject POI; //The point of interest (Static)

    [Header ("Set in Inspector")]
    public float easing = 0.05f;

    [Header("Set Dynamically")]
    public float camZ; //The z position of the camera

    void Awake()
    {
        camZ = this.transform.position.z; //Assigning 'camZ' by getting it's Z position from the transform.
    }

    void FixedUpdate()
    {
        //if there's only one line follwing an if, it doesn't need braces
        if (POI == null) return; //if point of interest = no object then return.

        //Get the position of the poi
        Vector3 destination = POI.transform.position; //Assigning POI to destination.

        //Interpolate from the current Camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing); //Assigining Vector3.Lerp to destination.

        //Force destinagtion.z to be camZ to keep the camera far enough away
        destination.z = camZ; //Assigning camZ to destination.z

        //Set the camera to the destination
        transform.position = destination; //assigning the destination to the position in the transform. 
    }



}
