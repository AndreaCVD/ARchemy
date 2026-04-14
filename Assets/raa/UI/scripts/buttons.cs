using UnityEngine;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] UIDocument uIDocument;

    private VisualElement root;

    private VisualElement inventoryPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        root = uIDocument.rootVisualElement;

        var ingredients = root.Q<VisualElement>("ingredientes_button");
        var recetas = root.Q<VisualElement>("recetas_button");

        inventoryPanel = root.Q<VisualElement>("inventory");

        ingredients.RegisterCallback<ClickEvent>(onClickIngredientes);
        recetas.RegisterCallback<ClickEvent>(onClickRecetas);
    }

    private void onClickRecetas(ClickEvent evt)
    {

    }

    private void onClickIngredientes(ClickEvent evt)
    {

        Debug.Log("Pressed");

        if (inventoryPanel != null)
        {
            inventoryPanel.style.display = DisplayStyle.Flex;
        }

    }
}