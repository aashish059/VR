using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class addButtonNext : MonoBehaviour
{
    public static bool IsAddingButton=false;
    public GameObject buttonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EditMode.InEdit){
            if (Input.GetKeyDown(KeyCode.Q)){
                 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit)){
                    // Store the hit point to use in the CreateTextAtPoint method
                Vector3 hitPoint = hit.point;

                // Create text at the hit point with the input text
                CreateButtonAtPoint(hitPoint);

                // Exit text adding mode
                IsAddingButton = false;
                }
            }
        }
    }
    void CreateButtonAtPoint(Vector3 point){
        
    }
}
