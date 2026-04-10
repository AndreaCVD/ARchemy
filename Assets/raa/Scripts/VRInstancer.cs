using System.Collections;
using UnityEngine;

public class VRInstancer : MonoBehaviour
{
    [SerializeField] GameObject prefabObj;
    [SerializeField] float delay = 2.0f; // Segundos entre instancias
    private bool planeDetected = false; //Si detecta plano o no
    private Vector3 planePosition; //Como esta el plano

    void Start()
    {
        // Iniciar el coroutine que instancia objetos cada intervalo
        StartCoroutine(Instance());
    }

    private IEnumerator Instance()
    {
        while (true)
        {
            // Esperar el intervalo de tiempo
            yield return new WaitForSeconds(delay);

            // Verificar si se detectó un plano
            if (planeDetected)
            {
                // Instanciar el objeto en la posición del plano
                GameObject nuevoObjeto = Instantiate(prefabObj, planePosition, Quaternion.identity);

                // Opcional: Hacer que el objeto sea hijo de un objeto vacío para organizar la jerarquía
                // nuevoObjeto.transform.SetParent(transform);
            }
        }
    }

    // Método para actualizar la posición del plano cuando se detecta (ej. desde Raycast o input)
    public void UpdatePlane(Vector3 newPos)
    {
        planePosition = newPos;
        planeDetected = true;
    }

    // Ejemplo de detección básica con Raycast (requiere un plano físico en la escena)
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && planeDetected)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Si se hace clic en un objeto con tag "Plano"
                if (hit.collider.CompareTag("Plano"))
                {
                    UpdatePlane(hit.point);
                    // Opcional: Instanciar inmediatamente al hacer clic
                    // GameObject nuevo = Instantiate(prefabObjeto, hit.point, Quaternion.identity);
                }
            }
        }
    }
}
