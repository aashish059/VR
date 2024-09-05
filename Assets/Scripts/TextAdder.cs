using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextAdder : MonoBehaviour
{
    [SerializeField] TMP_InputField textInputField; // Reference to the Input Field for user text input
    public UnityEngine.UI.Button addTextButton; // Reference to the Button for adding text
    public GameObject textPrefab; // Reference to a prefab for the text GameObject
    public GameObject parentGameObject; // Reference to the GameObject that will be the parent of the new text objects
    public TMP_Dropdown colorDropdown; // Reference to the Dropdown for selecting text color
    private bool isAddingText = false; // Flag to check if we are in text adding mode
    private Color selectedColor = Color.black; // Default text color

    private GameObject selectedTextObject; // Reference to the currently selected text object

    private void Start()
    {
        // Add listener to the button to call the OnAddTextButtonClick method when clicked
        addTextButton.onClick.AddListener(OnAddTextButtonClick);

        // Add listener to the dropdown to call the OnColorDropdownValueChanged method when value changes
        colorDropdown.onValueChanged.AddListener(OnColorDropdownValueChanged);
        
        // Initialize the dropdown options with colors
        InitializeColorDropdown();
    }

    private void Update()
    {
        if(EditMode.InEdit){
        // Check if we are in text adding mode and for the spacebar input
        if (isAddingText && Input.GetKeyDown(KeyCode.Space))
        {
            // Raycast to find the point in the scene where the user clicked
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Store the hit point to use in the CreateTextAtPoint method
                Vector3 hitPoint = hit.point;

                // Create text at the hit point with the input text
                CreateTextAtPoint(hitPoint);

                // Exit text adding mode
                isAddingText = false;
            }
        }

        
    if (Input.GetMouseButtonDown(0))
    {
        // Raycast to find the text object the user wants to select
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Text")) // Assuming the text objects have the tag "Text"
            {
                SelectTextObject(hit.collider.gameObject);
                Debug.Log("Selected Text");
            }
        }
        else
        {
            Debug.Log("No hits");
        }
    }

    // Check for the "Delete" key to remove the selected text object
    if (Input.GetKeyDown(KeyCode.Delete))
    {
        DeleteSelectedText();
    }
}
    }
    private void OnAddTextButtonClick()
    {
        // Enter text adding mode
        isAddingText = true;
    }

    private void CreateTextAtPoint(Vector3 point)
    {
        // Get the text from the input field
        string userText = textInputField.text;

        // Debug log to check the text from the input field
        Debug.Log("User text: " + userText);

        // Instantiate the text prefab at the specified point
        GameObject newTextObject = Instantiate(textPrefab, point, Quaternion.identity);

        // Set the parent of the new text object
        if (parentGameObject != null)
        {
            newTextObject.transform.SetParent(parentGameObject.transform);
        }

        // Set the text of the TextMeshPro component in the new GameObject
        TextMeshPro textMeshPro = newTextObject.GetComponent<TextMeshPro>();
        if (textMeshPro != null)
        {
            textMeshPro.text = userText;
            textMeshPro.color = selectedColor; // Set the selected color

            // Debug log to check the assigned text
            Debug.Log("Assigned text: " + textMeshPro.text);

            // Assign the tag "Text" to the new text object
            newTextObject.tag = "Text";
        }
        else
        {
            Debug.LogError("TextMeshPro component not found on the text prefab.");
        }
    }
    

    private void InitializeColorDropdown()
    {
        // Clear existing options
        colorDropdown.ClearOptions();

        // Define a list of colors
        List<string> colorOptions = new List<string> { "Black", "Red", "Green", "Blue", "Yellow", "White" };

        // Add options to the dropdown
        colorDropdown.AddOptions(colorOptions);
    }

    private void OnColorDropdownValueChanged(int index)
    {
        // Set the selected color based on the dropdown value
        switch (index)
        {
            case 0: selectedColor = Color.black; break;
            case 1: selectedColor = Color.red; break;
            case 2: selectedColor = Color.green; break;
            case 3: selectedColor = Color.blue; break;
            case 4: selectedColor = Color.yellow; break;
            case 5: selectedColor = Color.white; break;
            default: selectedColor = Color.black; break;
        }

        // Debug log to check the selected color
        Debug.Log("Selected color: " + selectedColor);
    }

    private void SelectTextObject(GameObject textObject)
    {
        // Store the reference to the selected text object
        selectedTextObject = textObject;

        // Optional: Add any visual indication of selection, like changing color or adding an outline
        TextMeshPro textMeshPro = selectedTextObject.GetComponent<TextMeshPro>();
        if (textMeshPro != null)
        {
            textMeshPro.color = Color.cyan; // Example of changing color to indicate selection
        }
    }

    private void DeleteSelectedText()
    {
        if (selectedTextObject != null)
        {
            Destroy(selectedTextObject);
            selectedTextObject = null;
        }
    }
    
}
