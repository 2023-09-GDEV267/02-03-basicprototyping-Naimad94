using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    static public ProjectileLine S; //Singleton

    [Header("Set in Inspector")]
    public float minDist = 0.1f;

    private LineRenderer line;
    private GameObject _poi;
    private List<Vector3> points;
    private object get;

    private void Awake()
    {
        S = this; //Set the singleton
        line = GetComponent<LineRenderer>(); //Get a refrence to the LineRenderer

        line.enabled = false; //Disable the LineRenderer until it's needed

        points = new List<Vector3>(); //Initialize the points List
    }

    public GameObject poi
    {
        get
        {
            return (_poi);
        }
        set
        {
            _poi = value;
            if(_poi != null) 
            {
                line.enabled = false; //When _poi is set to something new, it resets everything
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }

    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    public void AddPoint()
    {
        Vector3 pt = _poi.transform.position; //This is called to add a point to the line

        if(points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {
            return; //If the point isn't far enough from the last point, it returns
        }

        if (points.Count == 0 )
        {
            //If this is a launch point...
            Vector3 launchPosDiff = pt - Slingshot.LAUNCH_POS; //TBD it adds an extra bit of line to aid aiming later

            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.positionCount = 2;

            //Sets the first two points
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);

            line.enabled = true; //Enables the Line Renderer
        }
        else
        {
            points.Add(pt);
            line.positionCount = points.Count;
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;

        }
    }

    //Returns the location of the most recently added point
    public Vector3 lastPoint()
    {
        get 
        { 
            if(points == null)
            {
                return (Vector3.zero); //If there is no points, returns Vector3.zero
            }
            return (points[points.Count - 1]); 
        }
    }

    private void FixedUpdate()
    {
        if (poi == null)
        {
            if (FollowCam.POI != null)
            {
                if (FollowCam.POI.tag == "Projectile")
                {
                    poi = FollowCam.POI;
                }
                else
                {
                    return; //Return if we didn't find a poi
                }
            }
            else
            {
                return;
            }
        }

        AddPoint(); //If there is a poi, it's loc is added every FixedUpdate

        if (FollowCam.POI == null)
        {
            poi = null; //Once FollowCam.POI is null, make the local poi null too
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
