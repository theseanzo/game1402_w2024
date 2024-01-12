using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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


    // Start is called before the first frame update
    private void Awake()
    {
        animatorController = GetComponent<AnimatorController>();    
        rb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
    private void LateUpdate()
    {
        GroundCheck();
    }
    private void FixedUpdate()
    {
        
        HandleMovement();
        HandleRotation();
    }
    private void HandleInput()
    {
        HandleMovementInput();
        HandleJumpInput();

    }
    private void GroundCheck()
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
        
    }
    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
            isGrounded = false;
        }
    }
}
