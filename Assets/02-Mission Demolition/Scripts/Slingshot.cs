using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    //fierldsd set in the Unity Inspector pane
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMult = 8f;

    //field set dynamically
    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    private Rigidbody projectileRigidbody;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint"); //transform.Find ("LaunchPoint") searches for a child of slingshot named LaunchPoint and returns its transform.
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
        projectile.GetComponent<Rigidbody>().isKinematic = true;

        //Set it to isKinematic for now.
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = true;
    }

    private void Update()
    {
        if (!aimingMode) return; //If Slingshot is not in aimingMode, don't run this code

        Vector3 mousePos2D = Input.mousePosition; //Get the current mouse positionin 2D screen coordinates
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;

        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta = mouseDelta * maxMagnitude;
        }

        //Move the projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false; //The mouse has been released
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            projectile = null;
        }
    }
}

//What is mono develop?