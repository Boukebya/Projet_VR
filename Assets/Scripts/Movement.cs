using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //GameObject path
    public GameObject path;
    
    //current waypoint
    public int currentWaypoint = 0;
    
    public float speed;

    void Start()
    {
        //get speed from Stat
        speed = GetComponent<Stat>().actualSpeed;
        
        //get waypoints from path
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //get speed from Stat
        speed = GetComponent<Stat>().actualSpeed;
    
    
        //follow waypoints
        if (currentWaypoint < path.transform.childCount)
        {
            //get position of current waypoint
            Vector3 target = path.transform.GetChild(currentWaypoint).position;
            //move towards current waypoint
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            //rotate towards current waypoint
            transform.LookAt(target);
            //if reached waypoint, go to next waypoint
            if (transform.position == target)
            {
                currentWaypoint++;
            }
        }
        //if we reached the end of the path, destroy
        else
        {
            Destroy(gameObject);
        }
        
    }
}
