using UnityEngine;

public class Shield : MonoBehaviour
{
    // Gets the ghosts pointOfView collider and disables it   
    public Collider ghostCollider;
    public Collider ghostCollider2;

    public Collider playerCollider;
    public float shieldTime = 6f;

    // On trigger enter, disable the ghostCollider for the shield time.
    void OnTriggerEnter (Collider other)
    {
        // Check if the other object is the player.
        if (other.transform == playerCollider.transform)
        {
            // Disable the ghostCollider for the shield time.
            ghostCollider.enabled = false;
            ghostCollider2.enabled = false;
            // Enable the ghostCollider after the shield time.
            Invoke("EnableGhostCollider", shieldTime);
            // Moves the shield object to 10000 units away from the player
            gameObject.transform.position = new Vector3(10000, 10000, 10000);
            // Console log that shows the player has been shielded
            Debug.Log("Player has been shielded");
            // Console log that shows the shield time
            Debug.Log("Shield time: " + shieldTime);
        }
    }

    // Enable the ghostCollider after the shield time.
    void EnableGhostCollider()
    {
        ghostCollider.enabled = true;
        // Console log that shows the ghostCollider has been enabled
        Debug.Log("ghostCollider has been enabled");
        ghostCollider2.enabled = true;
        
    }
}
