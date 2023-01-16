using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSizeCellSetter : MonoBehaviour
{
    
    // [SerializeField] private int rowPer = 40;
    // [SerializeField] private int columnPer = 10;
    
    public float CellHeight
    {
        get
        {
            // return (int)((rectTransform.rect.height - (gridLayout.padding.top + gridLayout.padding.bottom)
            //     - gridLayout.spacing.y * (rowCount - 1)) / rowCount);


            return (int)(contentHeigth*0.3);
        }
    }

    public int CellWidth
    {
        get
        {
                                Debug.Log("よこ幅＝"+rectTransform.rect.width*.01);

            // return (int)((rectTransform.rect.width - (gridLayout.padding.left + gridLayout.padding.right)
            //     - gridLayout.spacing.x * (columnCount - 1)) / columnCount);
                        return (int)(contentWidth*0.4);

        }
    }

    private RectTransform rectTransform;
    private GridLayoutGroup gridLayout;

    
    private float contentHeigth{
        get{
            return (int)rectTransform.rect.height;
        }
    }

    private float contentWidth{
        get{
            return (int)rectTransform.rect.width;
        }
    }
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        gridLayout = GetComponent<GridLayoutGroup>();
        UpdateCellSize();
    }

    private void UpdateCellSize()
    {
        // TODO 空白の調整をする
        gridLayout.cellSize = new Vector2(CellWidth,CellHeight);
        int paddingLeft=(int)(contentWidth*0.05);
        int paddingRight=(int)(contentWidth*0.05);
        int paddingTop=(int)(contentHeigth*0.1);
        int paddingBottom=(int)(contentHeigth*0.2);
        gridLayout.padding=new RectOffset(paddingLeft,paddingRight,paddingTop,paddingBottom);
        gridLayout.spacing=new Vector2(contentWidth*0.3f,contentHeigth*0.2f);
    }


}
