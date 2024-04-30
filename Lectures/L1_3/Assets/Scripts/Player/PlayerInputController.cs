using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerController _playerController;
    private CameraController _cameraController;
    PlayerInput playerInput;

    private void OnEnable()
    {
        _playerController = GetComponent<PlayerController>();
        _cameraController = FindObjectOfType<CameraController>(); //this is not a good function to normally use unless it's a singleton, because you can typically have more than one object in a scene
        if (playerInput == null)
        {
            playerInput = new PlayerInput();
            playerInput.PlayerMovement.Movement.performed += i => _playerController.HandleMovementInput(i.ReadValue<Vector2>());
            playerInput.PlayerMovement.Camera.performed += i => _cameraController.RotateCamera(i.ReadValue<Vector2>());
            playerInput.PlayerActions.Sprint.performed += i => _playerController.HandleSprintInput(true);
            playerInput.PlayerActions.Sprint.canceled += i => _playerController.HandleSprintInput(false);
            playerInput.PlayerActions.Jump.started += i => _playerController.HandleJumpInput();
            //a lambda function is of the type (parameters)=>one_line_function;
            //if multiple lines (parameters)=>{}


        }
        playerInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
