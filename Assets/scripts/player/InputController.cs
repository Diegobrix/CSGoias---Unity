using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private ActionsMap map;
    public ActionsMap.PlayerMoves1Actions playerOnFootMove;

    private PlayerMovementController movementControl;
    private PlayerLookController lookController;

    // Start is called before the first frame update
    void Awake()
    {
        map = new ActionsMap();
        playerOnFootMove = map.playerMoves1;
        movementControl = GetComponent<PlayerMovementController>();
        lookController = GetComponent<PlayerLookController>();

        playerOnFootMove.jump.performed += ctx => movementControl.Jump();
    }

    private void FixedUpdate() {
        movementControl.SetPlayerMovement(playerOnFootMove.movement.ReadValue<Vector2>());
    }

    private void LateUpdate() {
        lookController.setLook(playerOnFootMove.view.ReadValue<Vector2>());
    }

    private void OnEnable() {
        playerOnFootMove.Enable();    
    }

    private void OnDisable() {
        playerOnFootMove.Disable();
    }
}
