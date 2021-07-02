using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;

    public float borderTemp;
    public float speed;


    private void LateUpdate()
    {
        CameraDrag();
    }

  

    private void CameraDrag()
    {
        if(Input.mousePosition.y >= Screen.height - borderTemp)
        {
            Move(-Vector3.forward);
        }
        else if(Input.mousePosition.y <= borderTemp)
        {
            Move(-Vector3.back);
        }
        else if(Input.mousePosition.x >= Screen.width - borderTemp)
        {
            Move(-Vector3.right);
        }
        else if(Input.mousePosition.x <= borderTemp)
        {
            Move(-Vector3.left);
        }
    }

    private void Move(Vector3 moveDir)
    {
        transform.Translate(moveDir * speed * Time.deltaTime, Space.World);
    }

}
