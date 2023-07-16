using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactionTextAlert;

     public void SetText(string text)
     {
        interactionTextAlert.text = text;
     }
}
