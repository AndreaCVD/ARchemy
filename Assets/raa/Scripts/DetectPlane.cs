using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Random = UnityEngine.Random;

public class DetectPlane : MonoBehaviour
{
    //Plane Manager
    [SerializeField] private ARPlaneManager planeManager;
    [Header("Lista de Setas Disponibles")]
    public List<GameObject> TiposSetas = new List<GameObject>();
    [SerializeField] GameObject father;

    [Header("Planos que se detectan")]
    public List<ARPlane> detectedPlanes = new List<ARPlane>();
    [Header("Setas que se instancian")]
    public List<GameObject> ListaMushrooms = new List<GameObject>();

    [Header("Bools")]
    public bool coroutineStart;
    public bool planeDetect;
    [Header("Time Management")]
    public float time = 0f;
    public float timeMax = 10f;

    RaycastHit hitInfo; //Informacion de cuando el raycast de la camara se encuentre con pared layer XRSimulation
    Ray ray;
    [Header("Punto de Vista")]
    [SerializeField] Camera cameraView;

    void Start()
    {
        coroutineStart = false;
        planeDetect = false;
        ray = new Ray(cameraView.transform.position, cameraView.transform.forward);
    }
    void Update()
    {
        //Hacer que el ray siempre salga del punto de vista de la camara
        ray = new Ray(cameraView.transform.position, cameraView.transform.forward);
        if (planeDetect == true && coroutineStart == false) //si la lista no esta vacia es que detecta planos
        {            
            coroutineStart = true;
            Invoke(nameof(Instance), 2.0f);
            Debug.Log("Corotina Empezada: " + detectedPlanes[0]);
             
        }
        else {
            //coroutineStart= false; --> NO HACER ESTO, PETA
            time += Time.deltaTime;
            if ( time >= timeMax)
            {
                time = 0f;
                coroutineStart = false;
            }
        }

    }
    private void OnEnable()
    {
        if (planeManager != null)
        {
            planeManager.planesChanged += OnPlanesChanged;
        }
    }
    private void OnDisable()
    {
        if (planeManager != null)
        {
            planeManager.planesChanged -= OnPlanesChanged;
        }
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            detectedPlanes.Add(plane);
            planeDetect = true;
            Debug.Log("Plano detectado: " + plane);
        }

        foreach (var plane in args.removed)
        {
            detectedPlanes.Remove(plane);
            Debug.Log("Plano eliminado:" + plane);
        }
    } 

    void Instance() //Instanciar setas
    {
        //Ejecutar Raycast
        //Distancia máxima del ray, sino con Mathf.Infinity no tiene limite
        Physics.Raycast(ray, out hitInfo, Mathf.Infinity);
        Debug.Log("ROTATION" + hitInfo.normal); //la normal de la superficie que se encuentra raycast        
        
        if (hitInfo.normal == new Vector3(1, 0, 0)) //Pared
        {
            //TiposSetas seta = TiposSetas[Random.Range(0, TiposSetas.Count)];
            //TipoSetas.Count --> directamente coje elementos maximos de la lista
            GameObject newmush = Instantiate(TiposSetas[Random.Range(0, TiposSetas.Count)], hitInfo.point, Quaternion.Euler(90f, 0f, -90f), father.transform);
            ListaMushrooms.Add(newmush);
        }
        else if (hitInfo.normal == new Vector3(0, 1, 0)) //Suelo
        {
            GameObject newmush = Instantiate(TiposSetas[Random.Range(0, TiposSetas.Count)], hitInfo.point, Quaternion.Euler(0f, 90f, 0f), father.transform);
            ListaMushrooms.Add(newmush);
        }

        //No funciona ns pq
        //if (hitInfo.transform.gameObject.layer == 30) //30 es XR Simulation
        //{
        //    Debug.Log("Instancias seta");
        //    //ListaMushrooms.Add(prefabObj);
        //}
    }
}
