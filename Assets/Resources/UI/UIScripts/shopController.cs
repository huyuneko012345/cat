using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DialogUtil.FIlePath;
using static DialogUtil.PrefabName;

using TMPro;



public class ShopController : MonoBehaviour
{


    public void addItem()
    {
        GameObject content = GameObject.Find(CONTENT);
        ItemDetaBase itemDataBase = (ItemDetaBase)Resources.Load("DB/ItemDB");
        GameObject itemButtonPrefab = (GameObject)Resources.Load(SHOPITEMBUTTON);
        List<Item> itemList = itemDataBase.itemDataList;
        foreach (Item item in itemList)
        {
            GameObject itemButton = Instantiate(itemButtonPrefab, content.transform);
            TextMeshProUGUI name = itemButton.GetComponentInChildren<TextMeshProUGUI>();
            var button = itemButton.transform.Find("Button");
            Image img= button.GetComponent<Image>();
            img.sprite=item.image;
            name.text = item._name;
        }
    }
}
