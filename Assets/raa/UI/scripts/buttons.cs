using UnityEngine;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] UIDocument uIDocument;
    private VisualElement root;

    // Elementos principales
    private VisualElement inventoryPanel, panelsParent;
    private VisualElement ingredients, close_inventory;

    void Start()
    {
        root = uIDocument.rootVisualElement;

        // 1. Asignamos los contenedores y botones base
        inventoryPanel = root.Q<VisualElement>("inventory");
        panelsParent = root.Q<VisualElement>("panels");
        ingredients = root.Q<VisualElement>("ingredientes_button");
        close_inventory = root.Q<VisualElement>("ocultar_inventario");

        // 2. Eventos de abrir/cerrar inventario
        ingredients.RegisterCallback<ClickEvent>(onClickIngredientes);
        close_inventory.RegisterCallback<ClickEvent>(onClickCloseInventario);

        // 3. BUSCADOR AUTOMÁTICO DE SETAS (Para no escribir una por una)
        // Buscamos cualquier elemento cuyo nombre termine en "_info"
        root.Query<VisualElement>().ForEach(boton =>
        {
            if (boton.name.EndsWith("_info"))
            {
                boton.RegisterCallback<ClickEvent>(onClickAbrirPanelInfo);
            }
        });
    }

    // Una sola función para TODAS las setas
    private void onClickAbrirPanelInfo(ClickEvent evt)
    {
        // 'target' es el botón que pulsaste (ej: amanita_info)
        VisualElement botonPulsado = evt.currentTarget as VisualElement;

        // Creamos el nombre del panel cambiando "_info" por "_panel"
        string nombrePanel = botonPulsado.name.Replace("_info", "_panel");
        VisualElement panelParaMostrar = root.Q<VisualElement>(nombrePanel);

        if (panelParaMostrar != null)
        {
            // Ocultamos el inventario y mostramos el contenedor padre de paneles
            inventoryPanel.style.display = DisplayStyle.None;
            panelsParent.style.display = DisplayStyle.Flex;

            // MOSTRAMOS solo el que nos interesa
            panelParaMostrar.style.display = DisplayStyle.Flex;

            Debug.Log("Mostrando: " + nombrePanel);
        }
    }

    private void onClickIngredientes(ClickEvent evt)
    {
        inventoryPanel.style.display = DisplayStyle.Flex;
        close_inventory.style.display = DisplayStyle.Flex;
        ingredients.style.display = DisplayStyle.None;
    }

    private void onClickCloseInventario(ClickEvent evt)
    {
        inventoryPanel.style.display = DisplayStyle.None;
        panelsParent.style.display = DisplayStyle.None; // Cerramos también los paneles de info
        close_inventory.style.display = DisplayStyle.None;
        ingredients.style.display = DisplayStyle.Flex;
    }
}