using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadInteraction : InteractionsMessage, IInteractable
{
    [SerializeField] private GameObject cellDoor;
    private bool isOpen;

    public void Awake()
    {
        msg = "Digit Password";
        isOpen = false;
    }

     public void Interact()
    {
        UseKeypad();
    }

    private void UseKeypad()
    {
        isOpen = true;
        msg = string.Empty;

        cellDoor.GetComponent<Animator>().SetBool("IsOpen", isOpen);
    }
}
