using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class GridSizeCellSetter : MonoBehaviour
{
    private const int MINNUM = 0;
    private const int MAXNUM = 1;

    [Range(MINNUM, MAXNUM)][SerializeField] private float CellWidthPer = 0.8f;
    [Range(MINNUM, MAXNUM)][SerializeField] private float CellHeightPer = 0.3f;
    // [Range(MINNUM, MAXNUM)][SerializeField] private float LeftRightPer = 0.02f;
    // [Range(MINNUM, MAXNUM)][SerializeField] private float spacingWidthPer = 0.18f;
    // [Range(MINNUM, MAXNUM)][SerializeField] private float spacingHeightPer = 0.2f;
    // [Range(MINNUM, MAXNUM)][SerializeField] private float paddingTopPer = 0.2f;
    // [Range(MINNUM, MAXNUM)][SerializeField] private float paddingButtomPer = 0.2f;






    private float CellHeight
    {
        get
        {
            return (float)(contentHeight * CellHeightPer);
        }
    }


    private float CellWidth
    {
        get
        {
            return (float)(contentWidth * (CellWidthPer / 2.0));

        }
    }

    // private float leftRight
    // {
    //     get
    //     {
    //         return contentWidth * (LeftRightPer / 2.0f);
    //     }
    // }

    private RectTransform rectTransform;
    private GridLayoutGroup gridLayout;


    private float contentHeight
    {
        get
        {
            return (float)rectTransform.sizeDelta.y*(-1);
        }
    }

    private float contentWidth
    {
        get
        {
            return (float)rectTransform.sizeDelta.x*(-1);
        }
    }
    
    // private int PaddingTop
    // {
    //     get
    //     {
    //         return (int)(contentHeight * paddingTopPer);
    //     }
    // }

    // private int PaddingButtom
    // {
    //     get
    //     {
    //         return (int)(contentHeight * paddingButtomPer);
    //     }
    // }

    void OnValidate()
    {
        rectTransform = GetComponent<RectTransform>();
        gridLayout = GetComponent<GridLayoutGroup>();
        UpdateCellSize();
        // UpdatePaddingSize();
        // UpdateRectSize();
        // UpdatespacingSize();

    }

    private void UpdateCellSize()
    {
        
        gridLayout.cellSize = new Vector2(CellWidth, CellHeight);
    }
    // private void UpdateRectSize()
    // {
    //     rectTransform.offsetMin = new Vector2(leftRight, 10);
    //     rectTransform.offsetMax = new Vector2(-leftRight, 0f);
    // }
    // private void UpdatespacingSize()
    // {
    //     gridLayout.spacing = new Vector2(contentWidth * spacingWidthPer, contentHeight * spacingHeightPer);
    // }
    // private void UpdatePaddingSize()
    // {
    //     gridLayout.padding.top = PaddingTop;
    //     gridLayout.padding.bottom = PaddingButtom;
    // }


}
