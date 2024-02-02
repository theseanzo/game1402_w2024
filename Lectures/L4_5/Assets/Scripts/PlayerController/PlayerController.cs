using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Private Variables
	Rigidbody2D rb;
	Vector2 movement, mousePosition;
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
	private Gun weapon;
	
	#endregion
	private void Awake()
	{


	}
	// Start is called before the first frame update
	void Start()
	{
		
	}
	public void HandleMovementInput(Vector2 movementInput)
	{
		
	}
	public void MouseAim(Vector2 mousePos)
	{
		
	}
	public void Shoot()
	{
		
	}
	// Update is called once per frame
	void Update()
	{
		
	}

	private void FixedUpdate() 
	{

	}
}
