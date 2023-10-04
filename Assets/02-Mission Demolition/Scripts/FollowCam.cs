using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{ 
    static public GameObject POI; //The point of interest (Static)

    [Header ("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

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

        //Limit the X & Y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        //Interpolate from the current Camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing); //Assigining Vector3.Lerp to destination.

        //Force destinagtion.z to be camZ to keep the camera far enough away
        destination.z = camZ; //Assigning camZ to destination.z

        //Set the camera to the destination
        transform.position = destination; //assigning the destination to the position in the transform. 

        //Set the orthographicSize of the Camera to keep Ground in view.
        Camera.main.orthographicSize = destination.y + 10;
    }



}
