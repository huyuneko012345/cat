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


            return (int)((rectTransform.rect.height*0.2));
        }
    }

    public int CellWidth
    {
        get
        {
                                Debug.Log("よこ幅＝"+rectTransform.rect.width*.01);

            // return (int)((rectTransform.rect.width - (gridLayout.padding.left + gridLayout.padding.right)
            //     - gridLayout.spacing.x * (columnCount - 1)) / columnCount);
                        return (int)((rectTransform.rect.width*0.3));

        }
    }

    private RectTransform rectTransform;
    private GridLayoutGroup gridLayout;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        gridLayout = GetComponent<GridLayoutGroup>();
        
        UpdateCellSize();
    }

    private void UpdateCellSize()
    {

        gridLayout.cellSize = new Vector2(CellWidth,CellHeight);
        int paddingLeft=(int)(CellWidth*0.05);
        int paddingRight=(int)(CellWidth*0.05);
        gridLayout.padding=new RectOffset(paddingLeft,paddingRight,10,10);
    }


}
