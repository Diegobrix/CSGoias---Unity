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

    private int pass; 
    private void UseKeypad()
    {
        pass = 321;
        isOpen = true;
        msg = string.Empty;

        cellDoor.GetComponent<Animator>().SetBool("IsOpen", isOpen);
    }
}
