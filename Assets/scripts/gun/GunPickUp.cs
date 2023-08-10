using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunPickUp : InteractionsMessage, IInteractable
{
    private Transform playerHand;
    private Transform player;
    private Gun gunController;
    private PlayerLookController lookController;

    private GameObject gun;
    public InputController inputController;
    
    private Rigidbody gunRigidbody;
    private BoxCollider gunBoxCollider;

    public GunMovementController gunMovementController;
    public bool isEquipped;

    
    public void Awake()
    { 
        player = GameObject.Find("Player").transform;
        playerHand = GameObject.Find("Player_Hand").transform;
        lookController = player.GetComponent<PlayerLookController>();

        isEquipped = false;
    }

    public void Interact()
    {
        PickGun();
    }

    private void PickGun()
    {
        gunRigidbody = transform.GetComponent<Rigidbody>();
        gunBoxCollider = transform.GetComponent<BoxCollider>();

        if(gunRigidbody != null)
        {
            gunRigidbody.isKinematic = true;
        }

        if(gunBoxCollider != null)
        {
            gunBoxCollider.enabled = false;
        }

        SetGunPosition();

        inputController = player.transform.GetComponent<InputController>();
        gunController = transform.GetComponent<Gun>();

        if(gunController != null)
        {
            SetShoot(); 
            EquipGun();
        }
    }

    private void SetGunPosition()
    {
        transform.position = playerHand.position;
        transform.rotation = playerHand.rotation;
        transform.SetParent(playerHand);
    }

    private void SetShoot()
    {
        inputController.playerOnFootMove.shoot.performed += ctx => gunController.Shoot();
    }

    public void EquipGun()
    {
        isEquipped = true;
    }
}
