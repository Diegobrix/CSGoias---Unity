using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    private float xRot = 0f;
    [SerializeField] private float xSensibility = 30f;
    [SerializeField] private float ySensibility = 30f;
    [SerializeField] private float maxRotationX = 80f;
    [SerializeField] private float minRotationX = -80f;

    public void setLook(Vector2 mouseInput)
    {
        xRot -= (mouseInput.y * Time.deltaTime) * ySensibility;
        xRot = Mathf.Clamp(xRot, minRotationX, maxRotationX);

        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.Rotate(Vector3.up * (mouseInput.x * Time.deltaTime) * xSensibility);
    }
}
