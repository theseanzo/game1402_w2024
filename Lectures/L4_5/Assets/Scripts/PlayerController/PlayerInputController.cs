using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
	private PlayerController _playerController;
	PlayerInput _playerInput;

	private void OnEnable()
	{
		_playerController = GetComponent<PlayerController>();
		if (_playerInput == null)
		{
			_playerInput = new PlayerInput();
			_playerInput.PlayerMovement.Movement.performed += i => _playerController.HandleMovementInput(i.ReadValue<Vector2>());
			_playerInput.PlayerMovement.AimMouse.performed += i => _playerController.MouseAim(i.ReadValue<Vector2>());
			_playerInput.PlayerActions.Shoot.started += i => _playerController.Shoot();

			
		}
		_playerInput.Enable();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
