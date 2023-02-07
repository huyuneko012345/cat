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
        quickItemData = GetComponent<QuickItemData>();
    }
    void Update()
    {
        if (!createFlg)
        {
            return;
        }

        if (isFood())
        {
            return;
        }
        if (isDrink())
        {
            return;
        }
        if (isItem())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;

            try
            {
                var obj = Instantiate(prefab, Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity);
                obj.transform.position = new Vector3(obj.transform.position.x, 1f, obj.transform.position.z);
                obj.AddComponent<BoxCollider>();
                obj.AddComponent<GrabObject>();
                if (quickItemData.GetMyItem().item.typeId == 1)
                {
                    obj.AddComponent<foodeating>();
                }
                quickItemData.minusCount();
            }
            finally
            {
                createFlg = false;
                prefab = null;
            }


        }
    }

    private bool isFood()
    {
        bool r = GameObject.FindGameObjectWithTag("food") != null ? true : false;
        Debug.Log("isfood :" + r);
        return r;
    }
    private bool isDrink()
    {
        bool r = GameObject.FindGameObjectWithTag("drink") != null ? true : false;
        return r;
    }
    private bool isItem()
    {
        bool r = GameObject.FindGameObjectWithTag("item") != null ? true : false;
        return r;
    }
}
