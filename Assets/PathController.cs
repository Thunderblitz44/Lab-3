using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public Transform[] waypoints; // Define the points on your line/path
    public float speed = 5.0f; // Speed at which the GameObject moves
    public Transform targetObject; 
    public Rigidbody targetRigidbody; // Reference to the GameObject to rotate towards
    private int currentWaypoint = 0;
    private bool playerMoving = false;
    void Update()
    {
        if (waypoints.Length == 0)
        {
            return; // No waypoints, nothing to do
        }

        // Calculate the rotation to point towards the target
        if (targetObject != null)
        {
            Vector3 targetDirection = targetObject.position - transform.position;
            targetDirection.y = 0; // Lock rotation to Y-axis

            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            }
        }

        // Move the GameObject towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

        // Check if the GameObject has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.01f)
        {
            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0; // Loop back to the first waypoint
            }
        }
        }
    }
    

    

