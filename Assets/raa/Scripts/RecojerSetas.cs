using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Random = UnityEngine.Random;

public class RecojerSetas : MonoBehaviour
{
    public event Action<GameObject> objectSpawned;

    public List<GameObject> Inventario = new List<GameObject>();
    string setas;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                setas = Hit.transform.name;
                switch (setas) //switch que busca las diferentes setas
                {
                    case "Leccinum":
                        //action --> añadirlo en la lista inventario
                        Debug.Log("le has dado a Orange Bolet");
                        break;
                    case "Amanita rubescensA":
                        //action
                        Debug.Log("le has dado a una Blusher");
                        break;
                    case "Biporus_a":
                        //action
                        Debug.Log("le has dado a un champiñón");
                        break;
                    case "Musmire":
                        //action
                        Debug.Log("le has dado a la roja");
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void DestroyandKeep(GameObject newSeta)
    {
        AddMushroom(newSeta);
        Debug.Log(newSeta.name);
    }
    private void AddMushroom(GameObject newSeta)
    {
        //objectSpawned.
        Inventario.Add(newSeta);
    }


    private void NameDestroy()
    {
        
    }
}
