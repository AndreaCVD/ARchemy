//using System.Reflection.Emit;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
//using UnityEngine.UIElements.IntegerField;
//using System.Reflection.Emit;
//using EditorGUI.PropertyField;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] UIDocument uIDocument;
    private VisualElement root;

    // Elementos principales
    private VisualElement inventoryPanel, panelsParent, recetas_panel;
    private VisualElement ingredients, recetas, close_inventory, close_recetas, close_panels;
    [SerializeField] IntegerField num_amanita, num_musmire, num_leccinum, num_biporus;
    //public NumericField number_leccinum; // El numero de setas 
    [SerializeField] RecojerSetas inventory;
    
    void Start()
    {
        root = uIDocument.rootVisualElement;
          
        // 1. Asignamos los contenedores y botones base
        inventoryPanel = root.Q<VisualElement>("inventory");
        panelsParent = root.Q<VisualElement>("panels");
        recetas_panel = root.Q<VisualElement>("recetas");

        ingredients = root.Q<VisualElement>("ingredientes_button");
        recetas = root.Q<VisualElement>("recetas_button");

        close_inventory = root.Q<VisualElement>("ocultar_inventario");
        close_recetas = root.Q<VisualElement>("ocultar_recetas");

        close_panels = root.Q<VisualElement>("ocultar_panel");

        //abrir/cerrar inventario
        ingredients.RegisterCallback<ClickEvent>(onClickIngredientes);
        close_inventory.RegisterCallback<ClickEvent>(onClickCloseInventario);

        //abrir/cerrar recetas
        recetas.RegisterCallback<ClickEvent>(onClickRecetas);
        close_recetas.RegisterCallback<ClickEvent>(onClickCloseRecetas);
        
        //Buscar el numeric field
        //num_leccinum = root.Q<VisualElement>("IntegerField");
        num_amanita = root.Q<IntegerField>("num_amanita");
        num_musmire = root.Q<IntegerField>("num_musmire");
        num_leccinum = root.Q<IntegerField>("num_leccinum");
        num_biporus = root.Q<IntegerField>("num_biporus");

        //buscar elementos que tengan _info
        root.Query<VisualElement>().ForEach(boton =>
        {
            if (boton.name.EndsWith("_info"))
            {
                boton.RegisterCallback<ClickEvent>(onClickAbrirPanelInfo);
            }
        });

        //cerrar el panel actual de info
        root.Query<VisualElement>("ocultar_panel").ForEach(btnSalir =>
        {
            btnSalir.RegisterCallback<ClickEvent>(onClickRegresarAlInventario);
        });


    }
    void Update()
    {
        //int a = inventory.num_Leccinum();
        //Debug.Log("INVENTARIO = "+a);
        ////string b =  num_leccinum.text;
        ////Debug.Log(b);
        num_amanita.value = inventory.amanita_lenght;
        num_musmire.value = inventory.musmire_lenght;
        num_leccinum.value = inventory.leccinum_lenght;
        num_biporus.value = inventory.biporus_lenght;


        //Debug.Log(num_leccinum.value);
        //Debug.Log(inventory.leccinum_lenght);


        //if (num_leccinum.text != a)
        //{
        //    num_leccinum.text = inventory.num_Leccinum();
        //}
    }
    // Una sola función para TODAS las setas
    private void onClickAbrirPanelInfo(ClickEvent evt)
    {
        VisualElement botonPulsado = evt.currentTarget as VisualElement;
        string nombrePanel = botonPulsado.name.Replace("_info", "_panel");
        VisualElement panelParaMostrar = root.Q<VisualElement>(nombrePanel);

        if (panelParaMostrar != null)
        {
            // Ocultamos inventario y mostramos el contenedor padre
            inventoryPanel.style.display = DisplayStyle.None;
            ingredients.style.display = DisplayStyle.None;
            close_inventory.style.display = DisplayStyle.None;

            panelsParent.style.display = DisplayStyle.Flex;
            close_panels.style.display = DisplayStyle.Flex;

            // Ocultamos solo los hijos directos para no romper la jerarquía interna
            foreach (var hijo in panelsParent.Children()) hijo.style.display = DisplayStyle.None;

            panelParaMostrar.style.display = DisplayStyle.Flex;


        }

    }
    private void onClickRegresarAlInventario(ClickEvent evt)
    {
        //0cultamos todo el grupo de paneles de info
        panelsParent.style.display = DisplayStyle.None;
        close_panels.style.display = DisplayStyle.None;

        //volvemos a mostrar el inventario
        inventoryPanel.style.display = DisplayStyle.Flex;

        //y los botones del menu inicial
        close_inventory.style.display = DisplayStyle.Flex;
    }

    private void onClickIngredientes(ClickEvent evt)
    {
        inventoryPanel.style.display = DisplayStyle.Flex;
        close_inventory.style.display = DisplayStyle.Flex;
        ingredients.style.display = DisplayStyle.None;
        recetas.style.display = DisplayStyle.None;
    }

    private void onClickCloseInventario(ClickEvent evt)
    {
        inventoryPanel.style.display = DisplayStyle.None;
        panelsParent.style.display = DisplayStyle.None; // Cerramos también los paneles de info
        close_inventory.style.display = DisplayStyle.None;
        ingredients.style.display = DisplayStyle.Flex;
        recetas.style.display = DisplayStyle.Flex;
    }

    private void onClickRecetas(ClickEvent evt)
    {
        recetas_panel.style.display = DisplayStyle.Flex;

        close_recetas.style.display = DisplayStyle.Flex;
        recetas.style.display = DisplayStyle.None;
        ingredients.style.display = DisplayStyle.None;
    }

    private void onClickCloseRecetas(ClickEvent evt)
    {
        recetas_panel.style.display = DisplayStyle.None;

        close_recetas.style.display = DisplayStyle.None;
        recetas.style.display = DisplayStyle.Flex;
        ingredients.style.display = DisplayStyle.Flex;
    }
}