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
    foreach(Item item in itemList)
        {
            GameObject itemButton=Instantiate(itemButtonPrefab, content.transform);
            TextMeshProUGUI name=itemButton.GetComponentInChildren<TextMeshProUGUI>();
            name.text=item._name;
        }
    }
}
