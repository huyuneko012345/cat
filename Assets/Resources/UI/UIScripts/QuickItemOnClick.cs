using System.Linq;
using System.Security.Cryptography;
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

        // if (isFood())
        // {
        //     return;
        // }
        // if (isDrink())
        // {
        //     return;
        // }
        // if (isItem())
        // {
        //     return;
        // }
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;

            try
            {
                var obj = Instantiate(prefab, new Vector3(0, 0.0f, 2f), Quaternion.identity);
                if (isFood() && obj.tag == "food")
                {
                    Destroy(obj);
                    return;
                }
                if (isDrink() && obj.tag == "drink")
                {
                    Destroy(obj);
                    return;
                }
                if (isItem() && obj.tag == "item")
                {
                    Destroy(obj);
                    return;
                }
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

        if (GameObject.FindGameObjectsWithTag("food").Count() <= 1)
        {

            return false;
        }
        return true;
    }
    private bool isDrink()
    {
        if (GameObject.FindGameObjectsWithTag("drink").Count() <= 1)
        {
            return false;
        }
        return true;
    }
    private bool isItem()
    {
        if (GameObject.FindGameObjectsWithTag("item").Count() <= 1)
        {
            return false;
        }
        return true;
    }
}
