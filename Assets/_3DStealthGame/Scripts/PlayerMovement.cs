using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Get the animator component.
    Animator m_Animator;    
    public InputAction MoveAction;

    // Set the run and walk speeds.
    public float runSpeed = 3.0f;
    public float walkSpeed = 1.0f;
    // Set the turn speed.
    public float turnSpeed = 20f;

    // Get the rigidbody component.
    Rigidbody m_Rigidbody;
    // Set the movement vector.
    Vector3 m_Movement;
    // Set the rotation of the player.
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
        // Get the rigidbody component.
        m_Rigidbody = GetComponent<Rigidbody> ();
        // Enable the movement action.
        MoveAction.Enable();
        // Get the animator component.
        m_Animator = GetComponent<Animator> ();
    }

    void FixedUpdate ()
    {
        // Get the movement input from the keyboard.
        var pos = MoveAction.ReadValue<Vector2>();
        var key = Keyboard.current;
        // Check if the left shift key is pressed.
        bool isRunning = key.leftShiftKey.isPressed;
        // If the left shift key is pressed, the player will run, otherwise they will walk.
        float speed = isRunning ? runSpeed : walkSpeed;
        
        // Set the horizontal and vertical movement values.
        float horizontal = pos.x;
        float vertical = pos.y;
        
        // Set the movement vector.
        m_Movement.Set(horizontal, 0f, vertical);
        // Normalize the movement vector.
        m_Movement.Normalize ();

        // Rotate the player to the desired forward direction.
        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        // Set the rotation of the player.
        m_Rotation = Quaternion.LookRotation (desiredForward);
        // Rotate the player to the desired forward direction.
        m_Rigidbody.MoveRotation (m_Rotation);
        // Move the player to the desired position.
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * speed * Time.deltaTime);
        // Check if the player is walking or running.

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        // Check if the player is walking or running.
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        // Set the walking animation.
        m_Animator.SetBool ("IsWalking", isWalking);
    }
}