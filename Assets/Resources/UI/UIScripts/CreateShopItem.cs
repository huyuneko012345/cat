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
    [SerializeField] private ItemMasterData itemMasterData;
    [SerializeField] private GameObject yesNoCanvas;
    [SerializeField] private GameObject ItemescriptionCanvas;

    [SerializeField] private Text itemText;

    public Action<int> Init()
    {
        // ItemMasterData itemMasterData = (ItemMasterData)Resources.Load("BD/ItemMasterData");
        Item[] itemList = itemMasterData.GetItemList();
        Action<int> onChangeFP = (fp) => { };


        ;
        foreach (Item item in itemList)
        {
            int id = item.GetId();
            Transform itemTransform = Instantiate((GameObject)Resources.Load(SHOP_ITEM_BUTTON)).transform;
            GameObject shopContent = GameObject.Find(CONTENT);
            itemTransform.SetParent(shopContent.transform, false);
            itemTransform.GetComponent<ShowItemData>().setItem(id);

            Button button = itemTransform.Find("Button").GetComponent<Button>();
            Button shopItemButton = itemTransform.GetComponent<Button>();
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
