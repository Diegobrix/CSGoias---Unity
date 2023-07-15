using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour, IInteractable
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float maxRayLength = 5f;
    [SerializeField] private LayerMask mask;

    private void Awake() {
        playerCamera = Camera.main;
        mask = LayerMask.GetMask("InteractableElement");
    }

    private void Update() {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxRayLength);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, maxRayLength, mask))
        {
            IInteractable hitObject = hitInfo.transform.GetComponent<IInteractable>();

            if(hitObject == null)
            {
                return;
            }

            hitObject.Interact();
        }
    }

    public void Interact()
    {
        //Chamar função de interação 
    }
}
