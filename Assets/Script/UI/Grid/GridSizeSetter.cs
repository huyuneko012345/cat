using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
/// <summary>
///　グリッドサイズを%で調節する
/// </summary>
public class GridSizeSetter : MonoBehaviour
{
     private const int MINNUM = 0;
     private const int MAXNUM = 1;

    [Range(MINNUM, MAXNUM)][SerializeField] private float CellWidthPer = 0.8f;
    [Range(MINNUM, MAXNUM)][SerializeField] private float CellHeightPer = 0.3f;
    [Range(MINNUM, MAXNUM)][SerializeField] private float spacingWidthPer = 0.1f;
    [Range(MINNUM, MAXNUM)][SerializeField] private float spacingHeightPer = 0.03f;

    [Range(MINNUM, MAXNUM)][SerializeField] private float paddingTopPer = 0.2f;
    [Range(MINNUM, MAXNUM)][SerializeField] private float paddingButtomPer = 0.2f;

    [SerializeField]private GameObject viewport;


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

    private float SpacingHeight
    {
        get
        {
            return (float)(contentHeight * spacingHeightPer);
        }
    }

    private float SpacingWidth
    {
        get
        {
            return (float)(contentWidth * spacingWidthPer);

        }
    }


    
    private RectTransform rectTransform;
    private GridLayoutGroup gridLayout;



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

    private int PaddingTop
    {
        get
        {
            return (int)(contentHeight * paddingTopPer);
        }
    }

    private int PaddingButtom
    {
        get
        {
            return (int)(contentHeight * paddingButtomPer);
        }
    }

    void Update()
    {
        rectTransform=viewport.GetComponent<RectTransform>();
        gridLayout = GetComponent<GridLayoutGroup>();
        UpdateCellSize();
        UpdatespacingSize();
        UpdatePaddingBottom();
        UpdatePaddingTop();
    }
    void OnValidate()
    {
       
        rectTransform=viewport.GetComponent<RectTransform>();
        gridLayout = GetComponent<GridLayoutGroup>();
        UpdateCellSize();
        UpdatespacingSize();
        UpdatePaddingBottom();
        UpdatePaddingTop();

    }


    private void UpdateCellSize()
    {
        gridLayout.cellSize = new Vector2(CellWidth, CellHeight);
    }

    private void UpdatespacingSize()
    {
       
        gridLayout.spacing = new Vector2(SpacingWidth, SpacingHeight);
    }

    private void UpdatePaddingTop(){
        gridLayout.padding.top=PaddingTop;
    }
    private void UpdatePaddingBottom(){
        gridLayout.padding.bottom=PaddingButtom;
    }




}
