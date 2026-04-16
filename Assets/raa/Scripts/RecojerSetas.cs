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

    [SerializeField] GameObject setaLeccinum;
    [SerializeField] GameObject setaAmarita;
    [SerializeField] GameObject setaBiporus;
    [SerializeField] GameObject setaMusmire;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                setas = Hit.transform.name;
                switch (setas) //switch que busca las diferentes setas
                {
                    case "Leccinum":
                        //añadirlo en la lista inventario
                        Inventario.Add(setaLeccinum);
                        //pop-up de info?
                        Debug.Log("le has dado a Orange Bolet");
                        break;
                    case "Amanita rubescensA":
                        Inventario.Add(setaAmarita);
                        Debug.Log("le has dado a una Blusher");
                        break;
                    case "Biporus_a":
                        Inventario.Add(setaBiporus);
                        Debug.Log("le has dado a un champiñón");
                        break;
                    case "Musmire":
                        Inventario.Add(setaMusmire);
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
