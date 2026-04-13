using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInstancer : MonoBehaviour
{
    [SerializeField] GameObject prefabObj;
    //[SerializeField] float delay = 2.0f; // Segundos entre instancias
    //[SerializeField] DetectPlane isPlane; //Si detecta plano o no
    private Vector3 planePosition; //Como esta el plano
    //bool planeDetected;
    //[Tooltip("The list of prefabs available to spawn.")]
    //List<GameObject> m_ObjectPrefabs = new List<GameObject>();
    //public List<GameObject> objectPrefabs
    //{
    //    get => m_ObjectPrefabs;
    //    set => m_ObjectPrefabs = value;
    //}


    public void Instance() //Instanciar
    {
        //while (planeDetected) //mientras se detecte el plano sea true
        //{
                // Instanciar el objeto en la posición del plano
                GameObject nuevoObjeto = Instantiate(prefabObj, planePosition, Quaternion.identity);
                // Opcional: Hacer que el objeto sea hijo de un objeto vacío para organizar la jerarquía
                nuevoObjeto.transform.SetParent(transform);

                //yield return new WaitForSeconds(delay); // Esperar el tiempo especificado
        //}
    }
    public void StopInstance()
    {
        //StopCoroutine(Instance());
        Debug.Log("Se ha parado las intancias");

    }
    //void Update() 
    //{
    //    // Iniciar cuando se detecte plano
    //    if (isPlane.planeDetected == true)
    //    {
    //        planeDetected = true;
    //        StartCoroutine(Instance(delay));
    //    }
    //    else
    //    {
    //        StopCoroutine(Instance(0f));
    //        //No detecta ningun plano
    //        Debug.Log("No se detecta ningun plano");
    //    }
    //}
    //void PlaneDetection()//Detectar Plano
    //{
    //    Ray ray = new Ray(transform.position, Vector3.down);
    //    if (Physics.Raycast(ray, out RaycastHit hit))
    //    {
    //        if (hit.collider.CompareTag("XR Simulation"))
    //        {
    //            planeDetected = true;
    //            //if (corutinaInstanciado == null)
    //            //{
    //            //    corutinaInstanciado = InstanciarPeriodicamente(intervaloSegundos);
    //            //    StartCoroutine(corutinaInstanciado);
    //            //}
    //            UpdatePlane(hit.point);
    //        }
    //        else {
    //            planeDetected = false;
    //        }
    //    }
    //}    
    //// Actualizar posición del plano cuando se detecta con el Raycast
    //public void UpdatePlane(Vector3 newPos)
    //{
    //    planePosition = newPos;
    //    planeDetected = true;
    //}
}
