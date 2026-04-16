using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Random = UnityEngine.Random;

public class RecojerSetas : MonoBehaviour
{

    public List<string> Inventario = new List<string>();

    Vector3 tipoEntrada = Vector3.zero;



    private void Update()
    {

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)

        if (Input.GetMouseButtonDown(0))
        {
            //Creamos un rayo desde la posición del toque
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red, 3f);

            int capaSetas = LayerMask.GetMask("seta");

            if (Physics.Raycast(ray, out Hit, capaSetas))
            {

                //obtener el objeto que tenia el collider

                GameObject setaTocada = Hit.transform.gameObject;

                string name = setaTocada.name;

                if (name.Contains("Leccinum") || name.Contains("Amanita") || name.Contains("Biporus_a") || name.Contains("Musmire") )
                {
                    pickSeta(setaTocada);
                }
                
            }

        }
    }

    void pickSeta(GameObject seta)
    {
        Debug.Log("Has recogido: " + seta.name);

        Destroy(seta);
    }

}
