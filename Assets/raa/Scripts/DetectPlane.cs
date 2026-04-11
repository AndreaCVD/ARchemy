using System.Collections.Generic;

using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DetectPlane : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    //[SerializeField]  VRInstancer intanciar;
    [SerializeField] GameObject prefabObj;
    //[SerializeField] private ARRaycastManager raycastManager;
    //[SerializeField] private GameObject prefabObj;
    public List<ARPlane> detectedPlanes = new List<ARPlane>();
    public bool planeDetected;

    void Update()
    {
        if(detectedPlanes != null) //si la lista no esta vacia es que detecta planos
        {
            //InvokeRepeating("Instance()", 3.0f, 3.0f);
            Debug.Log("--PLANO--: " + detectedPlanes[0].planeId );
        }

    }
    //private List<XRRaycastHit> hits = new List<XRRaycastHit>();
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
    //void Update()
    //{
    //    //// Verificar si se detectó un plano nuevo o si hay input de usuario
    //    //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    //    //{
    //        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

    //        // Realizar raycast para encontrar planos
    //        if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
    //        {
    //            XRPlaneHit hit = hits[0];

    //            // Colocar objeto en la posición del plano detectado
    //            if (hit.trackable is XRPlane plane)
    //            {
    //                Vector3 position = hit.pose.position;
    //                Quaternion rotation = hit.pose.rotation;

    //                // Instanciar objeto automáticamente
    //                Instantiate(prefabObj, position, rotation, transform);
    //            }
    //        }
    //    //}
    //}
    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            detectedPlanes.Add(plane);
            // Debug.Log("Plano detectado:" + plane.planeId+" en posición"+ plane.center);
            Debug.Log("Plano detectado: " + plane);
        }

        foreach (var plane in args.removed)
        {
            detectedPlanes.Remove(plane);
            //intanciar.StopInstance();
            Debug.Log("Plano eliminado:" + plane);
        }
    }

    void Instance() //Instanciar
    {
        Debug.Log("Instancias seta");

        // Instanciar el objeto en la posición del plano
        //GameObject nuevoObjeto = Instantiate(prefabObj, planePosition, Quaternion.identity);
        // Opcional: Hacer que el objeto sea hijo de un objeto vacío para organizar la jerarquía
        //nuevoObjeto.transform.SetParent(transform);
    }

//    // Ejemplo correcto para obtener un TrackableId válido:
//    List<ARRaycastHit> _hits = new List<ARRaycastHit>();
//if (_raycastManager.Raycast(screenCenter, _hits, TrackableType.PlaneWithinPolygon))
//{
//    TrackableId _planeID = _hits.trackableId; // Ahora será válido
//    ARPlane _arPlane = _arPlaneManager.GetPlane(_planeID);
//}
}
