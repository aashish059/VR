using UnityEngine;

public class NextSite : MonoBehaviour
{
    public GameObject n;
    public GameObject r;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Nextscene();
        }
    }

    public void Nextscene()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Next")
            {
                n.SetActive(true);
                r.SetActive(false);
                Debug.Log("Hit");
            }
            else if (hit.transform.gameObject.tag == "Prev")
            {
                r.SetActive(true);
                n.SetActive(false);
                Debug.Log("Hit");
            }
            else if (hit.transform.gameObject.tag == "Next1")
            {
                r.SetActive(false);
                n.SetActive(true);
                Debug.Log("Hit");
            }
            else if (hit.transform.gameObject.tag == "Next2")
            {
                r.SetActive(false);
                n.SetActive(true);
                Debug.Log("Hit");
            }
            else if (hit.transform.gameObject.tag == "Next3")
            {
               r.SetActive(false);
                n.SetActive(true);
                Debug.Log("Hit");
            }
            else if (hit.transform.gameObject.tag == "Next4")
            {
               r.SetActive(false);
                n.SetActive(true);
                Debug.Log("Hit");
            }
            else if (hit.transform.gameObject.tag == "Prev1")
            {
                r.SetActive(true);
                n.SetActive(false);
                Debug.Log("Hit");
            }
            else if (hit.transform.gameObject.tag == "Prev2")
            {
                r.SetActive(true);
                n.SetActive(false);
                Debug.Log("Hit");
            }
            else if (hit.transform.gameObject.tag == "Prev3")
            {
                r.SetActive(true);
                n.SetActive(false);
                Debug.Log("Hit");
            }
            else if (hit.transform.gameObject.tag == "Prev4")
            {
                r.SetActive(true);
                n.SetActive(false);
                Debug.Log("Hit");
            }
            else if (hit.transform.gameObject.tag == "Prev5")
            {
                r.SetActive(true);
                n.SetActive(false);
                Debug.Log("Hit");
            }
            else if (hit.transform.gameObject.tag == "Prev6")
            {
                r.SetActive(true);
                n.SetActive(false);
                Debug.Log("Hit");
            }
            else if (hit.transform.gameObject.tag == "Prev7")
            {
                r.SetActive(true);
                n.SetActive(false);
                Debug.Log("Hit");
            }
        }
    }
}
