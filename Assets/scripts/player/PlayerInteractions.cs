using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour, IInteractable
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float maxRayLength = 5f;
    [SerializeField] private LayerMask mask;
    private PlayerUI ui;

    private void Awake() {
        playerCamera = Camera.main;
        ui = GetComponent<PlayerUI>();
        mask = LayerMask.GetMask("InteractableElement");
    }

    private void Update() {
        ui.SetText(string.Empty);

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxRayLength);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, maxRayLength, mask))
        {
            IInteractable hitObject = hitInfo.transform.GetComponent<IInteractable>();
            InteractionsMessage hitMessage = hitInfo.collider.GetComponent<InteractionsMessage>();

            if(hitObject == null)
            {
                return;
            }

            if(hitMessage != null)
            {
                ui.SetText(hitMessage.msg);
            }
            
            hitObject.Interact();
        }
    }

    public void Interact()
    {
        //Chamar função de interação 
    }
}
