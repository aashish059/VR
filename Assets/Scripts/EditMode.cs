using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditMode : MonoBehaviour
{
    public static bool InEdit = false;
    public GameObject Editmenu;
    //public GameObject cursor;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(InEdit){
                Resume();
                //cursor.SetActive(true);
            }
            else{
                Pause();
                //cursor.SetActive(false);
            }
        }
        
    }
    public void Resume(){
        Editmenu.SetActive(false);
        //Time.timeScale=1f;
        InEdit=false;
        //cursor.SetActive(true);
    }
    void Pause(){
        Editmenu.SetActive(true);
        //Time.timeScale=0f;
        InEdit=true;
        //cursor.SetActive(false);
    }
     public void LoadDefaultScene(){
        SceneManager.LoadScene("MainMenu");
    }
}


