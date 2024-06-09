using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// encapsulated the view data for camera 

[System.Serializable]
public class CameraViewInfo 
{
    [SerializeField] Space positionSpace;
    [SerializeField] Vector3 positionOffset;
    [SerializeField] Space rotationSpace;
    [SerializeField] Vector3 rotation;
    [SerializeField] float fov;
    [SerializeField] float smoothTime;

    public CameraViewInfo(CameraViewInfo reference)
    {
        positionSpace = reference.positionSpace;
        positionOffset = reference.positionOffset;
        rotationSpace = reference.rotationSpace;
        rotation = reference.rotation;
        fov = reference.fov;
        smoothTime = reference.smoothTime;
    }

    public Space PositionSpace { get => positionSpace; set => positionSpace = value; }
    public Vector3 PositionOffset { get => positionOffset; set => positionOffset = value; }
    public Space RotationSpace { get => rotationSpace; set => rotationSpace = value; }
    public Vector3 Rotation { get => rotation; set => rotation = value; }
    public float Fov { get => fov; set => fov = value; }
    public float SmoothTime { get => smoothTime; set => smoothTime = value; }
}
