using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunPickUp : InteractionsMessage, IInteractable
{
    private Transform playerHand;
    private Transform player;
    private Gun gunController;

    private GameObject gun;
    public InputController inputController;
    
    private Rigidbody gunRigidbody;
    private BoxCollider gunBoxCollider;
    
    public void Awake()
    {        
        msg = "Pegar Arma";
        player = GameObject.Find("Player").transform;
        playerHand = GameObject.Find("Player_Hand").transform;
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
        }
    }

    private void SetGunPosition()
    {
        transform.position = playerHand.position;
        transform.rotation = playerHand.rotation;
        transform.SetParent(player);
    }

    private void SetShoot()
    {
        inputController.playerOnFootMove.shoot.performed += ctx => gunController.Shoot();
    }
}
