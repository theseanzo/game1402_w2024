using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Private Variables
	Rigidbody2D rb;
	Vector2 movement, mousePosition;
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
		rb = GetComponent<Rigidbody2D>();
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
		movement = movementInput;
		movement.Normalize();
	}
	public void MouseAim(Vector2 mousePos)
	{
		mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
	}
	public void Shoot()
	{
		weapon?.Shoot(rb.velocity);
	}
	// Update is called once per frame
	void Update()
	{
		
	}

	private void FixedUpdate() 
	{
		rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
		Vector2 lookDirection = mousePosition - rb.position;
		lookDirection.Normalize();
		float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;



	}
}
