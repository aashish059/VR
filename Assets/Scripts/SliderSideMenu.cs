using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderSideMenu : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform sidemenuRectTransform;
    private float width;
    private float startPositionX;
    private float startingAnchoredPositionX;
    public enum Side{left,right}
    public Side side;
    // Start is called before the first frame update
    void Start(){
        width=Screen.width;
    }
   public void OnDrag(PointerEventData eventData){
    //throw new System.NotImplementedException();
    sidemenuRectTransform.anchoredPosition = new Vector2(Mathf.Clamp(startingAnchoredPositionX-(startPositionX-eventData.position.x),GetMinPosition(), GetMaxPosition()),0);
   }
   public void OnPointerDown(PointerEventData eventData){
    //throw new System.NotImplementedException();
    StopAllCoroutines();
    startPositionX=eventData.position.x;
    startingAnchoredPositionX=sidemenuRectTransform.anchoredPosition.x;
   }
   public void OnPointerUp(PointerEventData eventData){
    //throw new System.NotImplementedException();
    StartCoroutine(HandleMenuSlide(.25f,sidemenuRectTransform.anchoredPosition.x, isAfterHalfPoint()?GetMinPosition():GetMaxPosition()));
   }
   private bool isAfterHalfPoint(){
    if(side==Side.right)
        return sidemenuRectTransform.anchoredPosition.x<width;
    else
        return sidemenuRectTransform.anchoredPosition.x<0;
   }
   private float GetMinPosition(){
    if(side==Side.right)
        return width/2;
    return -width*.4f;
   }
   private float GetMaxPosition(){
    if(side==Side.right)
        return width * 1.4f;
    return width/2;
   }
   private IEnumerator HandleMenuSlide(float slideTime,float startingX,float targetX){
    for(float i=0;i<slideTime;i+=.025f){
        sidemenuRectTransform.anchoredPosition = new Vector2(Mathf.Lerp(startingX,targetX,i/slideTime),0);
        yield return new WaitForSecondsRealtime(.025f);
    }
   }
}
