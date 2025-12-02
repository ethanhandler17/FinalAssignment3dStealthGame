using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    // Set the move speed.
    public float moveSpeed = 1.0f;
    // Set the waypoints.
    public Transform[] waypoints;

    // Get the rigidbody component.
    private Rigidbody m_RigidBody;
    // Set the current waypoint index.
    int m_CurrentWaypointIndex;

    void Start ()
    {
        // Get the rigidbody component.
        m_RigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        // Get the current waypoint.
        Transform currentWaypoint = waypoints[m_CurrentWaypointIndex];
        // Set the current to target vector.
        Vector3 currentToTarget = currentWaypoint.position - m_RigidBody.position;

        // Check if the current to target is less than 0.1f.
        if (currentToTarget.magnitude < 0.1f)
        // Increment the current waypoint index.
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
        }
        // Set the forward rotation.
        Quaternion forwardRotation = Quaternion.LookRotation(currentToTarget);
        // Move the rigidbody to the forward rotation.
        m_RigidBody.MoveRotation(forwardRotation);
        // Move the rigidbody to the current to target position.
        m_RigidBody.MovePosition(m_RigidBody.position + currentToTarget.normalized * moveSpeed * Time.deltaTime);
    }
}