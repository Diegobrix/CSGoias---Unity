using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody rigidBody;
    
    [SerializeField] private float maxPlayerSpeed;
    [SerializeField] private float playerAccelerationSpeed;
    private Vector3 playerVelocity;

    public bool isGrounded;
    private float jumpForce = 5f;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        isGrounded = true;

        maxPlayerSpeed = 10f;
        playerAccelerationSpeed = (maxPlayerSpeed * 5);
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

    public float PlayerStartRun()
    {
        return maxPlayerSpeed = 20f;
    }

    public float PlayerStopRun()
    {
        return maxPlayerSpeed = 10f;
    }

    private void OnCollisionEnter(Collision col) 
    {
        if(col.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision col) 
    {
        if(col.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
