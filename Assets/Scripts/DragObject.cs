using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;

    public bool isThereAnObject;

    public LayerMask layerMask;

    private bool _isSelected;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit,100f,layerMask.value))
            {
                isThereAnObject = true;
            }
            else
            {
                isThereAnObject = false;
                _isSelected = false;
            } 
        }
    }

    private void OnMouseDown()
    {
        _isSelected = true;
        
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseUp()
    {
        _isSelected = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if (isThereAnObject && _isSelected)
        {
            transform.position = GetMouseWorldPos() + mOffset; 
        }
    }
}
