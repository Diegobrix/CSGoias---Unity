using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody rigidBody;
    
    private float maxPlayerSpeed = 10f;
    private float playerAccelerationSpeed = 50f;
    private Vector3 playerVelocity;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
    }

    private Vector3 playerDirection = Vector3.zero;
    private Vector3 currentPlayerVelocity;
    public Vector3 setPlayerMovement(Vector2 playerInput)
    {
        playerDirection = new Vector3(playerInput.x, 0, playerInput.y).normalized;
        playerVelocity = Vector3.SmoothDamp(playerVelocity, playerDirection * maxPlayerSpeed, ref currentPlayerVelocity, maxPlayerSpeed / playerAccelerationSpeed);
        return transform.position += playerVelocity * Time.deltaTime;
    }
}
