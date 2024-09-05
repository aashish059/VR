using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    public Canvas siteCanvas;
    public GameObject g;  // Assign the canvas of the site in the Unity Inspector

    private bool isVisible = false;  // Track the visibility state of the canvas

    void Update()
    {
        // Check if the 'H' key is pressed
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("H key pressed");  // Log to confirm key press

            // Toggle the canvas visibility
            isVisible = !isVisible;
            siteCanvas.enabled = isVisible;
            g.SetActive(isVisible);

            Debug.Log("Canvas visibility toggled to: " + isVisible);  // Log the new visibility state
        }
    }
}
