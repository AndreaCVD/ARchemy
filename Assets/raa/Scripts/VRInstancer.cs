using UnityEngine;

public class VRInstancer : MonoBehaviour
{
    public GameObject prefabObjeto;
    public float intervaloTiempo = 2.0f; // Segundos entre instancias
    private bool planoDetectado = false;
    private Vector3 posicionPlano;

    void Start()
    {
        // Iniciar el coroutine que instancia objetos cada intervalo
        StartCoroutine(InstanciarPeriodicamente());
    }

    private IEnumerator InstanciarPeriodicamente()
    {
        while (true)
        {
            // Esperar el intervalo de tiempo
            yield return new WaitForSeconds(intervaloTiempo);

            // Verificar si se detectó un plano
            if (planoDetectado)
            {
                // Instanciar el objeto en la posición del plano
                GameObject nuevoObjeto = Instantiate(prefabObjeto, posicionPlano, Quaternion.identity);

                // Opcional: Hacer que el objeto sea hijo de un objeto vacío para organizar la jerarquía
                // nuevoObjeto.transform.SetParent(transform);
            }
        }
    }

    // Método para actualizar la posición del plano cuando se detecta (ej. desde Raycast o input)
    public void ActualizarPlano(Vector3 nuevaPosicion)
    {
        posicionPlano = nuevaPosicion;
        planoDetectado = true;
    }

    // Ejemplo de detección básica con Raycast (requiere un plano físico en la escena)
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && planoDetectado)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Si se hace clic en un objeto con tag "Plano"
                if (hit.collider.CompareTag("Plano"))
                {
                    ActualizarPlano(hit.point);
                    // Opcional: Instanciar inmediatamente al hacer clic
                    // GameObject nuevo = Instantiate(prefabObjeto, hit.point, Quaternion.identity);
                }
            }
        }
    }
}
