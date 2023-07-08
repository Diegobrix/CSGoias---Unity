using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private ActionsMap map;
    private ActionsMap.PlayerMoves1Actions playerOnFootMove;

    private PlayerMovementController movementControl;

    // Start is called before the first frame update
    void Awake()
    {
        map = new ActionsMap();
        playerOnFootMove = map.playerMoves1;
        movementControl = GetComponent<PlayerMovementController>();
    }

    private void FixedUpdate() {
        movementControl.setPlayerMovement(playerOnFootMove.movement.ReadValue<Vector2>());
    }

    private void OnEnable() {
        playerOnFootMove.Enable();    
    }

    private void OnDisable() {
        playerOnFootMove.Disable();
    }
}
