using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{
    public Transform[] PatrolPoints;
    public float Speed;
    Transform CurrentPatrolPoints;
    private int CurrentPatrolNumber;
    
    // Use this for initialization
    void Start()
    {
        CurrentPatrolNumber = 0;
        CurrentPatrolPoints = PatrolPoints[CurrentPatrolNumber];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Speed);
        if(Vector2.Distance (transform.position,CurrentPatrolPoints.position) < 0.1f)
        {
            if(CurrentPatrolNumber + 1 < PatrolPoints.Length)
            {
                CurrentPatrolNumber++;
            }
            else
            {
                CurrentPatrolNumber = 0;
            }
            CurrentPatrolPoints = PatrolPoints[CurrentPatrolNumber];
        }
        //turn to face the current patrol point
        //finding the direction vector that points to the patrol point
        Vector3 PartrolPointDirection = CurrentPatrolPoints.position - transform.position;
        //figure out the rotation in degrees that we need to turn forward
        float angle = Mathf.Atan2(PartrolPointDirection.y, PartrolPointDirection.x) * Mathf.Rad2Deg ;
        //made the rotation that we need to face 
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //Apply the rotation to our transform
        transform.rotation = Quaternion.RotateTowards(transform.rotation,q,1);
    }
}