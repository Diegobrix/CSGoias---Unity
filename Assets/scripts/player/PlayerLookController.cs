using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : MonoBehaviour
{
    public InputController inputController;

    public Camera playerCamera;
    private Transform playerTransform;
    private float xRot = 0f;

    [SerializeField] private float mouseSensitivity = 30f;

    [SerializeField] private float maxRotationX = 80f;
    [SerializeField] private float minRotationX = -80f;

    public GunPickUp gunController;
    private bool gunEquipped;

    public GunMovementController gunSway;

    private void Awake() {
        playerTransform = GetComponent<Transform>();
        gunController = GameObject.Find("Gun").GetComponent<GunPickUp>();
        inputController = GetComponent<InputController>();

        gunEquipped = false;
    }

    private void Update()
    {
        VerifyIfGunExists();
        gunSway = GetComponentInChildren<GunMovementController>();

        if(gunEquipped)
        {
            gunSway.SetGunMovement(inputController.playerOnFootMove.view.ReadValue<Vector2>());
        }
    }

    public void setLook(Vector2 mouseInput)
    {
        xRot -= (mouseInput.y * Time.deltaTime) * mouseSensitivity;
        xRot = Mathf.Clamp(xRot, minRotationX, maxRotationX);

        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        transform.Rotate(Vector3.up * (mouseInput.x * Time.deltaTime) * mouseSensitivity);
    }


    private bool VerifyIfGunExists()
    {
        if(gunController.isEquipped)
        {
            return gunEquipped = true;
        }

        return gunEquipped = false;
    }
}
