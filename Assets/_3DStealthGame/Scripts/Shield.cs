using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{
    // Static variable to track if player is currently shielded
    public static bool IsPlayerShielded = false;
    
    // Reference to the player collider
    public Collider playerCollider;
    // Duration of the shield effect in seconds
    public float shieldTime = 10f;

    // On trigger enter, activate shield when player picks it up
    void OnTriggerEnter (Collider other)
    {
        // Check if the other object is the player
        if (other.transform == playerCollider.transform)
        {
            // Activate shield mode
            StartCoroutine(ActivateShield());
            // Hide/destroy the shield pickup
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            // Console log that shows the player has been shielded
            Debug.Log("Player has been shielded for " + shieldTime + " seconds");
        }
    }

    // Coroutine to activate shield for the specified duration
    IEnumerator ActivateShield()
    {
        // Enable shield mode
        IsPlayerShielded = true;
        
        // Wait for the shield duration
        yield return new WaitForSeconds(shieldTime);
        
        // Disable shield mode
        IsPlayerShielded = false;
        // Console log that shows the shield has expired
        Debug.Log("Shield has expired");
        
        // Destroy the shield object after use
        Destroy(gameObject);
    }
}
