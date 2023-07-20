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
    private Gun gunController;

    // Start is called before the first frame update
    void Awake()
    {
        map = new ActionsMap();
        playerOnFootMove = map.playerMoves1;
        movementControl = GetComponent<PlayerMovementController>();
        lookController = GetComponent<PlayerLookController>();
        gunController = GameObject.Find("Gun").GetComponent<Gun>();

        playerOnFootMove.jump.performed += ctx => movementControl.Jump();
        playerOnFootMove.shoot.performed += ctx => gunController.Shoot();
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
