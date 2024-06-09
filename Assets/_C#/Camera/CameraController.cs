using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] CameraViewInfo viewInfo;

    new Camera camera;

    Transform currentTarget;
    CameraViewInfo currentProperties;

    Vector3 targetPos;
    Vector3 targetRotation;
    Vector3 positionVelocity = Vector3.zero;
    Quaternion rotationVelocity = Quaternion.identity;
    float fovVelocity = 0f;

    float smoothTime;
    float targetSmoothTime;

    float SmoothTime
    {
        get
        {
            if (Mathf.Approximately(targetSmoothTime, smoothTime))
                return smoothTime;
            else
            {
                smoothTime = Mathf.Lerp(smoothTime, targetSmoothTime, 250 * Time.deltaTime);
                return smoothTime;
            }
        }
        set => targetSmoothTime = value;
    }

    private void Awake()
    {
        camera = GetComponent<Camera>();
        currentProperties = viewInfo;
        currentTarget = target;
        smoothTime = currentProperties.SmoothTime;
    }

    private void Start()
    {
        transform.position = targetPos;
        transform.eulerAngles = targetRotation;
    }

    private void LateUpdate()
    {
        // calculate the new pos and rot
        CalculateValues();

        // set the vallues 
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref positionVelocity, SmoothTime);
        transform.rotation = QuaternionUtil.SmoothDamp(transform.rotation, Quaternion.Euler(targetRotation), ref rotationVelocity, SmoothTime);
    }

    private void CalculateValues()
    {
        // set the size of the camera base on render mode
        if (!camera.orthographic)
            camera.fieldOfView = Mathf.SmoothDamp(camera.fieldOfView, currentProperties.Fov, ref fovVelocity, currentProperties.SmoothTime);
        else
            camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, currentProperties.Fov, ref fovVelocity, currentProperties.SmoothTime);

        // calculate the values
        targetPos = currentTarget.position;
        Vector3 positionOffset = currentProperties.PositionSpace == Space.World ? currentProperties.PositionOffset :
            currentProperties.PositionOffset.x * currentTarget.right + currentProperties.PositionOffset.y * currentTarget.up + currentProperties.PositionOffset.z * currentTarget.forward;
        targetPos += positionOffset;
        targetRotation = currentProperties.RotationSpace == Space.World ? currentProperties.Rotation : currentProperties.Rotation + currentTarget.eulerAngles;
    }
}
