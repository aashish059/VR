using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function to load the Virtual Reality Builder scene
   // public GameObject g;
    public void LoadVRBuilderScene()
    {
        SceneManager.LoadScene("SampleScene"); // Replace "VRBuilderScene" with the actual scene name
    }

    // Function to load the VR Tour scene
    public void LoadVRTourScene()
    {
        SceneManager.LoadScene("CSEvr"); 
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
    /*public void Show(){
        g.SetActive(true);
    }
    public void Hide(){
        g.SetActive(false);
    }*/
    public void LoadDefaultScene(){
        SceneManager.LoadScene("MainMenu");
    }
}
