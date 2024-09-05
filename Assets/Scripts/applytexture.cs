using UnityEngine;
using System.IO;

public class Uapplytexture : MonoBehaviour
{
    public string textureFileName = "scene1.jpg"; // Name of the texture file in the StreamingAssets folder
    public Material existingMaterial; // Reference to the existing material

    void Start()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, textureFileName);

        Texture2D texture = LoadTexture(filePath);

        if (texture == null)
        {
            Debug.LogError("Failed to load texture at " + filePath);
            return;
        }

        // Assign the texture to the existing material
        existingMaterial.mainTexture = texture;
    }

    Texture2D LoadTexture(string filePath)
    {
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(2, 2);
            if (texture.LoadImage(fileData)) // Automatically resizes the texture dimensions.
            {
                return texture;
            }
        }
        return null;
    }
}
