using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Random = UnityEngine.Random;
using UnityEditor;

public class RecojerSetas : MonoBehaviour
{
    [SerializeField] List<string[]> Inventary = new List<string[]>();
    //Leccinum  [0][x]
    //Amanita   [1][x]
    //Biporus   [2][x]
    //Musmire   [3][x]
    //Con esta lista de arrays, podemos guardar la cantidad de setas de cada tipo
    public string[] leccinum;
    public string[] amanita;
    public string[] biporus;
    public string[] musmire;

    private int leccinum_lenght;
    private int amanita_lenght;
    private int biporus_lenght ;
    private int musmire_lenght;

    Vector3 tipoEntrada = Vector3.zero;

    void Start()
    {
        Inventary.Add(leccinum);
        Inventary.Add(amanita);
        Inventary.Add(biporus);
        Inventary.Add(musmire);

        leccinum_lenght = 0;
        amanita_lenght = 0;
        biporus_lenght = 0;
        musmire_lenght = 0;
    }
    private void Update()
    {

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Creamos un rayo desde la posición del toque
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;

            //Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red, 3f);

            int capaSetas = LayerMask.GetMask("seta");

            if (Physics.Raycast(ray, out Hit, capaSetas))
            {

                //obtener el objeto que tenia el collider
                GameObject setaTocada = Hit.transform.gameObject;

                string name = setaTocada.name;

                if (name.Contains("Leccinum") || name.Contains("Amanita") || name.Contains("Biporus_a") || name.Contains("Musmire"))
                {
                    pickSeta(setaTocada);
                }

            }

        }
    }

    void pickSeta(GameObject seta)
    {
        Debug.Log("Has recogido: " + seta.name);
        if  (seta.name.Contains("Leccinum")) 
        {
            int i = leccinum_lenght;
            string[] newArray = new string[i+1];
            //spurce array, int sourceIndex, destination array, int destination index, lenght
            System.Array.Copy(leccinum, newArray, i);
            newArray[i] = seta.name;
            leccinum = newArray;

            leccinum_lenght++;
        }
        else if (seta.name.Contains("Amanita"))
        {
            int i = amanita_lenght;
            string[] newArray = new string[i + 1];
            //spurce array, int sourceIndex, destination array, int destination index, lenght
            System.Array.Copy(amanita, newArray, i);
            newArray[i] = seta.name;
            amanita = newArray;

            amanita_lenght++;
        }
        else if (seta.name.Contains("Biporus_a"))
        {
            int i = biporus_lenght;
            string[] newArray = new string[i + 1];
            //spurce array, int sourceIndex, destination array, int destination index, lenght
            System.Array.Copy(biporus, newArray, i);
            newArray[i] = seta.name;
            biporus = newArray;

            biporus_lenght++;
        }
        else if (seta.name.Contains("Musmire"))
        {
            int i = musmire_lenght;
            string[] newArray = new string[i + 1];
            //spurce array, int sourceIndex, destination array, int destination index, lenght
            System.Array.Copy(musmire, newArray, i);
            newArray[i] = seta.name;
            musmire = newArray;

            musmire_lenght++;
        }

        Destroy(seta);
    }

}
