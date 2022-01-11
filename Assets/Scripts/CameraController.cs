using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 10f;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;
   
    // Update is called once per frame
    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        if(Camera.current != null)
        {
            transform.position = new Vector3(xAxisValue + transform.position.x, transform.position.y,
                zAxisValue + transform.position.z);
        }

        if (Input.GetMouseButton(2))
        {
            if (Input.GetAxis("Mouse X")>0f)
            {
                currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
                currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
                transform.rotation=Quaternion.Euler(transform.rotation.x,currentRotation.x,0);
            }
            /*currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
            currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
            currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
            currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
            Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y,currentRotation.x,0);
            if (Input.GetMouseButtonDown(0))
                Cursor.lockState = CursorLockMode.Locked;*/  
        }
    }
}
