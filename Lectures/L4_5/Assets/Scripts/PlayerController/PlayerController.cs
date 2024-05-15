using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Private Variables
	Rigidbody2D _rb;
	Vector2 _movement, _mousePosition;
	private Gun weapon;
	#endregion
	#region Serialize Fields
	[Header("Movement")]
	[SerializeField]
	private float rotationSpeed = 15f;
	[SerializeField]
	float moveSpeed = 5f;
	[Header("Weapons")]
	[SerializeField]
	private Gun gun;
	[SerializeField]
	private Transform gunLocation;
	
	
	#endregion
	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		if(gun && gunLocation) //recall that an "existence check" returns a boolean value (true or false) so if(gun && gunLocation) is saying "do gun and gun location exist?"
        {
			weapon = Instantiate(gun, gunLocation);
        }

	}
	// Start is called before the first frame update
	void Start()
	{
		
	}
	public void HandleMovementInput(Vector2 movementInput)
	{
		_movement = movementInput;
		_movement.Normalize();
	}
	public void MouseAim(Vector2 mousePos)
	{
		_mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
	}
	public void Shoot()
	{
		weapon?.Shoot(_rb.velocity);
	}
	// Update is called once per frame
	void Update()
	{
		
	}

	private void FixedUpdate() 
	{
		_rb.velocity = _movement * moveSpeed * Time.fixedDeltaTime;
		Vector2 lookDirection = _mousePosition - _rb.position;
		lookDirection.Normalize();
		float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
		_rb.rotation = angle;



	}
}
