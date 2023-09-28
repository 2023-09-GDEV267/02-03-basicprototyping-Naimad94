using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    //fierldsd set in the Unity Inspector pane
    [Header ("Set in Inspector")]
    public GameObject prefabProjectile;

    //field set dynamically
    [Header ("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("launchPoint"); //transform.Find ("LaunchPoint") sarches for a child of slingshot named LaunchPoint and returns its transform.
        launchPoint = launchPointTrans.gameObject;  //Gets the game object associated with that transform and assigns it to the GameObject field launchPoint.
        launchPoint.SetActive(false); //The SetActive method on GameObject like launchPoint tells the game whether or not to ignore them. 
        launchPos = launchPointTrans.position;
    }

    void OnMouseEnter()
    {
        print("Slingshot: OnMouseEnter()"); //print ("Slingshot: OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    // Update is called once per frame
    void OnMouseExit()
    {
        print("Slingshot: OnMouseExit()");  //print ("Slingshot: OnMouseExit()");
        launchPoint.SetActive(false);
    }

    void OnMouseDown()
    {
        //The player has pressed the mouse button while over Slingshot
        aimingMode = true;
        //Instantiate a Projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        //Start it at the launchPoint
        projectile.transform.position = launchPos;
        //Set it as kinematic for now
        projectile.GetComponent<RigidBody>().isKinematic = true;
    }
}

//What is mono develop?