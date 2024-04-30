
using UnityEngine;
/// <summary>
/// Yes, I do not teach cinemachine right off the bat. The reason for this is that I want students to get the camera logic right for their first assignment, and thus get some practice with 3D transforms.
/// </summary>
public class CameraController : MonoBehaviour
{
    private Vector3 _cameraFollowVelocity = Vector3.zero;
    Transform _targetTransform;
    [SerializeField]
    private float cameraFollowSpeed = .2f;
    [SerializeField]
    private float cameraLookSpeed = 2f;
    [SerializeField]
    private float cameraPivotSpeed = 2f;
    [SerializeField]
    float minPivotAngle = -35;
    [SerializeField]
    float maxPivotAngle = 35;
    [SerializeField]
    Transform cameraPivot;


    private float _lookAngle = 0, _pivotAngle = 0;
    void Awake()
    {
        _targetTransform = FindObjectOfType<PlayerController>().transform;
    }
    private void HandleAllCameraMovement()
    {
        FollowTarget();
    }
    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, _targetTransform.position, ref _cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;
    }
    /// <summary>
    /// Pretty standard camera logic, but may be helpful to explain to people. Especially quaternions, as they will be very confused about them at this point.
    /// </summary>
    /// <param name="movement"></param>
    public void RotateCamera(Vector2 movement)
    {
        _lookAngle = _lookAngle + movement.x * cameraLookSpeed;
        _pivotAngle = _pivotAngle - (movement.y * cameraPivotSpeed);
        _pivotAngle = Mathf.Clamp(_pivotAngle, minPivotAngle, maxPivotAngle);
        Vector3 rotation = Vector3.zero;
        rotation.y = _lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;
        rotation = Vector3.zero;
        rotation.x = _pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }
    private void LateUpdate()
    {
        HandleAllCameraMovement();
    }
}
