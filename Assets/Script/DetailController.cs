using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailController : MonoBehaviour
{
    // Start is called before the first frame update

    private bool detailFlg = false;
    [SerializeField]private GameObject DetailCanvas;
    // Update is called once per frame
    void Awake()
    {
        if(this.DetailCanvas==null){
            DetailCanvas=(GameObject)Resources.Load("UI/prefabs/DetailCanvas");
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
}
