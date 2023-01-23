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
    [Range(MINNUM, MAXNUM)][SerializeField] private float spacing = 0.02f;


    private float contentHeight
    {
        get
        {
            return (float)rectTransform.rect.height;
        }
    }
    private float contentWidth
    {
        get
        {
            return (float)rectTransform.rect.width;
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
    void OnValidate()
    {
        viewport = GameObject.Find(VIEWPORT);
        rectTransform = viewport.GetComponent<RectTransform>();
        verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
        if(isVertical()){
             UpdatespacingHeight();
        }
    }

    private void UpdatespacingHeight()
    {
        verticalLayoutGroup.spacing = SpacingHeight;
    }
   private bool isVertical(){
    if(name=="VerticalLayoutGroup"){
        return true;
    }
    return false;
   }

}
