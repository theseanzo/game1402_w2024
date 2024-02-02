using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
	private PlayerController playerController;
	PlayerInput playerInput;

	private void OnEnable()
	{
		playerController = GetComponent<PlayerController>();
		if (playerInput == null)
		{
			playerInput = new PlayerInput();
			playerInput.PlayerMovement.Movement.performed += i => playerController.HandleMovementInput(i.ReadValue<Vector2>());
			playerInput.PlayerMovement.AimMouse.performed += i => playerController.MouseAim(i.ReadValue<Vector2>());
			playerInput.PlayerActions.Shoot.started += i => playerController.Shoot();

			
		}
		playerInput.Enable();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
