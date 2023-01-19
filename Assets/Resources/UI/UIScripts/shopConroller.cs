using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DialogUtil.FIlePath;
using TMPro;



public class shopConroller : MonoBehaviour
{

    public void addItem(GameObject content)
    {
        ItemDetaBase itemDataBase=(ItemDetaBase)Resources.Load("DB/ItemDB");
        GameObject itemButtonPrefab = (GameObject)Resources.Load(SHOPITEMBUTTON);
        List<Item> itemList=itemDataBase.itemDataList;
        int count=itemList.Count;
        for (int i = 0; i < count; i++)
        {
            GameObject itemButton=Instantiate(itemButtonPrefab, content.transform);
            TextMeshProUGUI name=itemButton.GetComponentInChildren<TextMeshProUGUI>();
            name.text=itemList[i]._name;
        }
    }
}
