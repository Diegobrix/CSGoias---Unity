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
    public Gun gunPicked;
    private GameObject gun;

    // Start is called before the first frame update
    void Awake()
    {
        map = new ActionsMap();
        playerOnFootMove = map.playerMoves1;
        movementControl = GetComponent<PlayerMovementController>();
        lookController = GetComponent<PlayerLookController>();

        gun = GameObject.Find("Gun");

        VerifyShootPossibility();

        playerOnFootMove.jump.performed += ctx => movementControl.Jump();
    }

    private void FixedUpdate() {
        movementControl.SetPlayerMovement(playerOnFootMove.movement.ReadValue<Vector2>());

        if(gunPicked == null)
        {
            VerifyShootPossibility();
        }
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

    private void VerifyShootPossibility()
    {
        
        if((gun.transform.parent != null) && (gun.transform.parent.gameObject.name == "Player_Hand"))
        {
            gunPicked = gun.GetComponent<Gun>();
        }

        if(gunPicked != null)
        {
            playerOnFootMove.shoot.performed += ctx => gunPicked.Shoot();
        }
    }
}
