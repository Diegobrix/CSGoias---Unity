using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopoInteraction : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        BeThrown();
    }

    private void BeThrown()
    {
        Debug.Log("Fui embora");
    }
}
