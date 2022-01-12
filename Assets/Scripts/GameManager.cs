using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField]private List<UnitController> _selectedUnits;
   // [SerializeField]private UnitController _selectedUnit;
   //
   // public UnitController SelectedUnit
   // {
   //    get => _selectedUnit;
   //    set => _selectedUnit = value;
   // }
   public List<UnitController> SelectedUnits
   {
      get => _selectedUnits;
      set => _selectedUnits = value;
   }

   [SerializeField]private new Camera camera;

   private void Awake()
   {
      //_selectedUnits = new List<UnitController>();
   }

   private void Update()
   {
      //Sol tıklandığında
      if (Input.GetMouseButtonDown(0))
      {
         Ray ray = camera.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;
         
         if (Physics.Raycast(ray, out hit))
         {
            //Hedeflerden birine tıklandıysa ve seçilmiş birimlerimiz varsa
            if (hit.transform.tag == "Target" && _selectedUnits!=null)
            {
               Debug.Log("seçilen birimler için hedef belirlendi");

               foreach (var selectedUnit in _selectedUnits)
               {
                  selectedUnit.target = hit.transform;
               }
            }
            //Hedefe değil de başka bir yere tıklandıysa ya da seçilmiş birimimiz yoksa
            else if(hit.transform.gameObject.layer!=LayerMask.NameToLayer("UI"))
            {
               Debug.Log("seçim iptal edildi ya da birim seçmedin");
               if (_selectedUnits != null) _selectedUnits.Clear();
            }
         }
      }
   }
}
