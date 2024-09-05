using UnityEngine;

public class hardCode : MonoBehaviour
{
    // Array to hold references to your site game objects
    public GameObject[] sites;

    // Reference to the hub site
    //public GameObject hubSite;

    // Index to keep track of the current active site
    private int currentSiteIndex = 0;  // -1 indicates the hub site

    void Start()
    {
        //sites[0].SetActive(true);
        // Deactivate all sites at the start
       for (int i = 1; i < sites.Length; i++)
        {
            sites[i].SetActive(false);
        }

        // Activate the hub site
        //hubSite.SetActive(true);
    }

    void Update()
    {
    if(PauseMenu.IsPaused==false){
        if (Input.GetMouseButtonDown(0))
        {
            // Get the ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                HandleSpriteClick(hit.collider.gameObject);
            }
        }
        }
    }

    private void HandleSpriteClick(GameObject clickedObject)
    {
        string tag = clickedObject.tag;
        int newSiteIndex = -1;

        // Determine the new site index based on the clicked sprite tag
        switch (tag)
        {
            case "Site1":
                newSiteIndex = 1;
                break;
            case "Site2":
                newSiteIndex = 2;
                break;
            case "Site3":
                newSiteIndex = 6;
                break;
            case "Site4":
                newSiteIndex = 4;
                break;
            case "Site5":
                newSiteIndex = 5;
                break;
            case "Site6":
                newSiteIndex = 3;
                break;
            case "Site7":
                newSiteIndex = 0;
                break;
            case "Site8":
                newSiteIndex = 1;
                break;
            case "Site9":
                newSiteIndex = 1;
                break;
            case "Site10":
                newSiteIndex = 1;
                break;
            case "Site11":
                newSiteIndex = 1;
                break;
            case "Site12":
                newSiteIndex = 1;
                break;
            case "Site13":
                newSiteIndex = 7;
                break;
            case "Site14":
                newSiteIndex = 1;
                break;
            default:
                Debug.LogWarning("Unknown site tag: " + tag);
                break;
        }

        // If a valid site index is found, switch to that site
       if (newSiteIndex >= 0 && newSiteIndex != currentSiteIndex)
        {
            if (currentSiteIndex >= 0)
            {
                sites[currentSiteIndex].SetActive(false);
            }
            /*else
            {
                hubSite.SetActive(false);
            }*/
            sites[newSiteIndex].SetActive(true);
            currentSiteIndex = newSiteIndex;
        }
    }
}

