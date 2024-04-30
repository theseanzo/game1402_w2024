using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
/// <summary>
/// This is where you will spend a lot of the time in Lecture 1.
/// </summary>
public class PlayerController : MonoBehaviour
{
    //This is a standard 3D player controller
    AnimatorController _animatorController;
    Vector3 _moveDirection;
    Transform _cameraObject;
    Rigidbody _rb;
    private GroundCheck _groundCheck;
    /// <summary>
    /// This will be their first time seeing headers
    /// </summary>
    [Header("Movement")]
    [SerializeField]
    private float rotationSpeed = 15f;
    [SerializeField]
    float walkSpeed = 1.5f;
    [SerializeField]
    float runSpeed = 5f;
    [SerializeField]
    float sprintSpeed = 7f;
    

    [Header("Jump info")]
    [SerializeField]
    float jumpForce = 20f;

    [Header("Input")]
    private float _xMovement;
    private float _yMovement;
    private float _movementAmount;
    private float _cameraMovementX;
    private float _cameraMovementY;
    
    bool _isSprinting;

    

    SkinnedMeshRenderer _meshRenderer;
    private void Awake()
    {
        _animatorController = GetComponent<AnimatorController>(); //this grabs the AnimatorController
        _meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();//remember this when dealing with 3d models as they typically do not have the mesh renderer in the same place as where you put all of your animators, scripts, etc 
        _rb = GetComponent<Rigidbody>();
        _groundCheck = GetComponent<GroundCheck>();
        _cameraObject = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked; //get rid of the cursor
        Cursor.visible = false;
    }
    private void Start()
    {
        StartCoroutine(ChangePlayerColor());
    }
    /// <summary>
    /// This is the first coroutine example I show. Feel free to show something different, but I feel it helps them with their first assignment
    /// </summary>
    /// <returns></returns>
    IEnumerator ChangePlayerColor()
    {
        float alpha = 0.0f;
        bool upOrDown = true;
        while (true)
        {
            alpha += 0.005f * (upOrDown ? 1f : -1f);
            if (alpha >= 1.0f || alpha <= 0.0f)
                upOrDown = !upOrDown;
            _meshRenderer.material.SetColor("_Color", Color.white * alpha);
            yield return new WaitForFixedUpdate();
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        _animatorController.UpdateMovementValues(0, _movementAmount, _isSprinting);
    }
    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
        _groundCheck.Check(); //check for grounded
    }
    private void HandleMovement()
    {
        Vector3 moveDirection = _cameraObject.forward * _yMovement;
        moveDirection += _cameraObject.right * _xMovement;
        moveDirection.Normalize();
        moveDirection.y = 0;
        if (_isSprinting)
        {
            moveDirection = moveDirection * sprintSpeed;
        }
        else
        {
            if (_movementAmount >= 0.5f)
            {
                moveDirection = moveDirection * runSpeed;
            }
            else
            {
                moveDirection = moveDirection * walkSpeed;
            }
        }
        moveDirection.y = _rb.velocity.y;
        _rb.velocity = moveDirection;
    }
    /// <summary>
    /// This function should give them a lot of trouble. It will help them understand how you make a character face a particular direction using quaternions. It also gives them the opportunity to use Slerp for (potentially) the first time.
    /// </summary>
    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = _cameraObject.forward * _yMovement;
        targetDirection = targetDirection + _cameraObject.right * _xMovement;
        targetDirection.Normalize();
        targetDirection.y = 0;
        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = playerRotation;
    }

    public void HandleMovementInput(Vector2 movement)
    {
        _xMovement = movement.x;
        _yMovement = movement.y;
        _movementAmount = Mathf.Abs(_xMovement) + Mathf.Abs(_yMovement);

    }
    public void HandleSprintInput(bool sprint)
    {
        _isSprinting = sprint;
    }
    public void HandleJumpInput()
    {
        if (_groundCheck.IsGrounded)
        {
            Vector3 velocity = _rb.velocity;
            velocity.y = jumpForce; //change our y velocity to be whatever we want it to be for jumping up
            _rb.velocity = velocity; //reattach that to our rigid body
            _groundCheck.DisableTemporarily(); //we disable this temporarily so that ground checks don't trigger as soon as we leave the air.
        }
    }

}
