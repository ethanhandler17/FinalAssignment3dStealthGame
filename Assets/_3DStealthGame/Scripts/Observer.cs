using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    // Get the game ending component.
    public GameEnding gameEnding;
    // Get the player transform.
    public Transform player;
    // Set if the player is in range.
    bool m_IsPlayerInRange;
    

    // On trigger enter, set the player in range to true.
    void OnTriggerEnter (Collider other)
    {
        // Check if the other object is the player.
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    // On trigger exit, set the player in range to false.
    void OnTriggerExit (Collider other)
    {
        // Check if the other object is the player.
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    // Update is called once per frame.
    void Update ()
    {
        // Check if the player is in range.
        if (m_IsPlayerInRange)
        {
            // Set the direction of the ray.
            Vector3 direction = player.position - transform.position + Vector3.up;
            // Create a ray.
            Ray ray = new Ray(transform.position, direction);
            // Create a raycast hit.
            RaycastHit raycastHit;
            // Check if the raycast hits the player.

            if(Physics.Raycast(ray, out raycastHit))
            {
                // Check if the raycast hits the player.
                if (raycastHit.collider.transform == player)
                {
                    // Call the game ending caught player method.
                    gameEnding.CaughtPlayer();
                }
            }

        }
    }
}