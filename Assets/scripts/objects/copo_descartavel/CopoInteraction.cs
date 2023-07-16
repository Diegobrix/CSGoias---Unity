using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopoInteraction : MonoBehaviour, IInteractable
{
    private Camera playerPosition;
    private Rigidbody copoRigidbody;
    [SerializeField] private float hitForce = 1.5f;
    
    private void Awake() {
        playerPosition = Camera.main;
        copoRigidbody = GetComponent<Rigidbody>();
    }

    public void Interact()
    {
        BeThrown();
    }

    private void BeThrown()
    {
        copoRigidbody.AddForce((playerPosition.transform.forward * hitForce), ForceMode.Impulse);
    }
}
