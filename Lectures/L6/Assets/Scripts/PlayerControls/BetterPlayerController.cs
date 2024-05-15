using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Callbacks;
using UnityEngine;

public class BetterPlayerController : PlayerController
{
	#region Serializable Fields
	[Header("Jump")]
	[SerializeField]
	float  fallMultiplier = 2.5f, lowJumpMultiplier = 2f, coyoteTime=.3f;
	[Header("Movement")]
	[SerializeField]
	float moveSmoothing = .01f;
	
	#endregion
	#region Private Variables
	float _lastGroundedTime;
	float _lastJumpTime;
	
	#endregion
	
	
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		groundCheck = GetComponent<GroundCheck>();
	}
	public override void HandleJump()
	{
		_lastJumpTime = Time.time;
		if(!isJumping && (groundCheck.IsGrounded || CheckCoyoteTime()))
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
			isJumping = true;
		}
			
	}
	public override void JumpReleased()
	{
		isJumping = false;
	}
	public override void Move(Vector2 movement)
	{
		this.movementVector.x = movement.x;
	}
	void Start()
	{
		
	}

	protected override void FixedUpdate()
	{
		if(groundCheck.IsGrounded)
		{
			_lastGroundedTime = Time.time;
		}
		float moveSpeed = Mathf.Lerp(rb.velocity.x, movementVector.x * speed, moveSmoothing);
		if(rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
		}
		else if (rb.velocity.y > 0 && !isJumping)
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
		}
		rb.velocity = new Vector2(movementVector.x * speed, rb.velocity.y);
	}
	bool CheckCoyoteTime()
	{
		return Time.time - _lastGroundedTime <= coyoteTime;
	}
}
