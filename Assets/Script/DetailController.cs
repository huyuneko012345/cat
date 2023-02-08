using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetailController : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update

    private bool detailFlg = false;
    [SerializeField] private GameObject DetailCanvas;
    // Update is called once per frame
    void Awake()
    {
        if (this.DetailCanvas == null)
        {
            DetailCanvas = GameObject.Find("DetailCanvas");
        }
    }
    // クリック
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        
        if (detailFlg)
        {
            detailFlg = false;
        }
        else
        {
            detailFlg = true;
        }
        this.DetailCanvas.SetActive(detailFlg);

    }
}
