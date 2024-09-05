using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenu;
    public GameObject cursor;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(IsPaused){
                Resume();
                cursor.SetActive(true);
            }
            else{
                Pause();
                cursor.SetActive(false);
            }
        }
        
    }
    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale=1f;
        IsPaused=false;
        //cursor.SetActive(true);
    }
    void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale=0f;
        IsPaused=true;
        //cursor.SetActive(false);
    }
     public void LoadDefaultScene(){
        SceneManager.LoadScene("MainMenu");
    }
}
