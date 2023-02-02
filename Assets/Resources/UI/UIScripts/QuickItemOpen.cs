using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Di = System.Diagnostics;
using System;


public class QuickItemOpen : MonoBehaviour
{
    Di.Stopwatch sw;

    TimeSpan ts;
    private Vector3 clickPosition;

    /*[NonSerialized]*/
   

    public GameObject childButton;
    public Transform parent;

    [SerializeField] private RectTransform rectTransform;

    [SerializeField] private Image image;

    [SerializeField] private MyItemDB myItemDB;



    private bool flg = false;
    private bool isOpen = false;
    private const int X=4;
    public void PushDown()
    {
        sw.Reset();
        sw.Start();

    }
    public void PushUp()
    {
        sw.Stop();
        ts = sw.Elapsed;
        if (!isSec())
        {
            return;
        }
        if (!isOpen)
        {
            List<MyItem> myItems = myItemDB.myItemList;
            myItems=myItems.FindAll((item)=>item.count>0);
            
            foreach (MyItem myItem in myItems)
            {
                Transform childTransform = (Transform)Instantiate(childButton).transform;
                childTransform.SetParent(parent, false);
                childTransform.GetComponent<QuickItemData>().setMyItem(myItem.item.id);
            }
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x * X, rectTransform.sizeDelta.y);
            image.color=new Color32(255,255,255,90);
            isOpen = true;
            

        }
        else
        {
            Debug.Log("close");
            var quickItemButtons = GameObject.FindGameObjectsWithTag("QuickChildButton");
            foreach (var Button in quickItemButtons)
            {
                Destroy(Button);
            }
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x / X, rectTransform.sizeDelta.y);
            image.color=new Color32(255,255,255,0);
            isOpen = false;
        }
    }

    void Awake()
    {
        sw = new Di.Stopwatch();
    }

    public bool isSec()
    {   Debug.Log(ts.Milliseconds);
        if (ts.Milliseconds >= 200)
        {
            return true;
        }
        return false;
    }
}

