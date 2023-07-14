using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    private Transform playerTransform;
    private float xRot = 0f;

    //Caso queira especificar uma sensibilidade para o eixo x e y do mouse
    /*
    [SerializeField] private float xSensibility = 30f;
    [SerializeField] private float ySensibility = 30f;
    */

    [SerializeField] private float mouseSensitivity = 30f;

    [SerializeField] private float maxRotationX = 80f;
    [SerializeField] private float minRotationX = -80f;


    private void Awake() {
        playerTransform = GetComponent<Transform>();    
    }

    public void setLook(Vector2 mouseInput)
    {
        xRot -= (mouseInput.y * Time.deltaTime) * mouseSensitivity;
        xRot = Mathf.Clamp(xRot, minRotationX, maxRotationX);

        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        transform.Rotate(Vector3.up * (mouseInput.x * Time.deltaTime) * mouseSensitivity);
    }
}
