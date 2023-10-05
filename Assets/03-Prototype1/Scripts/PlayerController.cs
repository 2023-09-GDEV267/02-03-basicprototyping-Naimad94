using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Declarations
    private Rigidbody rb;
    private float movementX; //Reason it's a float value is because we want better movement instead of
    private float movementY; //an int which will give us whole num and not give us acurate movement

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Assigning Rigidbody component to rb.
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x; //Assigning movementVector.x to movementX
        movementY = movementVector.y; //Assigning movementVector.z to movementZ
    }

    private void FixedUpdate()
    {
        //Assiging a new object of Vector3 to Vector3 movement. Don't know whats the parameters mean.
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement); //Adding force to rb(Rigidbody component)
    }
}


//Code is from Rollaball except roll a ball used x and y to move in my case im using x and z to move.