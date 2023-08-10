using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovementController : MonoBehaviour
{
    public PlayerLookController playerLook;
    [SerializeField] private float gunMoveSpeed;
    [SerializeField] private float speed;

    private Vector3 originalGunPosition;
    private PlayerLookController lookController;

    private void Awake()
    {
        originalGunPosition = transform.localPosition;
        speed = 1.5f;
        gunMoveSpeed = 2f;
    }

    public void SetGunMovement(Vector2 mouseInput)
    {
        Quaternion rotationX = Quaternion.AngleAxis(-(mouseInput.y * speed), Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(-(mouseInput.x * speed), Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, gunMoveSpeed * Time.deltaTime);
    }
}
