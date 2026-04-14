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
