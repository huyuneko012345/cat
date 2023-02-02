using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickItemOnClick : MonoBehaviour
{
    private Vector3 mousePosition;
    private bool createFlg = false;
    private GameObject prefab;
    private QuickItemData quickItemData;
    public void OnClick()
    {
        prefab = quickItemData.GetPrefab();
        createFlg = true;
    }
    void Awake()
    {
        quickItemData=GetComponent<QuickItemData>();
    }
    void Update()
    {
        if (!createFlg)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            try
            {
                Instantiate(prefab, Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity);
                quickItemData.minusCount();
            }
            finally
            {
                createFlg = false;
                prefab = null;
            }
            Debug.Log(quickItemData.GetCount());
            if(isCount()){
                Destroy(this.gameObject);
            }

        }
    }
    private bool isCount(){
        if(quickItemData.GetCount()<=0){
            return true;
        }
        return false;
    }
    }
