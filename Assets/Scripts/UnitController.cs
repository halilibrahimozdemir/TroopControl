using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public Transform target;
    public string type;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        cam=Camera.main;
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (target)
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnMouseOver()
    {
        //Birimin üstüne sağ tıklandığında seçilmesi
        if (Input.GetMouseButtonDown(1))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (!_gameManager.SelectedUnits.Contains(this))
                {
                    _gameManager.SelectedUnits.Add(this);
                }
            }
            else
            {
                _gameManager.SelectedUnits.Clear();
                _gameManager.SelectedUnits.Add(this);
            }
        }
    }
}
