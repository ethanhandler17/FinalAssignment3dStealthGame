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
                    // Check if player is shielded - if so, destroy this observer instead of catching player
                    if (Shield.IsPlayerShielded)
                    {
                        // Player is shielded, destroy the parent ghost GameObject
                        Debug.Log("Ghost destroyed by shielded player!");
                        
                        // Destroy the parent GameObject (the actual ghost prefab)
                        if (transform.parent != null)
                        {
                            Destroy(transform.parent.gameObject);
                        }
                        else
                        {
                            // Fallback: destroy root if no parent
                            Destroy(transform.root.gameObject);
                        }
                    }
                    else
                    {
                        // Player is not shielded, catch them
                        gameEnding.CaughtPlayer();
                    }
                }
            }

        }
    }
}