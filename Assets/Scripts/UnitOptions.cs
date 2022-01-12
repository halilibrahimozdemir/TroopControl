using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField] private GameObject _displaySelectedSoldiers;
    [SerializeField] private GameObject _displaySelectedElites;
    [SerializeField] private Text _displaySelectedSoldiersQuantity;
    [SerializeField] private Text _displaySelectedElitesQuantity;
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
        _displaySelectedSoldiers.SetActive(false);
        _displaySelectedElites.SetActive(false);
        selectedUnits = _gameManager.SelectedUnits;
    }

    // Update is called once per frame
    void Update()
    {
        selectedUnits = _gameManager.SelectedUnits;
        if (selectedUnits.Count>=1)
        {
            int soldiersQuantity = 0;
            int elitesQuantity = 0;
            foreach (var selectedUnit in selectedUnits)
            {
                if (selectedUnit.type == "Soldier")
                {
                    soldiersQuantity++;
                }else if (selectedUnit.type == "Elite")
                {
                    elitesQuantity++;
                }
                else
                {
                    Debug.Log("Unity Type Hatası");
                }
            }

            if (soldiersQuantity > 0)
            {
                _displaySelectedSoldiers.SetActive(true);
                _displaySelectedSoldiersQuantity.text = soldiersQuantity.ToString();
            }
            else
            {
                _displaySelectedSoldiers.SetActive(false);
            }

            if (elitesQuantity > 0)
            {
                _displaySelectedElites.SetActive(true);
                _displaySelectedElitesQuantity.text = elitesQuantity.ToString();
            }
            else
            {
                _displaySelectedElites.SetActive(false);
            }


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
            _displaySelectedElites.SetActive(false);
            _displaySelectedSoldiers.SetActive(false);
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
