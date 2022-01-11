using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleSelectBox : MonoBehaviour
{
    [SerializeField]
    private RectTransform _selectSquareImage;

    [SerializeField]private Vector3 _startPos;
    private Vector3 _endPos;

    [SerializeField]private GameManager _gameManager;

    private Vector3 _mousePos1;
    private Vector3 _mousePos2;

    [SerializeField]private UnitController[] _selectableUnits;
    void Start()
    {
        _selectSquareImage.gameObject.SetActive(false);
        _selectableUnits = GameObject.FindObjectsOfType<UnitController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonUp(1))
        {
            _selectSquareImage.gameObject.SetActive(false);
            _mousePos2 = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            if (_mousePos1 != _mousePos2)
            {
                SelectUnits();
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            _mousePos1 = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                _startPos = hit.point;
            }
        }
        else if (Input.GetMouseButton(1))
        {
            if (!_selectSquareImage.gameObject.activeInHierarchy)
            {
                _selectSquareImage.gameObject.SetActive(true);
            }

            _endPos = Input.mousePosition;

            Vector3 squareStart = Camera.main.WorldToScreenPoint(_startPos);
            squareStart.z = 0f;

            Vector3 center = (squareStart + _endPos) / 2f;

            _selectSquareImage.position = center;
            
            float sizeX = Mathf.Abs(squareStart.x - _endPos.x);
            float sizeY = Mathf.Abs(squareStart.y - _endPos.y);

            _selectSquareImage.sizeDelta = new Vector2(sizeX, sizeY);
        }
    }
    
    private void SelectUnits()
    {
        //Null hale gelen veya silinen unitleri temizlemek için
        List<UnitController> remUnits = new List<UnitController>();

        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            if (_gameManager.SelectedUnits != null)
            {
                Debug.Log("shifte basılmadığı için seçim varsa iptal edildi");
                _gameManager.SelectedUnits.Clear();
            }

            Rect selectRect = new Rect(_mousePos1.x, _mousePos1.y, _mousePos2.x-_mousePos1.x,
                _mousePos2.y-_mousePos1.y);

            foreach (var selectableUnit in _selectableUnits)
            {
                if (selectRect.Contains(Camera.main.WorldToViewportPoint(selectableUnit.transform.position), true))
                {
                    if (_gameManager.SelectedUnits != null)
                    {
                        _gameManager.SelectedUnits.Add(selectableUnit);
                    }
                    else
                    {
                        Debug.Log("selectedUnits listesi null");
                    }
                } 
            }
        }
        else
        {
            Rect selectRect = new Rect(_mousePos1.x, _mousePos1.y, _mousePos2.x-_mousePos1.x,
                _mousePos2.y-_mousePos1.y);

            foreach (var selectableUnit in _selectableUnits)
            {
                if (selectRect.Contains(Camera.main.WorldToViewportPoint(selectableUnit.transform.position), true))
                {
                    if (_gameManager.SelectedUnits != null)
                    {
                        if (!_gameManager.SelectedUnits.Contains(selectableUnit))
                        {
                            _gameManager.SelectedUnits.Add(selectableUnit); 
                        }
                    }
                    else
                    {
                        Debug.Log("selectedUnits listesi null");
                    }
                } 
            }
        }
        
        
    }

    private void ClearSelection()
    {
        
    }
}
