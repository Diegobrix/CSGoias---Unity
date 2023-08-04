using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunPickUp : InteractionsMessage, IInteractable
{
    private Transform player;
    private Gun gunController;

    private GameObject gun;
    public void Awake()
    {        
        msg = "Pegar Arma";
        player = GameObject.Find("Player_Hand").transform;
    }

    public void Interact()
    {
        PickGun();
    }

    private void PickGun()
    {
        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.GetComponent<BoxCollider>().enabled = false;

        transform.position = player.position;
        transform.rotation = player.rotation;
        transform.SetParent(player);
    }
}
