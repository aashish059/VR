using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneSwitch : MonoBehaviour
{
    public GameObject[] gameObjects; // Array to hold the sequence of GameObjects
    public UnityEngine.UI.Button switchButton; // Reference to the button
    public UnityEngine.UI.Button previousButton;
    private int currentIndex = 0; // Index to keep track of the currently active GameObject

    void Start()
    {
        // Initialize the GameObjects, making sure only the first one is active
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(i == 0);
        }

        // Add a listener to the button to call the SwitchGameObject method when clicked
        switchButton.onClick.AddListener(SwitchGameObject);
        previousButton.onClick.AddListener(SwitchToPreviousGameObject);
    }

    void SwitchGameObject()
    {
        // Get the next index
        int nextIndex = (currentIndex + 1) % gameObjects.Length;

        // Check if the next GameObject has a material with an image texture
        if (HasImageTexture(gameObjects[nextIndex]))
        {
            // Disable the current GameObject
            gameObjects[currentIndex].SetActive(false);

            // Update the index to the next GameObject
            currentIndex = nextIndex;

            // Enable the next GameObject
            gameObjects[currentIndex].SetActive(true);
        }
        else
        {
            Debug.Log("Next GameObject does not have a material with an image texture.");
        }
    }

    void SwitchToPreviousGameObject()
    {
        // Get the previous index
        int previousIndex = (currentIndex - 1 + gameObjects.Length) % gameObjects.Length;

        // Disable the current GameObject
        gameObjects[currentIndex].SetActive(false);

        // Update the index to the previous GameObject
        currentIndex = previousIndex;

        // Enable the previous GameObject
        gameObjects[currentIndex].SetActive(true);
    }

    bool HasImageTexture(GameObject gameObject)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material material = renderer.material;
            if (material != null && material.mainTexture != null)
            {
                // Check if the texture is an image (Texture2D)
                if (material.mainTexture is Texture2D)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
