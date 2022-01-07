using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleSelectBox : MonoBehaviour
{
    [SerializeField]
    private RectTransform _selectSquareImage;

    [SerializeField]private Vector3 _startPos;
    private Vector3 _endPos;
    
    void Start()
    {
        _selectSquareImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonUp(1))
        {
            _selectSquareImage.gameObject.SetActive(false);
        }
        
        if (Input.GetMouseButtonDown(1))
        {
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
}
