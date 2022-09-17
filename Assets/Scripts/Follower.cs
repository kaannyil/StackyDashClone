using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    PlayerControl playerControl;
    public float distanceTravelled;
    int speed = 10;
    [HideInInspector]
    public bool distanceTravelledBool = false;
    [HideInInspector]
    public bool distanceTravelledBoolBack = false;
    public void PathTravelled()
    {
        if (distanceTravelledBool)
        {
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
        }
        else if (distanceTravelledBoolBack)
        {
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop) * Quaternion.Euler(0,180,0);
        }
    }
    void Update()
    {
        if (distanceTravelledBool)
        {
            distanceTravelled += speed * Time.deltaTime;
        }

        else if (distanceTravelledBoolBack)
        {
            distanceTravelled -= speed * Time.deltaTime;
        }
    }
}
