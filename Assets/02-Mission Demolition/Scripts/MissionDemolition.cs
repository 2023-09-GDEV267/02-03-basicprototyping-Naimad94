using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing, 
    levelEnd
}

public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S; //a private Singleton

    [Header("Set in Inspector")]
    public Text uitLevel; //The UIText_Level Text
    public Text uitShots; //The UIText_Shots text
    public Text uitButton; //The Text on UIButton_View
    public Vector3 castlePos; //The place to put castles
    public GameObject[] casltes; //An array of the castles

    [Header("Set Dynamically")]
    public int level; //The current level
    public int levelMax; //The number of levels
    public int shotsTaken;
    public GameObject castle; //The current castle
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot"; //FollowCam mode

    // Start is called before the first frame update
    void Start()
    {
        S = this; //Define the Slingshot

        level = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    void StartLevel()
    {
        if(castle != null) 
        {
            Destroy(castle);
        }
    }

    //Destroy old projectiles if they exist
    GameObject[] gos = GameObject.FindObjectsWithTag("Projectile");
    for each (GameObject pTemp in gos)
    {
        Destroy(pTemp);
    }

    //Instantiate the new castle
    castle = Instantiate<GameObject>(castles[level]);
    castle.transform.position = casltePos;
    shotsTaken = 0;
    //Reset the camera
    SwitchView("Show Both");
    ProjectileLine.S.Clear();
    //Reset the goal
    Goal.goalMet = false;
    UpdateGui();
    mode = GameMode.playing;
}
