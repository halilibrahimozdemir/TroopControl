using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UnitOptions : MonoBehaviour
{
    [SerializeField] private List<UnitController> selectedUnits;

    [SerializeField] private GameManager _gameManager;

    [SerializeField] private GameObject _unitOptions;
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private Slider _stoppingDistanceSlider;
    [SerializeField] private Text _minSpeedValue;
    [SerializeField] private Text _maxSpeedValue;
    [SerializeField] private Text _minStoppingValue;
    [SerializeField] private Text _maxStoppingValue;

    [SerializeField] private GameObject _displayWindow;
    [SerializeField] private Text _displayUnitName;
    [SerializeField] private Text _displayUnitSpeed;
    [SerializeField] private Text _displayUnitStoppingDistance;
    // Start is called before the first frame update
    void Start()
    {
        _minSpeedValue.text = _speedSlider.minValue.ToString();
        _maxSpeedValue.text = _speedSlider.maxValue.ToString();
        _minStoppingValue.text = _stoppingDistanceSlider.minValue.ToString();
        _maxStoppingValue.text = _stoppingDistanceSlider.maxValue.ToString();
        _displayWindow.SetActive(false);
        _unitOptions.SetActive(false);
        selectedUnits = _gameManager.SelectedUnits;
    }

    // Update is called once per frame
    void Update()
    {
        selectedUnits = _gameManager.SelectedUnits;
        if (selectedUnits.Count>=1)
        {
            if (!_unitOptions.activeInHierarchy)
            {
                _unitOptions.SetActive(true);
            }
            
            if (selectedUnits.Count == 1) // sadece bir birim seçtiysek özelliklerini gösteriyoruz
            {
                _displayWindow.SetActive(true);
                _displayUnitName.text = selectedUnits[0].name;
                _displayUnitSpeed.text = selectedUnits[0].GetComponent<NavMeshAgent>().speed.ToString();
                _displayUnitStoppingDistance.text =
                    selectedUnits[0].GetComponent<NavMeshAgent>().stoppingDistance.ToString();
                
            }
            else // birden fazla seçtiysek birim türünü ve sayılarını gösteriyoruz
            {
                _displayWindow.SetActive(false);
            }
        }
        else
        {
            _unitOptions.SetActive(false);
        }
    }

    public void SpeedChange()
    {
        if (selectedUnits.Count >= 1)
        {
            foreach (var selectedUnit in selectedUnits)
            {
                if (selectedUnit.GetComponent<NavMeshAgent>())
                {
                    selectedUnit.GetComponent<NavMeshAgent>().speed = _speedSlider.value;
                } 
            }
           
        }
    }

    public void StoppingDistanceChange()
    {
        if (selectedUnits.Count >= 1)
        {
            foreach (var selectedUnit in selectedUnits)
            {
                if (selectedUnit.GetComponent<NavMeshAgent>())
                {
                    selectedUnit.GetComponent<NavMeshAgent>().stoppingDistance = _stoppingDistanceSlider.value;
                } 
            }
           
        }
    }
}
