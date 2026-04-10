using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DetectPlane : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    //[SerializeField] private ARRaycastManager raycastManager;
    //[SerializeField] private GameObject prefabObj;
    private List<ARPlane> detectedPlanes = new List<ARPlane>();

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
            Debug.Log("Plano detectado:" + plane);
        }

        foreach (var plane in args.updated)
        {
            // Actualizar datos del plano si es necesario
        }

        foreach (var plane in args.removed)
        {
            detectedPlanes.Remove(plane);
            Debug.Log("Plano eliminado:" + plane);
        }
    }
}
