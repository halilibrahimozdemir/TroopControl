using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleSelectionClick : MonoBehaviour
{
    private Vector3 _mousePos1;
    private Vector3 _mousePos2;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _mousePos1 = Camera.main.ScreenToViewportPoint(Input.mousePosition);  
        }

        if (Input.GetMouseButtonUp(1))
        {
            _mousePos2 = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            if (_mousePos1 != _mousePos2)
            {
                SelectUnits();
            }
        }
        
    }

    private void SelectUnits()
    {
        //Null hale gelen veya silinen unitleri temizlemek için
        List<UnitController> remUnits = new List<UnitController>();

        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            
        }
    }
}
