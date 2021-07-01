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
        //CameraDrag();
        MoveCam();
    }

    private void MoveCam()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(0))
        {
            var t = mousePos - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += t * Time.deltaTime;
        }
    }

    private void CameraDrag()
    {
        if(Input.mousePosition.y > Screen.height)
        {
            Move(Vector3.forward);
        }
        else if(Input.mousePosition.y < Screen.height)
        {
            Move(Vector3.back);
        }
        else if(Input.mousePosition.x > Screen.width)
        {
            Move(Vector3.right);
        }
        else if(Input.mousePosition.x < Screen.width)
        {
            Move(Vector3.left);
        }
    }

    private void Move(Vector3 moveDir)
    {
        cam.transform.Translate(moveDir * Time.deltaTime, Space.World);
    }

}
