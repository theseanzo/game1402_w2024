using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //This is a standard 3D player controller
    AnimatorController animatorController;
    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody rb;

    [Header("Movement")]
    [SerializeField]
    private float rotationSpeed = 15f;
    [SerializeField]
    float walkSpeed = 1.5f;
    [SerializeField]
    float runSpeed = 5f;
    [SerializeField]
    float sprintSpeed = 7f;

    [Header("Falling")]
    [SerializeField]
    float rayCastHeightOffset = 0.1f;
    [SerializeField]
    LayerMask groundLayer;

    [Header("Jump info")]
    [SerializeField]
    float jumpForce = 20f;

    [Header("Input")]
    private float xMovement;
    private float yMovement;
    private float movementAmount;
    private float cameraMovementX;
    private float cameraMovementY;

    bool isGrounded = true;
    bool isJumping;
    bool isSprinting;


    float inAirTimer;

    private void Awake()
    {
        animatorController = GetComponent<AnimatorController>(); //this grabs the AnimatorController
        rb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
    private void LateUpdate()
    {
        // GroundCheck();
    }
    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }
    private void HandleInput()
    {
        HandleMovementInput();
        HandleSprintInput(); //we handle sprint input as well
        HandleJumpInput();

    }
    private void GroundCheck() //this is where we figure out if we are on the ground or not
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffset;

        if (!isGrounded)
        {
            if (Physics.SphereCast(rayCastOrigin, 0.5f, -Vector3.up, out hit, 0.5f, groundLayer))
            {
                isGrounded = true;
            }
        }

    }
    private void HandleMovement()
    {
        Vector3 moveDirection = cameraObject.forward * yMovement;
        moveDirection += cameraObject.right * xMovement;
        moveDirection.Normalize();
        moveDirection.y = 0;
        if (isSprinting)
        {
            moveDirection = moveDirection * sprintSpeed;
        }
        else
        {
            if (movementAmount >= 0.5f)
            {
                moveDirection = moveDirection * runSpeed;
            }
            else
            {
                moveDirection = moveDirection * walkSpeed;
            }
        }
        moveDirection.y = rb.velocity.y;
        rb.velocity = moveDirection;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * yMovement;
        targetDirection = targetDirection + cameraObject.right * xMovement;
        targetDirection.Normalize();
        targetDirection.y = 0;
        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = playerRotation;
    }

    private void HandleMovementInput()
    {
        xMovement = Input.GetAxis("Horizontal");
        yMovement = Input.GetAxis("Vertical");
        movementAmount = Mathf.Abs(xMovement) + Mathf.Abs(yMovement);
        animatorController.UpdateMovementValues(0, movementAmount, isSprinting);
        
    }
    private void HandleSprintInput()
    {
        if (Input.GetButton("Sprint")) //Remember: GetKey, GetButton, etc. is for a button that's held down. GetKeyDown, GetButtonDown, etc. only trigger when the button is held down
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }
    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce; //change our y velocity to be whatever we want it to be for jumping up
            rb.velocity = velocity; //reattach that to our rigid body
            isGrounded = false; //inform that we are no longer on the ground
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isGrounded = false;
    }
}
