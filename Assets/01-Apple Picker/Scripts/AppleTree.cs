using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab; //Prefab for instantiating apples.

    public float speed = 1f; //Speed at which the AppleTree moves.

    public float leftAndRightEdge = 10f; //Distance where AppleTree turns around.

    public float chanceToChangeDirection = 0.1f; //Chance that the AppleTree will change directions.

    public float secondsBetweenAppleDrops = 1f; //Rate at which Apples will be instantiated.

    // Start is called before the first frame update
    //Dropping apples every second
    void Start()
    {
        
    }

    // Update is called once per frame
    //Basic Movement
    //Changing Direction
    void Update()
    {
        Vector3 pos = transform.position; //Current position of AppleTree
        pos.x += speed * Time.deltaTime; //x component of pos is increased by the speed * Time.
        transform.position = pos; //Assigns this modified pos back to transform.position (moves AppleTree to a new position)
    }

    //Test whether the new pos.x that was just set in the previous lines is < the negative side to side limit that is set by leftAndRightEdge.
        if (pos.x < -leftAndRightEdge)
        {
            //Move Right,If pos.x is too small, speed is set to Mathf.Abs(speed), which takes the absolute value of speed, gaurenteeing that the resulting value will be 
            //positive, which translates into movement right.
            speed = Mathf.Abs(speed);  //Move Right
        }
        //If pos.x is > than leftAndRightEdge, then speed is set to the negative of Mathf.Abs (Speed), ensuring that the AppleTree will move to the left.
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Math.Abs(speed); //Move Left
        }
}

//deltaTime is the measure of the number of seconds since the last frame. Allows movement of the AppleTree time based.
//Time.deltaTime is 0.04f (each frame is 4/100 of a second)