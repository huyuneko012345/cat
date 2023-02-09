using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SizeSetterUtils.PrefabName;

[ExecuteAlways]
public class SpacingSizeSetter : MonoBehaviour
{
    private const int MINNUM = 0;
    private const int MAXNUM = 1;
    [Range(MINNUM, MAXNUM)][SerializeField] private float spacing = 0.03f;


    private float contentHeight
    {
        get
        {
            return (float)rectTransform?.rect.height;
        }
    }
    private float contentWidth
    {
        get
        {
            return (float)rectTransform?.rect.width;
        }
    }

    private float SpacingHeight
    {
        get
        {
            return (float)(contentHeight * spacing);
        }
    }
    private float SpacingWidth
    {
        get
        {
            return (float)(contentWidth * spacing);

        }
    }



    private GameObject viewport;
    private RectTransform rectTransform;
    private VerticalLayoutGroup verticalLayoutGroup;
    private HorizontalLayoutGroup horizontalLayoutGroup;
    void OnValidate()
    {
        viewport = GameObject.Find(VIEWPORT);
        rectTransform = viewport?.GetComponent<RectTransform>();
        verticalLayoutGroup = gameObject?.GetComponent<VerticalLayoutGroup>();
        horizontalLayoutGroup=gameObject?.GetComponent<HorizontalLayoutGroup>();
        if(rectTransform==null){
            return;
        }    
        if(verticalLayoutGroup!=null){
            UpdatespacingHeight();
        }
        if(horizontalLayoutGroup!=null){
            UpdatespacingWidth();
        }
             
             

    }

    private void UpdatespacingHeight()
    {
        verticalLayoutGroup.spacing = SpacingHeight;
    }
    private void UpdatespacingWidth()
    {
        verticalLayoutGroup.spacing = SpacingWidth;
    }
    private void log(){
        Debug.Log("log");
    }


}
