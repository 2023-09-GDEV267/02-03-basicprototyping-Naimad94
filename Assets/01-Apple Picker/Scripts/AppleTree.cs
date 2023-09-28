using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab; //Prefab for instantiating apples.

    public float speed = 1f; //Speed at which the AppleTree moves.

    public float leftAndRightEdge = 10f; //Distance where AppleTree turns around.

    public float chanceToChangeDirections = 0.1f; //Chance that the AppleTree will change directions.

    public float secondsBetweenAppleDrops = 1f; //Rate at which Apples will be instantiated.

    public static float bottomY = -20f;

    // Start is called before the first frame update
    //Dropping apples every second
    void Start()
    {
        //The second parameter, 2f, tells Invoke() to wait 2 seconds before it calls DropApple().
        Invoke("DroppApple", 2f); //Drops Apple every second.
    }

    void DropApple() //DropApple() is a custom function to instantiate an Apple at the AppleTree's location.
    {
        GameObject apple = Instantiate<GameObject>(applePrefab); //DropApple()creates an instance of applePrefab and assigns it to the GameObject.
        apple.transform.position = transform.position; //The position of this new apple GameObject is set to the position of the AppleTree.


        //Invoke() is called again. This time, it will call the DropApple function in secondsBetweenAppleDrops seconds (in this case, in 1 second based on the
        //default settings in the inspector). Because DropApple() function in default settings in the Inspector). Because DropApple() invokes itself every time it
        //is called, the effect will be for an Apple to be dropped every second that the game runs.
        Invoke("DropApple", secondsBetweenAppleDrops);

    }

    // Update is called once per frame
    //Basic Movement
    //Changing Direction
    void Update()
    {
        Vector3 pos = transform.position; //Current position of AppleTree
        pos.x += speed * Time.deltaTime; //x component of pos is increased by the speed * Time.
        transform.position = pos; //Assigns this modified pos back to transform.position (moves AppleTree to a new position)

         //Test whether the new pos.x that was just set in the previous lines is < the negative side to side limit that is set by leftAndRightEdge.
        if(pos.x < -leftAndRightEdge)
        {
            //Move Right,If pos.x is too small, speed is set to Mathf.Abs(speed), which takes the absolute value of speed, gaurenteeing that the resulting value will be 
            //positive, which translates into movement right.
            speed = Mathf.Abs(speed);  //Move Right
        }
        //If pos.x is > than leftAndRightEdge, then speed is set to the negative of Mathf.Abs (Speed), ensuring that the AppleTree will move to the left.
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move Left
        }
        //Random.value returns a random float value between 0 and 1 (including 0 and 1 as possible vallues). If this random number is less than chanceToChangeDirections
        else if(Random.value < chanceToChangeDirections)
        {
            speed = speed * -1; //Change direction. Apple Tree will change directions by setting speed to the negative of itself.
        }
    }

    //Changing Direction Randomly is now time-based because of fixedUpdate()
    void FixedUpdate()
    {
        if(Random.value < chanceToChangeDirections) //Cut the two lines that were marked // a and // b in the code listing for step1, replace them with the closing brace.
        {
            speed = speed * -1; //Pastes it here. (Change direction)
        }
    }
}

//deltaTime is the measure of the number of seconds since the last frame. Allows movement of the AppleTree time based.
//Time.deltaTime is 0.04f (each frame is 4/100 of a second)

//The invoke() function calls a named function in a certain number of seconds. In this case, it is calling the new function DropApple().