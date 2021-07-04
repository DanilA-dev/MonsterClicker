using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float borderTemp;
    [SerializeField] private float speed;

    [SerializeField] private Vector3 startPos;

    [SerializeField] private Vector2 limitX;
    [SerializeField] private Vector2 limitZ;


    private Vector3 camPos;


    private void Start()
    {
        transform.position = startPos;
    }

    private void LateUpdate()
    {
        camPos = transform.position;

        Movement();
    }

  

    private void Movement()
    {
        if(Input.mousePosition.y >= Screen.height - borderTemp)
        {
            camPos.z += speed * Time.deltaTime;
        }
        else if(Input.mousePosition.y <= borderTemp)
        {
            camPos.z -= speed * Time.deltaTime;
        }
        else if(Input.mousePosition.x >= Screen.width - borderTemp)
        {
            camPos.x += speed * Time.deltaTime;
        }
        else if(Input.mousePosition.x <= borderTemp)
        {
            camPos.x -= speed * Time.deltaTime;
        }

        Clamp();
    }

    private void Clamp()
    {
        camPos.x = Mathf.Clamp(camPos.x, limitX.x, limitX.y);
        camPos.z = Mathf.Clamp(camPos.z, limitZ.x, limitZ.y);
        transform.position = camPos;
    }
   

}
