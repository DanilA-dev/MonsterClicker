using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float borderTemp;

    [Header("Components Ref's")]
    [SerializeField] private Camera cam;

    [Header("Camera Bounds")]
    [SerializeField] private Vector2 boundsMax;
    [SerializeField] private Vector2 boundsMin;

    private Vector3 mousePos;

    private void LateUpdate()
    {
        CameraDrag();
    }

    private void CameraDrag()
    {

    }

}
