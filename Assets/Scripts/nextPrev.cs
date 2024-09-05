using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextPrev : MonoBehaviour
{
    public GameObject prev;
    public GameObject next;
    public GameObject curr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextscene(){
        
            next.SetActive(true);
            curr.SetActive(false);
    
}
    public void previous(){
        prev.SetActive(true);
        curr.SetActive(false);
        next.SetActive(false);
    }
}
