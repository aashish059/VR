using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
   public GameObject g;
   public void Show(){
    g.SetActive(true);
   }
   public void Hide(){
    g.SetActive(false);
   }
}