using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody rigidBody;
    
    private float maxPlayerSpeed = 10f;
    private float playerAccelerationSpeed = 50f;
    private Vector3 playerVelocity;

    public bool isGrounded;
    private float jumpForce = 5f;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        isGrounded = true;
    }
    
    private Vector3 playerDirection = Vector3.zero;
    private Vector3 currentPlayerVelocity;
    public void SetPlayerMovement(Vector2 playerInput)
    {
        playerDirection = new Vector3(playerInput.x, 0f, playerInput.y).normalized;
        playerVelocity = Vector3.SmoothDamp(playerVelocity, playerDirection * maxPlayerSpeed, ref currentPlayerVelocity, maxPlayerSpeed / playerAccelerationSpeed);
        transform.position += transform.TransformDirection(playerVelocity) * Time.deltaTime;
    }

    public void Jump()
    {
        if(isGrounded)
        {
            rigidBody.AddForce((Vector3.up * jumpForce), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision col) {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision col) {
        isGrounded = false;
    }
}
