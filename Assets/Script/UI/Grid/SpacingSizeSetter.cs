using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///verticalLayoutGroupまたはhorizontalLayoutGroupの間隔を%で調節するクラス
/// </summary>
[ExecuteAlways]
public class SpacingSizeSetter : MonoBehaviour
{
    private const int MINNUM = 0;
    private const int MAXNUM = 1;
    [Range(MINNUM, MAXNUM)][SerializeField] private float spacing = 0.03f;
    [SerializeField]private GameObject viewport;


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



    private RectTransform rectTransform;
    private VerticalLayoutGroup verticalLayoutGroup;
    private HorizontalLayoutGroup horizontalLayoutGroup;
    private void Update() {
        rectTransform = viewport?.GetComponent<RectTransform>();
        verticalLayoutGroup = gameObject?.GetComponent<VerticalLayoutGroup>();
        horizontalLayoutGroup = gameObject?.GetComponent<HorizontalLayoutGroup>();
        if (rectTransform == null)
        {
            return;
        }
        if (verticalLayoutGroup != null)
        {
            UpdatespacingHeight();
        }
        if (horizontalLayoutGroup != null)
        {
            UpdatespacingWidth();
        }
    }
    void OnValidate()
    {
        rectTransform = viewport?.GetComponent<RectTransform>();
        verticalLayoutGroup = gameObject?.GetComponent<VerticalLayoutGroup>();
        horizontalLayoutGroup = gameObject?.GetComponent<HorizontalLayoutGroup>();
        if (rectTransform == null)
        {
            return;
        }
        if (verticalLayoutGroup != null)
        {
            UpdatespacingHeight();
        }
        if (horizontalLayoutGroup != null)
        {
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
    private void log()
    {
        Debug.Log("log");
    }


}
