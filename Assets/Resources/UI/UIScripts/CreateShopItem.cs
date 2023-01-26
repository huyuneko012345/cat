using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static DialogUtil.FIlePath;
using static DialogUtil.PrefabName;
using TMPro;


public class CreateShopItem : MonoBehaviour
{
    [SerializeField] private int[] itemIds;

    [SerializeField] private GameObject yesNoCanvas;
    [SerializeField] private GameObject ItemescriptionCanvas;

    [SerializeField] private Text itemText;

    public Action<int> Init()
    {
        Action<int> onChangeFP = (fp) => { };

        
;
        foreach (int id in itemIds)
        {
            Transform item = Instantiate((GameObject)Resources.Load(SHOP_ITEM_BUTTON)).transform;
            GameObject shopContent = GameObject.Find(CONTENT);
            item.SetParent(shopContent.transform, false);
            item.GetComponent<ShowItemData>().setItem(id);
            var a= item.GetComponent<ShowItemData>();
            
            Button button = item.Find("Button").GetComponent<Button>();
            Button shopItemButton = item.GetComponent<Button>();
            int key = id;
            
            button.onClick.AddListener(() =>
            {
                OpenItemDescription(key);
            });
            shopItemButton.onClick.AddListener(() =>
            {
                OpenYesNoWindow(key);
            });
            
            onChangeFP += (fp) =>
            {
                bool canBuy = fp >= ItemMasterData.GetValue(key).price;
                // button.interactable = canBuy;
                shopItemButton.interactable = canBuy;
            };
        }
        return onChangeFP;
    }
    private void ItemTextInit()
    {
        if (ItemMasterData.GetLength() > 0 && itemIds.Length > 0)
        {
            itemText.text = ItemMasterData.GetValue(itemIds[0]).text;
        }
        else
        {
            itemText.text = "品切れ";
        }
    }
    private void OpenItemDescription(int id)
    {
        ItemescriptionCanvas.SetActive(true);
        ItemescriptionCanvas.GetComponent<ShowItemData>().setItem(id);
    }
    private void OpenYesNoWindow(int id)
    {
        yesNoCanvas.SetActive(true);
        yesNoCanvas.GetComponent<ShowItemData>().setItem(id);
    }
}
