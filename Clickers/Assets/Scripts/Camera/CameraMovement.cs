using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private SimpleTweenAnimation animations = new SimpleTweenAnimation();

    [SerializeField] private float borderTemp;
    [SerializeField] private float speed;

    private Vector3 startPos;
    private Quaternion startRot;

    private void Reset()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        startRot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z , 0f);
    }


    private void Start()
    {
        transform.position = startPos;
        transform.rotation = startRot;
    }

    private void LateUpdate()
    {
        CameraDrag();
    }

  

    private void CameraDrag()
    {
        if(Input.mousePosition.y >= Screen.height - borderTemp)
        {
            Move(Vector3.forward);
        }
        else if(Input.mousePosition.y <= borderTemp)
        {
            Move(Vector3.back);
        }
        else if(Input.mousePosition.x >= Screen.width - borderTemp)
        {
            Move(Vector3.right);
        }
        else if(Input.mousePosition.x <= borderTemp)
        {
            Move(Vector3.left);
        }
    }

    private void Move(Vector3 moveDir)
    {
        transform.Translate(moveDir * speed * Time.deltaTime, Space.World);
    }

}
