using System.Linq;
using System.Security.Cryptography;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*クイックアイテムボタンを押下した際の処理*/
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
    private const string FOOD = "food";
    private const string DRINK = "drink";
    private const string ITEM = "item";

    private const int foodId = 1;
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
                var obj = Instantiate(prefab, new Vector3(0, 0.0f, 2f), Quaternion.identity);
                if (isCount(FOOD))
                {
                    Destroy(obj);
                    return;
                }
                if (isCount(DRINK))
                {
                    Destroy(obj);
                    return;
                }
                if (isCount(ITEM))
                {
                    Destroy(obj);
                    return;
                }
                obj.AddComponent<BoxCollider>();
                obj.AddComponent<GrabObject>();
                if (quickItemData.GetMyItem().item.typeId == foodId)
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

    private const int LOWER_COUNT = 1;
    /// <summary>
    /// 生成したオブジェクトが一つだけにするためにある
    /// </summary>
    /// <param name="tagName"></param>
    /// <returns></returns>
    private bool isCount(string tagName)
    {
        if (GameObject.FindGameObjectsWithTag(tagName).Count() <= LOWER_COUNT)
        {

            return false;
        }
        return true;

    }

}
