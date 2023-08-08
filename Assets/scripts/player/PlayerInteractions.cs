using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour, IInteractable
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float maxRayLength = 5f;
    [SerializeField] private LayerMask mask;
    private PlayerUI ui;
    private InputController inputController;

    public GunParamsController gunParams;

    private void Awake()
    {
        inputController = GetComponent<InputController>();
        playerCamera = Camera.main;
        ui = GetComponent<PlayerUI>();
        mask = LayerMask.GetMask("InteractableElement");
    }

    private void Update()
    {
        ui.SetText(string.Empty);

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxRayLength);

        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, maxRayLength, mask))
        {
            IInteractable hitObj = hitInfo.collider.GetComponent<IInteractable>();
            Gun gun = hitInfo.collider.GetComponent<Gun>();

            if(gun != null)
            {
                ui.SetText($"Pegar - {gunParams.guns[gun.gunId].gunName}");
            }

            if(inputController.playerOnFootMove.interact.triggered)
            {
                hitObj.Interact();
            }
        }
    }
}
